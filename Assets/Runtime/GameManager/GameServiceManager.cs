using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MystiCorp.Runtime.GameManager {

    [CreateAssetMenu(fileName = GameServiceManagerResourceName, menuName = "Scriptables/Services/" + GameServiceManagerResourceName)]
    public class GameServiceManager : ScriptableObject {

        [SerializeField] private List<Service> services;

        private const string GameServiceManagerResourceName = "Game Service Manager";

        private static Instance instance;
        private static Instance I => instance != null ? instance : SpawnInstance();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static Instance SpawnInstance() {

            instance = new GameObject($"{GameServiceManagerResourceName} Instance").AddComponent<Instance>();
            DontDestroyOnLoad(instance);

            // initialize services
            var manager = Resources.Load<GameServiceManager>(GameServiceManagerResourceName);
            foreach (var service in manager.services)
                service.Initialize();

            return instance;
        }

        private class Instance : MonoBehaviour {

            public event Action OnStart;
            public event Action OnUpdate;
            public event Action OnLateUpdate;
            public event Action OnFixedUpdate;
            public event Action<Scene, Scene> OnSceneChange;
            public event Action OnOnApplicationQuit;

            private void Awake              () => SceneManager.activeSceneChanged += (from, to) => OnSceneChange?.Invoke(from, to);
            private void Start              () => OnStart               ?.Invoke();
            private void Update             () => OnUpdate              ?.Invoke();
            private void LateUpdate         () => OnLateUpdate          ?.Invoke();
            private void FixedUpdate        () => OnFixedUpdate         ?.Invoke();
            private void OnApplicationQuit  () => OnOnApplicationQuit   ?.Invoke();
        }

        public abstract class Service : ScriptableObject {

            public void Initialize() {

                instance.OnStart                += Start;
                instance.OnUpdate               += Update;
                instance.OnLateUpdate           += LateUpdate;
                instance.OnFixedUpdate          += FixedUpdate;
                instance.OnSceneChange          += OnSceneChange;
                instance.OnOnApplicationQuit    += OnApplicationQuit;

                RuntimeInitializeOnLoad();
            }

            protected static MonoBehaviour Instance => I;

            protected virtual void RuntimeInitializeOnLoad  () { }
            protected virtual void Start                    () { }
            protected virtual void Update                   () { }
            protected virtual void LateUpdate               () { }
            protected virtual void FixedUpdate              () { }
            protected virtual void OnSceneChange            (Scene from, Scene to) { }
            protected virtual void OnApplicationQuit        () { }

            #region Editor
            #if UNITY_EDITOR

            // displayed in editor for easy access
            [SerializeField, HideInInspector] private GameServiceManager gameServiceManager;

            [CustomEditor(typeof(Service), true)]
            protected class ServiceEditor : Editor {

                private const string
                    noManagersError       = "No Game Service Managers Found!",
                    multipleManagersError = "Multiple Game Service Managers Found!",
                    addToManagerButton    = "Add to Game Service Manager";

                private Service Service => target as Service;

                private bool IsOnManager(
                    out GameServiceManager manager,
                    out string log) {

                    var managerGUIDs = AssetDatabase.FindAssets($"t:{nameof(GameServiceManager)}");

                    manager = null;
                    log = "";

                    // already has manager
                    if (Service.gameServiceManager != null) {
                        manager = Service.gameServiceManager;
                    }

                    // no managers found
                    else if (managerGUIDs.Length == 0) {
                        log = noManagersError;
                        return false;
                    }

                    // multiple managers found
                    else if (managerGUIDs.Length > 1) {
                        log = multipleManagersError;
                        return false;
                    }

                    // find manager asset
                    else {
                        string managerPath = AssetDatabase.GUIDToAssetPath(managerGUIDs[0]);
                        manager = AssetDatabase.LoadAssetAtPath<GameServiceManager>(managerPath);
                    }

                    return manager.services.Contains(Service);
                }

                public override void OnInspectorGUI() {

                    base.OnInspectorGUI();

                    EditorGUILayout.Space();

                    bool onManager = IsOnManager(out var manager, out var log);

                    // error message
                    if (log != "") {
                        EditorGUILayout.HelpBox(log, MessageType.Error, true);
                    }

                    // prompt to add service to manager
                    else if (!onManager && log == "" && GUILayout.Button(addToManagerButton)) {

                        manager.services.Add(Service);
                        EditorUtility.SetDirty(manager);

                        Service.gameServiceManager = manager;
                        EditorUtility.SetDirty(Service);

                        AssetDatabase.SaveAssets();
                    }

                    // display connected manager
                    else if (onManager) {
                        GUI.enabled = false;
                        EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(gameServiceManager)));
                        GUI.enabled = true;
                    }
                }
            }

            #endif
            #endregion
        }
    }
}

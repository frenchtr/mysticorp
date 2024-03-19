using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UScene = UnityEngine.SceneManagement.Scene;

namespace MystiCorp.Runtime.Game_Manager {

    [CreateAssetMenu(fileName = GameManagerResourceName, menuName = "Services/Game Manager")]
    public class GameManager : ScriptableObject {

        [SerializeField] private List<Manager> managers;

        private static MonoBehaviour I => instance != null ? instance : SpawnGameManager();
        private static MonoBehaviour instance;

        private const string GameManagerResourceName = "Game Manager";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static MonoBehaviour SpawnGameManager() {

            var instance = new GameObject("Game Manager Instance").AddComponent<Instance>();
            DontDestroyOnLoad(instance);

            instance.Init(Resources.Load<GameManager>(GameManagerResourceName));

            return GameManager.instance = instance;
        }

        private class Instance : MonoBehaviour {

            public event Action OnStart;
            public event Action OnUpdate;
            public event Action OnLateUpdate;
            public event Action OnFixedUpdate;
            public event Action<UScene, UScene> OnSceneChange;
            public event Action OnOnApplicationQuit;

            public void Init(GameManager gm) {

                SceneManager.activeSceneChanged += (from, to) => this.OnSceneChange?.Invoke(from, to);

                foreach (var manager in gm.managers)
                    manager.GameManagerInitialize(this);
            }

            private void Start              () => this.OnStart               ?.Invoke();
            private void Update             () => this.OnUpdate              ?.Invoke();
            private void LateUpdate         () => this.OnLateUpdate          ?.Invoke();
            private void FixedUpdate        () => this.OnFixedUpdate         ?.Invoke();
            private void OnApplicationQuit  () => this.OnOnApplicationQuit   ?.Invoke();
        }

        public class Manager : ScriptableObject {

            public void GameManagerInitialize(UnityEngine.Object instance) {

                var inst = instance as Instance;

                inst.OnStart                    += this.Start;
                inst.OnUpdate                   += this.Update;
                inst.OnLateUpdate               += this.LateUpdate;
                inst.OnFixedUpdate              += this.FixedUpdate;
                inst.OnSceneChange              += this.OnSceneChange;
                inst.OnOnApplicationQuit        += this.OnApplicationQuit;

                this.RuntimeInitializeOnLoad();
            }

            protected static MonoBehaviour Instance => I;

            protected virtual void RuntimeInitializeOnLoad() { }
            protected virtual void Start() { }
            protected virtual void Update() { }
            protected virtual void LateUpdate() { }
            protected virtual void FixedUpdate() { }
            protected virtual void OnSceneChange(UScene from, UScene to) { }
            protected virtual void OnApplicationQuit() { }
            protected virtual void OnValidate() { }

            #region Editor
            #if UNITY_EDITOR

            // displayed in editor for easy access
            [SerializeField, HideInInspector] private GameManager gameManager;

            private bool IsAddedToGameManager(out GameManager gameManager, out string log) {

                var gameManagerGUIDs = AssetDatabase.FindAssets("t:GameManager");

                gameManager = null;
                log = "";

                if (gameManagerGUIDs.Length == 0) {
                    log = "No Game Managers Found!";
                    return false;
                }

                if (gameManagerGUIDs.Length > 1) {
                    log = "Multiple Game Managers Found!";
                    return false;
                }

                string gameManagerGUID = gameManagerGUIDs[0],
                       gameManagerPath = AssetDatabase.GUIDToAssetPath(gameManagerGUID);
                gameManager = AssetDatabase.LoadAssetAtPath<GameManager>(gameManagerPath);

                return gameManager.managers.Contains(this);
            }

            [CustomEditor(typeof(Manager), true)]
            protected class ManagerEditor : Editor {

                public override void OnInspectorGUI() {

                    var manager = this.target as Manager;

                    bool canAdd = !manager.IsAddedToGameManager(out var gameManager, out var log);

                    if ((canAdd || log != "") && GUILayout.Button("Add to Game Manager"))
                        if (canAdd) {
                            gameManager.managers.Add(manager);
                            manager.gameManager = gameManager;

                            EditorUtility.SetDirty(manager);
                            AssetDatabase.SaveAssets();
                        }
                        else Debug.LogError(log);

                    GUI.enabled = false;
                    EditorGUILayout.PropertyField(this.serializedObject.FindProperty("gameManager"));
                    GUI.enabled = true;

                    base.OnInspectorGUI();
                }
            }

            #endif
            #endregion
        }
    }
}

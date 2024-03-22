using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MystiCorp.Runtime.Debug_Canvas
{
    public class DebugCanvas : MonoBehaviour
    {
        [SerializeField]
        private KeyCode showKey;
        [SerializeField]
        private GameObject content;
        [SerializeField]
        private Button buttonPrefab;

        private readonly string[] excludeMethods = new[]
        {
            nameof(Start),
            nameof(Update),
            nameof(NotExcluded),
        };

        private bool NotExcluded(MethodInfo method) => !excludeMethods.Contains(method.Name);

        private void Start()
        {
            var methods = GetType()
                .GetMethods(BindingFlags.DeclaredOnly |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance)
                .Where(NotExcluded);

            foreach (var method in methods)
            {
                var button = Instantiate(buttonPrefab, content.transform);
                button.onClick.AddListener(() => method.Invoke(this, null));
                button.GetComponentInChildren<TextMeshProUGUI>().text = method.Name;
            }
        }

        private void Update()
        {
            content.SetActive(Input.GetKey(showKey));
        }

        private void ReloadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

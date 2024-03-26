using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;

namespace MystiCorp.Runtime.MainCamera
{
    public class OnAwakeSetCameraVariableValueToCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera cameraToAssign;
        [SerializeField]
        private CameraVariable cameraVariable;

        private void Awake()
        {
            cameraVariable.Value = cameraToAssign;
        }
    }
}

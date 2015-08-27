using UnityEngine;

namespace Game.Camera
{
    public class CameraView : MonoBehaviour
    {
        private UnityEngine.Camera mainCamera;

        void Start()
        {
            mainCamera = UnityEngine.Camera.main;
        }

        void Update()
        {
        }
    }
}

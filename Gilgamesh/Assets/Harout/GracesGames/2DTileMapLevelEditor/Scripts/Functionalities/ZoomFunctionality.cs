using UnityEngine;

using GracesGames.Common.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.Functionalities {

    public class ZoomFunctionality : MonoBehaviour {

        // ----- PRIVATE VARIABLES -----

        // Main camera components for zoom feature
        private Camera _mainCameraComponent;

        // Initial size used to reset the zoom functionality
        private float _mainCameraInitialSize;

        // ----- SETUP -----

        // Find the camera, position it in the middle of our level and store initial zoom level
        public void Setup(int width, int height) {
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (mainCamera != null) {
                mainCamera.transform.position =
                    new Vector3(width / 2.0f, height / 2.0f, mainCamera.transform.position.z);
                //Store initial zoom level
                _mainCameraComponent = mainCamera.GetComponent<Camera>();
                _mainCameraInitialSize = _mainCameraComponent.orthographic
                    ? _mainCameraComponent.orthographicSize
                    : _mainCameraComponent.fieldOfView;
                SetupClickListeners();
            } else {
                Debug.LogError("Object with tag MainCamera not found");
            }
        }

        // Hook up Zoom methods to Zoom buttons
        private void SetupClickListeners() {
            Utilities.FindButtonAndAddOnClickListener("ZoomInButton", ZoomIn);
            Utilities.FindButtonAndAddOnClickListener("ZoomOutButton", ZoomOut);
            Utilities.FindButtonAndAddOnClickListener("ZoomDefaultButton", ZoomDefault);
        }

        // ----- UPDATE -----

        private void Update() {
            // If Equals is pressed, zoom in
            if (Input.GetKeyDown(KeyCode.Equals)) {
                ZoomIn();
            }
            // if Minus is pressed, zoom out
            if (Input.GetKeyDown(KeyCode.Minus)) {
                ZoomOut();
            }
            // If 0 is pressed, reset zoom
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                ZoomDefault();
            }
        }

        // ----- PRIVATE METHODS -----

        // Increment the orthographic size or field of view of the camera, thereby zooming in
        private void ZoomIn() {
            if (_mainCameraComponent.orthographic) {
                _mainCameraComponent.orthographicSize = Mathf.Max(_mainCameraComponent.orthographicSize - 1, 1);
            } else {
                _mainCameraComponent.fieldOfView = Mathf.Max(_mainCameraComponent.fieldOfView - 1, 1);
            }
        }

        // Decrement the orthographic size or field of view of the camera, thereby zooming out
        private void ZoomOut() {
            if (_mainCameraComponent.orthographic) {
                _mainCameraComponent.orthographicSize += 1;
            } else {
                _mainCameraComponent.fieldOfView += 1;
            }
        }

        // Resets the orthographic size or field of view of the camera, thereby resetting the zoom level
        private void ZoomDefault() {
            if (_mainCameraComponent.orthographic) {
                _mainCameraComponent.orthographicSize = _mainCameraInitialSize;
            } else {
                _mainCameraComponent.fieldOfView = _mainCameraInitialSize;
            }
        }
    }
}
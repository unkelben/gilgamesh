// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.


// Slimmed down to only feature panning (zooming done in alternative way)

using UnityEngine;

namespace GracesGames._2DTileMapLevelEditor.Scripts {

    public class MoveCamera : MonoBehaviour {

        // VARIABLES

        public float PanSpeed = 4.0f; // Speed of the camera when being panned

        private Vector3 _mouseOrigin; // Position of cursor when mouse dragging starts
        private bool _isPanning; // Is the camera being panned?

        // UPDATE

        void Update() {
            // Get the right mouse button
            if (Input.GetMouseButtonDown(1)) {
                // Get mouse origin
                _mouseOrigin = Input.mousePosition;
                _isPanning = true;
            }

            // Disable movements on button release
            if (!Input.GetMouseButton(1)) _isPanning = false;

            // Move the camera on it's XY plane
            if (!_isPanning) return;
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _mouseOrigin);
            Vector3 move = new Vector3(pos.x * PanSpeed, pos.y * PanSpeed, 0);
            transform.Translate(move, Space.Self);
        }
    }
}
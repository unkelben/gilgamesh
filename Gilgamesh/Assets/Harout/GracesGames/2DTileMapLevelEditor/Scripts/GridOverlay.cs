using UnityEngine;

namespace GracesGames._2DTileMapLevelEditor.Scripts {

	public class GridOverlay : MonoBehaviour {

		public static GridOverlay Instance;

		// Sizes of the grid
		private int _gridSizeX = 10;

		private int _gridSizeY = 10;
		private const int GridSizeZ = 0;

		// Steps taken when moving the grid
		public float SmallStep = 0.5f;

		// Steps to define the dimensions of each square
		public float LargeStep = 1;

		// Starting position
		public float StartX;

		public float StartY;
		public float StartZ;

		// Offsets
		private float _offsetX = -0.5f;

		private float _offsetY = -0.5f;

		// Material of the grid
		public Material LineMaterial;

		// Color of the grid
		public Color MainColor = new Color(1f, 1f, 1f, 1f);

		// Method to Instantiate the GridOverlay instance and keep it from destroying
		void Awake() {
			if (Instance == null) {
				Instance = this;
			} else if (Instance != this) {
				Destroy(gameObject);
			}
		}

		// Changes the width size of the grid
		public void SetGridSizeX(int x) {
			_gridSizeX = x;
		}

		// Changes the height size of the grid
		public void SetGridSizeY(int y) {
			_gridSizeY = y;
		}

		// Updates the dimensions per square with 0.5
		public void GridSizeUp() {
			LargeStep += 0.5f;
		}

		// Update the dimensions per square with -0.5
		public void GridSizeDown() {
			LargeStep -= 0.5f;
		}

		// Move the grid up by smallStep amount
		public void GridUp() {
			_offsetY += SmallStep;
		}

		// Move the grid down by smallStep amount
		public void GridDown() {
			_offsetY -= SmallStep;
		}

		// Move the grid left by smallStep amount
		public void GridLeft() {
			_offsetX -= SmallStep;
		}

		// Move the grid right by smallStep amount
		public void GridRight() {
			_offsetX += SmallStep;
		}

		// Draws the grid
		void OnPostRender() {
			// Make sure largeStep never <= 0, since then the program crashes
			LargeStep = Mathf.Max(LargeStep, 0.5f);
			// set the current material
			LineMaterial.SetPass(0);

			GL.Begin(GL.LINES);

			GL.Color(MainColor);

			//Layers
			for (float j = 0; j <= _gridSizeY; j += LargeStep) {
				//X axis lines
				for (float i = 0; i <= GridSizeZ; i += LargeStep) {
					GL.Vertex3(StartX + _offsetX, j + _offsetY, StartZ + i);
					GL.Vertex3(_gridSizeX + _offsetX, j + _offsetY, StartZ + i);
				}

				//Z axis lines
				for (float i = 0; i <= _gridSizeX; i += LargeStep) {
					GL.Vertex3(StartX + i + _offsetX, j + _offsetY, StartZ);
					GL.Vertex3(StartX + i + _offsetX, j + _offsetY, GridSizeZ);
				}
			}

			//Y axis lines
			for (float i = 0; i <= GridSizeZ; i += LargeStep) {
				for (float k = 0; k <= _gridSizeX; k += LargeStep) {
					GL.Vertex3(StartX + k + _offsetX, StartY + _offsetY, StartZ + i);
					GL.Vertex3(StartX + k + _offsetX, _gridSizeY + _offsetY, StartZ + i);
				}
			}

			GL.End();
		}
	}
}

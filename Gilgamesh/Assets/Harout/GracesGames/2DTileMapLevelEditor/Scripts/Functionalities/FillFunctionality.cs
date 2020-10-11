using UnityEngine;
using UnityEngine.UI;

using GracesGames.Common.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.Functionalities {

	public class FillFunctionality : MonoBehaviour {

		// ----- PRIVATE VARIABLES -----

		// The level editor
		private LevelEditor _levelEditor;

		// UI objects to display pencil/fill mode
		private Texture2D _fillCursor;

		// Boolean to determine whether to use fill mode or pencil mode
		private bool _fillMode;

		// UI objects to display pencil/fill mode
		private Image _pencilModeButtonImage;

		private Image _fillModeButtonImage;

		// Color to display disabled mode
		private static readonly Color32 DisabledColor = new Color32(150, 150, 150, 255);

		// ----- SETUP -----

		public void Setup(Texture2D fillCursor) {
			_levelEditor = LevelEditor.Instance;
			_fillCursor = fillCursor;
			SetupClickListeners();
			// Initally disable fill mode
			DisableFillMode();
		}

		// Hook up Mode methods to Mode button
		private void SetupClickListeners() {
			// Hook up EnablePencilMode method to PencilButton
			GameObject pencilModeButton = Utilities.FindButtonAndAddOnClickListener("PencilButton", DisableFillMode);
			_pencilModeButtonImage = pencilModeButton.GetComponent<Image>();
			// Hook up EnableFillMode method to FillButton
			GameObject fillModeButton = Utilities.FindButtonAndAddOnClickListener("FillButton", EnableFillMode);
			_fillModeButtonImage = fillModeButton.GetComponent<Image>();
		}

		// ----- UPDATE -----

		private void Update() {
			// If F is pressed, toggle FillMode;
			if (Input.GetKeyDown(KeyCode.F)) {
				ToggleFillMode();
			}
			// Update the cursor
			UpdateCursor();
		}

		// Update cursor (only show fill cursor on grid)
		private void UpdateCursor() {
			// Save the world point were the mouse clicked
			Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (_levelEditor.GetScriptEnabled() && _fillMode && _levelEditor.ValidPosition((int) worldMousePosition.x, (int) worldMousePosition.y, 0)) {
				// If valid position, set cursor to bucket
				Cursor.SetCursor(_fillCursor, new Vector2(25, 90), CursorMode.Auto);
			} else {
				// Else reset cursor
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		}

		// ----- PUBLIC METHODS -----

		// Returns whether fill mode is enabled
		public bool GetFillMode() {
			return _fillMode;
		}

		// ----- PRIVATE METHODS -----

		// Toggle fill mode (between fill and pencil mode)
		private void ToggleFillMode() {
			if (_fillMode) {
				DisableFillMode();
			} else {
				EnableFillMode();
			}
		}

		// Enable fill mode and update UI
		private void EnableFillMode() {
			_fillMode = true;
			_fillModeButtonImage.GetComponent<Image>().color = Color.black;
			_pencilModeButtonImage.GetComponent<Image>().color = DisabledColor;
		}

		// Disable fill mode and update UI and cursor
		private void DisableFillMode() {
			_fillMode = false;
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			_pencilModeButtonImage.GetComponent<Image>().color = Color.black;
			_fillModeButtonImage.GetComponent<Image>().color = DisabledColor;
		}
	}
}
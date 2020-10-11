using UnityEngine;
using UnityEngine.UI;

using GracesGames.Common.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.Functionalities {

	public class GridFunctionality : MonoBehaviour {
		
		// ----- PRIVATE VARIABLES -----

		// UI objects to toggle the grid
		private GameObject _gridEyeImage;

		private GameObject _gridClosedEyeImage;
		private Toggle _gridEyeToggleComponent;
		
		// ----- SETUP -----

		public void Setup(int width, int height) {
			SetupClickListeners();
			// Setup grid overlay
			SetupGridOverlay(width, height);
			// Initialy enable grid
			ToggleGrid(true);
		}

		// Hook up Grid methods to Grid button
		private void SetupClickListeners() {
			// Hook up ToggleGrid method to GridToggle
			GameObject gridEyeToggle = Utilities.FindGameObjectOrError("GridEyeToggle");
			_gridEyeImage = Utilities.FindGameObjectOrError("GridEyeImage");
			_gridClosedEyeImage = Utilities.FindGameObjectOrError("GridClosedEyeImage");
			_gridEyeToggleComponent = gridEyeToggle.GetComponent<Toggle>();
			_gridEyeToggleComponent.onValueChanged.AddListener(ToggleGrid);

			// Hook up Grid Size methods to Grid Size buttons
			Utilities.FindButtonAndAddOnClickListener("GridSizeUpButton", GridOverlay.Instance.GridSizeUp);
			Utilities.FindButtonAndAddOnClickListener("GridSizeDownButton", GridOverlay.Instance.GridSizeDown);

			// Hook up Grid Navigation methods to Grid Navigation buttons
			Utilities.FindButtonAndAddOnClickListener("GridUpButton", GridOverlay.Instance.GridUp);
			Utilities.FindButtonAndAddOnClickListener("GridDownButton", GridOverlay.Instance.GridDown);
			Utilities.FindButtonAndAddOnClickListener("GridLeftButton", GridOverlay.Instance.GridLeft);
			Utilities.FindButtonAndAddOnClickListener("GridRightButton", GridOverlay.Instance.GridRight);
		}

		// Define the level sizes as the sizes for the grid
		private void SetupGridOverlay(int width, int height) {
			GridOverlay.Instance.SetGridSizeX(width);
			GridOverlay.Instance.SetGridSizeY(height);
		}
		
		// ----- PRIVATE METHODS -----

		// Method that toggles the grid
		private void ToggleGrid(bool enable) {
			GridOverlay.Instance.enabled = enable;
			// Update UI 
			_gridEyeImage.SetActive(!enable);
			_gridClosedEyeImage.SetActive(enable);
			_gridEyeToggleComponent.targetGraphic =
				enable ? _gridClosedEyeImage.GetComponent<Image>() : _gridEyeImage.GetComponent<Image>();
		}
	}
}
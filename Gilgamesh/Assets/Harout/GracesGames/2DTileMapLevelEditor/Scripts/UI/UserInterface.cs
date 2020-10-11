using UnityEngine;
using UnityEngine.UI;

using GracesGames.Common.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.UI {

	public class UserInterface : MonoBehaviour {

		// ----- PUBLIC VARIABLES -----

		// Button Prefab used to create tile selection buttons for each GameObjects.
		public GameObject ButtonPrefab;

		// Dimensions used for the representation of the GameObject tile selection buttons
		// Represented using a 0-200 slider in the editor
		[Range(1.0f, 200.0f)] public float ButtonSize = 100;

		// Dimensions used for the representation of the selected tile game object
		// Represented using a 0-200 slider in the editor
		[Range(1.0f, 200.0f)] public float SelectedTileSize = 100;

		// Scale of the images in regards to the total image rectangle size
		[Range(0.1f, 1.0f)] public float ButtonImageScale = 0.8f;

		// Sprite to indicate no tile is currently selected
		public Sprite NoSelectedTileImage;

		// ----- PRIVATE VARIABLES -----

		// The Level Editor using this User Interface
		private LevelEditor _levelEditor;

		// The UI panel used to store the Level Editor options
		private GameObject _levelEditorPanel;

		// Open button to reopen the level editor after closing it
		private GameObject _openButton;

		// GameObject used to show the currently selected tile
		private GameObject _selectedTile;

		// Image to indicate the currently selected tile
		private Image _selectedTileImage;

		// GameObject as the parent for all the GameObject in the tiles selection
		private GameObject _prefabParent;

		// ----- SETUP -----

		public void Setup() {
			name = ("LevelEditorUI");
			_levelEditor = LevelEditor.Instance;
			_levelEditorPanel = Utilities.FindGameObjectOrError("LevelEditorPanel");
			SetupOpenCloseButton();
			SetupSelectedTile();
			SetupPrefabsButtons();
			// Set the initial prefab button size
			UpdatePrefabButtonsSize();
		}

		private void SetupOpenCloseButton() {
			// Hook up CloseLevelEditorPanel method to CloseButton
			Utilities.FindButtonAndAddOnClickListener("CloseButton", _levelEditor.CloseLevelEditorPanel);

			// Hook up OpenLevelEditorPanel method to OpenButton and disable at start
			_openButton = Utilities.FindButtonAndAddOnClickListener("OpenButton", _levelEditor.OpenLevelEditorPanel);
			_openButton.SetActive(false);
		}

		private void SetupSelectedTile() {
			_selectedTile = Utilities.FindGameObjectOrError("SelectedTile");
			// Find the image component of the SelectedTileImage GameObject
			_selectedTileImage = Utilities.FindGameObjectOrError("SelectedTileImage").GetComponent<Image>();
		}

		private void SetupPrefabsButtons() {
			// Find the prefabParent object and set the cellSize for the tile selection buttons
			_prefabParent = Utilities.FindGameObjectOrError("Prefabs");
			if (_prefabParent.GetComponent<GridLayoutGroup>() == null) {
				Debug.LogError("Make sure prefabParent has a GridLayoutGroup component");
			}
			// Counter to determine which tile button is pressed
			int tileCounter = 0;
			//Create a button for each tile in tiles
			foreach (Transform tile in _levelEditor.GetTiles()) {
				int index = tileCounter;
				GameObject button = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity);
				button.name = tile.name;
				button.GetComponent<Image>().sprite = tile.gameObject.GetComponent<SpriteRenderer>().sprite;
				button.transform.SetParent(_prefabParent.transform, false);
				button.transform.localScale = new Vector3(ButtonImageScale, ButtonImageScale, ButtonImageScale);
				// Add a click handler to the button
				button.GetComponent<Button>().onClick.AddListener(() => { _levelEditor.ButtonClick(index); });
				tileCounter++;
			}
		}

		// ----- UPDATE -----

		// Updates the User Interface so it is configurable at run-time
		void Update() {
			// Only continue if the script is enabled (level editor is open) and there are no errors
			if (!_levelEditor.GetScriptEnabled()) return;
			// Update the button size to scale at runtime
			UpdatePrefabButtonsSize();
			// Update the selected tile game object to scale at runtime
			UpdateSelectedTileSize();
		}

		// Update the size of the prefab tile objects, the images will be square to keep the aspect ratio original
		private void UpdatePrefabButtonsSize() {
			_prefabParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(ButtonSize, ButtonSize);
		}

		// Update the size of the selected tile game object, the images will be scaled to half that
		private void UpdateSelectedTileSize() {
			_selectedTile.GetComponent<RectTransform>().sizeDelta = new Vector2(SelectedTileSize, SelectedTileSize);
			_selectedTileImage.GetComponent<RectTransform>().sizeDelta = new Vector2(SelectedTileSize / 2, SelectedTileSize / 2);
		}

		// ----- TOGGLES -----

		// Enables/disables the Level Editor Panel
		public void ToggleLevelEditorPanel(bool enable) {
			_levelEditorPanel.SetActive(enable);
		}

		// Enables/disables the Open Button (inverse of Level Editor Panel toggle)
		public void ToggleOpenButton(bool enable) {
			_openButton.SetActive(enable);
		}

		// ----- SET IMAGES -----

		// Updates the selected tile image.
		// Either sets it to the NoSelectedTileImage when the tileIndex is empty (default -1)
		// Or to the sprite of the selected tile
		public void SetSelectedTileImageSprite(int tileIndex) {
			_selectedTileImage.sprite = (tileIndex == LevelEditor.GetEmpty()
				? NoSelectedTileImage
				: _levelEditor.GetTiles()[tileIndex].gameObject.GetComponent<SpriteRenderer>().sprite);
		}
	}
}
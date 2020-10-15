using System;
using UnityEngine;

using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using GracesGames.Common.Scripts;
using GracesGames.SimpleFileBrowser.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.Functionalities {

	public class LoadFunctionality : MonoBehaviour {

		// ----- PRIVATE VARIABLES -----

		// The level editor
		private LevelEditor _levelEditor;

		// The file browser
		private GameObject _fileBrowserPrefab;

		// The file extension of the file to load
		private string[] _fileExtensions;

		// Method to identifiction the tiles when loading
		private TileIdentificationMethod _loadMethod;

		// Temporary variable to save state of level editor before opening file browser and restore it after save/load
		private bool _preFileBrowserState = true;

		// The tiles used to build the level
		private List<Transform> _tiles;

		// Starting path of the file browser
		private string _startPath;

		// ----- SETUP -----

		public void Setup(GameObject fileBrowserPrefab, string[] fileExtensions, TileIdentificationMethod loadMethod,
			List<Transform> tiles, string startPath) {
			_levelEditor = LevelEditor.Instance;
			_fileBrowserPrefab = fileBrowserPrefab;
            _fileExtensions = fileExtensions;
			_loadMethod = loadMethod;
			_tiles = tiles;
			_startPath = startPath;
			SetupClickListeners();
		}

		// Hook up Save/Load Level method to Save/Load button
		private void SetupClickListeners() {
			Utilities.FindButtonAndAddOnClickListener("LoadButton", OpenFileBrowser);
		}

		// ----- PUBLIC METHODS -----

		// Load from a file using a path
		public void LoadLevelUsingPath(string path) {
			// Enable the LevelEditor when the fileBrowser is done
			_levelEditor.ToggleLevelEditor(_preFileBrowserState);
			if (path.Length != 0) {
				BinaryFormatter bFormatter = new BinaryFormatter();
				// Reset the level
				_levelEditor.ResetBeforeLoad();
				FileStream file = File.OpenRead(path);
				// Convert the file from a byte array into a string
				string levelData = bFormatter.Deserialize(file) as string;
				// We're done working with the file so we can close it
				file.Close();
				LoadLevelFromStringLayers(levelData);
			} else {
				Debug.Log("Invalid path given");
			}
		}

		// ----- PRIVATE METHODS -----

		// Open a file browser to load files
		private void OpenFileBrowser() {
			_preFileBrowserState = _levelEditor.GetScriptEnabled();
			// Disable the LevelEditor while the fileBrowser is open
			_levelEditor.ToggleLevelEditor(false);
			// Create the file browser and name it
			GameObject fileBrowserObject = Instantiate(_fileBrowserPrefab, transform);
			fileBrowserObject.name = "FileBrowser";
			// Set the mode to save or load
			FileBrowser fileBrowserScript = fileBrowserObject.GetComponent<FileBrowser>();
			fileBrowserScript.SetupFileBrowser(ViewMode.Landscape, _startPath);
			fileBrowserScript.OpenFilePanel(_fileExtensions);
            // Subscribe to OnFileSelect event (call LoadLevelUsingPath using path) 
            fileBrowserScript.OnFileSelect += LoadLevelUsingPath;
            // Subscribe to OnFileBrowserClose event (call ReopenLevelEditor)
            fileBrowserScript.OnFileBrowserClose += ReopenLevelEditor;
        }

        // Reopens the level editor after closing the file browser
        private void ReopenLevelEditor()
        {
            _levelEditor.ToggleLevelEditor(true);
        }

        // Method that loads the layers
        private void LoadLevelFromStringLayers(string content) {
			// Split our level on layers by the new tabs (\t)
			List<string> layers = new List<string>(content.Split('\t'));
			foreach (string layer in layers) {
				if (layer.Trim() != "") {
					LoadLevelFromString(int.Parse(layer[0].ToString()), layer.Substring(1));
				}
			}
		}

		// Loads one layer
		private void LoadLevelFromString(int layer, string content) {
			// Split our layer on rows by the new lines (\n)
			List<string> lines = new List<string>(content.Split('\n'));
			// Place each block in order in the correct x and y position
			for (int i = 0; i < lines.Count; i++) {
				string[] blockIDs = lines[i].Split(',');
				for (int j = 0; j < blockIDs.Length - 1; j++) {
					_levelEditor.CreateBlock(TileStringRepresentationToInt(blockIDs[j]), j, lines.Count - i - 1, layer);
				}
			}

			// Update to only show the correct layer(s)
			_levelEditor.UpdateLayerVisibility();
		}

		// Transforms the tile identification type read from the file to a integer used as internal representation in the level editor
		// For index, parse the string to int
		// For name, transverse the Tiles and try to match on game object name or EMPTY
		// Defaults to LevelEditor.GetEmpty() (-1)
		private int TileStringRepresentationToInt(string tileString) {
			switch (_loadMethod) {
				case TileIdentificationMethod.Index:
					try {
						return int.Parse(tileString);
					}
					catch (FormatException) {
						Debug.LogError("Error: Trying to load a Name based level using Index loading");
						return LevelEditor.GetEmpty();
					}
					catch (ArgumentNullException) {
						Debug.LogError("Error: Encountered a null in the file");
						return LevelEditor.GetEmpty();
					}
				case TileIdentificationMethod.Name:
					if (tileString == "EMPTY")
						return LevelEditor.GetEmpty();
					for (int i = 0; i < _tiles.Count; i++) {
						if (_tiles[i].name == tileString) {
							return i;
						}
					}

					return LevelEditor.GetEmpty();
				default:
					return LevelEditor.GetEmpty();
			}
		}
	}
}
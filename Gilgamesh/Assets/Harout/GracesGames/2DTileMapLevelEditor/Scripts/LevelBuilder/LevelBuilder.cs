using UnityEngine;

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GracesGames._2DTileMapLevelEditor.Scripts.LevelBuilder {

	// Enum used to define save type
	public enum TileIdentificationMethod {
		Index,
		Name
	}

	// The LevelBuilder allows the user to build level without requiring the LevelEditor prefab or script
	// It contains the public method LoadLevelUsingPath which will load the file from the path and build the level
	// For an example, see the LevelBuilderDemoCaller script
	// Most of the code is extracted from the LoadFunctionality and LevelEditor scripts
	public class LevelBuilder : MonoBehaviour {

		// The tileset used to build the level
		[SerializeField] private Tileset _tileset;

		// The load method to identify the tiles
		[SerializeField] private TileIdentificationMethod _loadMethod;

		// The interal representation of an empty tile
		[SerializeField] private int _empty = -1;

		// The tiles array from the tileset
		private List<Transform> _tiles;

		// GameObject as the parent for all the layers (to keep the Hierarchy window clean)
		private GameObject _tileLevelParent;

		// Dictionary as the parent for all the GameObjects per layer
		private readonly Dictionary<int, GameObject> _layerParents = new Dictionary<int, GameObject>();

		// Setup the TileLevel prefab and set the _tile variable
		private void Awake() {
			_tileLevelParent = GameObject.Find("TileLevel") ?? new GameObject("TileLevel");
			_tiles = _tileset.Tiles;
		}

		// Load from a file using a path
		public void LoadLevelUsingPath(string path) {
			if (path.Length != 0) {
				BinaryFormatter bFormatter = new BinaryFormatter();
				// Reset the level
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

		// Method that loads one layer
		private void LoadLevelFromString(int layer, string content) {
			// Split our layer on rows by the new lines (\n)
			List<string> lines = new List<string>(content.Split('\n'));
			// Place each block in order in the correct x and y position
			for (int i = 0; i < lines.Count; i++) {
				string[] blockIDs = lines[i].Split(',');
				for (int j = 0; j < blockIDs.Length - 1; j++) {
					CreateBlock(TileStringRepresentationToInt(blockIDs[j]), j, lines.Count - i - 1, layer);
				}
			}
		}

		// Transforms the tile identification type read from the file to a integer used as internal representation in the level editor
		// For index, parse the string to int
		// For name, transverse the Tiles and try to match on game object name or EMPTY
		// Defaults to _empty (-1)
		private int TileStringRepresentationToInt(string tileString) {
			switch (_loadMethod) {
				case TileIdentificationMethod.Index:
					try {
						return int.Parse(tileString);
					}
					catch (FormatException) {
						Debug.LogError("Error: Trying to load a Name based level using Index loading");
						return _empty;
					}
					catch (ArgumentNullException) {
						Debug.LogError("Error: Encountered a null in the file");
						return _empty;
					}
				case TileIdentificationMethod.Name:
					if (tileString == "EMPTY")
						return _empty;
					for (int i = 0; i < _tiles.Count; i++) {
						if (_tiles[i].name == tileString) {
							return i;
						}
					}
					return _empty;
				default:
					return _empty;
			}
		}

		// Method that creates a GameObject for a given value and position
		// The value should be the index in the _tiles variable, resulting in the tile to build
		private void CreateBlock(int value, int xPos, int yPos, int zPos) {
			// If the value is not empty, set it to the correct tile
			if (value != _empty) {
				BuildBlock(_tiles[value], xPos, yPos, GetLayerParent(zPos).transform);
			}
		}

		// Builds the block by instantiating it and setting its parent
		private void BuildBlock(Transform toCreate, int xPos, int yPos, Transform parent) {
			//Create the object we want to create
			Transform newObject = Instantiate(toCreate, new Vector3(xPos, yPos, toCreate.position.z), Quaternion.identity);
			//Give the new object the same name as our tile prefab
			newObject.name = toCreate.name;
			// Set the object's parent to the layer parent variable so it doesn't clutter our Hierarchy
			newObject.parent = parent;
		}

		// Method that returns the parent GameObject for a layer
		private GameObject GetLayerParent(int layer) {
			if (_layerParents.ContainsKey(layer))
				return _layerParents[layer];
			GameObject layerParent = new GameObject("Layer " + layer);
			layerParent.transform.parent = _tileLevelParent.transform;
			_layerParents.Add(layer, layerParent);
			return _layerParents[layer];
		}
	}
}
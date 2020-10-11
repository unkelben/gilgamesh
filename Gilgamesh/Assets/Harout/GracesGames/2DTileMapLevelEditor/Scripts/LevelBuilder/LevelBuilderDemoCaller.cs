using UnityEngine;

namespace GracesGames._2DTileMapLevelEditor.Scripts.LevelBuilder {

	// Demo script demonstrating the usage of the LevelBuilder script
	// Contains a public String method which can be used to define the path to the level to load relative to the asset folder
	// Loads and builds the level found using the path on start using the LevelBuilder script
	public class LevelBuilderDemoCaller : MonoBehaviour {

		public string RelativePath = "/GracesGames/2DTileMapLevelEditor/DemoLevels/PlatformerIndexExample.lvl";

		private LevelBuilder _levelBuilder;

		void Start() {
			_levelBuilder = GetComponent<LevelBuilder>();
			_levelBuilder.LoadLevelUsingPath(Application.dataPath + RelativePath);
		}
	}
}
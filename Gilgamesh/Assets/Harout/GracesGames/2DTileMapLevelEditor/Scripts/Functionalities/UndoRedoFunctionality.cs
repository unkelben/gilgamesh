using UnityEngine;

using GracesGames.Common.Scripts;

namespace GracesGames._2DTileMapLevelEditor.Scripts.Functionalities {

	public class UndoRedoFunctionality : MonoBehaviour {

		// ----- PRIVATE VARIABLES -----

		// The level editor
		private LevelEditor _levelEditor;

		// Stacks to keep track for undo and redo feature
		private FiniteStack<int[,,]> _undoStack;

		private FiniteStack<int[,,]> _redoStack;

		// ----- SETUP -----

		public void Setup() {
			_levelEditor = LevelEditor.Instance;
			_undoStack = new FiniteStack<int[,,]>();
			_redoStack = new FiniteStack<int[,,]>();
			SetupClickListeners();
		}

		// Hook up Undo/Redo method to Undo/Redo button
		private void SetupClickListeners() {
			Utilities.FindButtonAndAddOnClickListener("UndoButton", Undo);
			Utilities.FindButtonAndAddOnClickListener("RedoButton", Redo);
		}

		// ----- UPDATE -----

		private void Update() {
			// If Z is pressed, undo action
			if (Input.GetKeyDown(KeyCode.Z)) {
				Undo();
			}
			// If Y is pressed, redo action
			if (Input.GetKeyDown(KeyCode.Y)) {
				Redo();
			}
		}

		// ----- PUBLIC METHODS -----

		// Reset undo and redo stacks
		public void Reset() {
			_undoStack = new FiniteStack<int[,,]>();
			_redoStack = new FiniteStack<int[,,]>();
		}

		// Push a level to the undo stack thereby saving it's state
		public void PushLevel(int[,,] level) {
			_undoStack.Push(level.Clone() as int[,,]);
		}

		// ----- PRIVATE METHODS -----

		// Load last saved level from undo stack and rebuild level
		private void Undo() {
			// See if there is anything on the undo stack
			if (_undoStack.Count > 0) {
				// If so, push it to the redo stack
				_redoStack.Push(_levelEditor.GetLevel());
			}
			// Get the last level entry
			int[,,] undoLevel = _undoStack.Pop();
			if (undoLevel != null) {
				// Set the level to the previous state
				_levelEditor.SetLevel(undoLevel);
			}
		}

		// Load last saved level from redo tack and rebuild level
		private void Redo() {
			// See if there is anything on the redo stack
			if (_redoStack.Count > 0) {
				// If so, push it to the redo stack
				_undoStack.Push(_levelEditor.GetLevel());
			}
			// Get the last level entry
			int[,,] redoLevel = _redoStack.Pop();
			if (redoLevel != null) {
				// Set level to the previous state
				_levelEditor.SetLevel(redoLevel);
			}
		}
	}
}
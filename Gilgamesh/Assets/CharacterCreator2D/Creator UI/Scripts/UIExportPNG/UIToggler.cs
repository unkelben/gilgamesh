using UnityEngine;
using UnityEngine.UI;

namespace CharacterCreator2D.UI
{
	public class UIToggler : MonoBehaviour {

		public Image icon;
		public bool active = true;
		public Sprite expandedIcon;
		public Sprite collapsedIcon;
		public GameObject[] objects;
		Button button;

		void Awake () 
		{
			button = GetComponent<Button>();
			button.onClick.AddListener(Toggle);
		}

		public void Toggle () {
			active = !active;
			foreach (GameObject go in objects) go.SetActive(active);
			if (icon == null) return; 
			if (active) icon.sprite = expandedIcon;
			else icon.sprite = collapsedIcon;
		}
	}
}
using UnityEngine;

namespace Game.Player {
	public class PlayerStartPosition : MonoBehaviour {
		[SerializeField] private float _marginBottomY = 0.2f;

		private void Start() {
			Camera camera = Camera.main;
			float height = GameManager.instance.levelManager.currentLevel.height; 
			transform.SetY(-height / 2.0f + _marginBottomY * height);
		}
	}
}
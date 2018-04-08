using UnityEngine;

namespace Game.Level {
	public class CameraSize : MonoBehaviour {
		private void Start() {
			Camera camera = Camera.main;
			float height = LevelManager.instance.currentLevel.height;
			camera.orthographicSize = height / 2.0f; 

		}
	}
}
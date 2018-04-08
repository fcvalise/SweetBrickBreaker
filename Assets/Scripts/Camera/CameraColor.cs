using UnityEngine;

namespace Game.Level {
	public class CameraColor : MonoBehaviour {
		void Start() {
			Camera.main.backgroundColor = LevelManager.instance.backgroundColor;
		}
	}
}

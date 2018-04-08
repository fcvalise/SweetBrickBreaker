using UnityEngine;

namespace Game.Level {
	public class Walls : MonoBehaviour {
		[SerializeField] private GameObject _wallRight;
		[SerializeField] private GameObject _wallLeft;
		[SerializeField] private GameObject _wallUp;
		[SerializeField] private GameObject _wallDown;

		private void Start() {
			Camera camera = Camera.main;
			float height = LevelManager.instance.currentLevel.height;
			float width = height * camera.aspect;

			_wallRight.transform.localScale = new Vector3(1.0f, height, 0.0f);
			_wallRight.transform.position = new Vector3(width / 2.0f + 0.5f, 0.0f, 0.0f);
			_wallLeft.transform.localScale = new Vector3(1.0f, height, 0.0f);
			_wallLeft.transform.position = new Vector3(-width / 2.0f - 0.5f, 0.0f, 0.0f);
			_wallUp.transform.localScale = new Vector3(width, 1.0f, 0.0f);
			_wallUp.transform.position = new Vector3(0.0f, height / 2.0f + 0.5f, 0.0f);
			_wallDown.transform.localScale = new Vector3(width, 1.0f, 0.0f);
			_wallDown.transform.position = new Vector3(0.0f, -height / 2.0f - 0.5f, 0.0f);
		}
	}
}
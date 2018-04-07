using UnityEngine;

namespace Game.Level {
	public class BrickInstantiator : MonoBehaviour {
		[SerializeField] GameObject _brick = null;
		private float _marginPercent = 0.2f;
		private float _spacePercent = 0.04f;

		private void Start() {
			Camera camera = Camera.main;
			float height = GameManager.instance.levelManager.currentLevel.height;
			float width = height * camera.aspect;
			float margin = width * _marginPercent;
			int rowCount = GameManager.instance.levelManager.currentLevel.brickRowCount;
			int colCount = GameManager.instance.levelManager.currentLevel.brickColCount;
			Vector2 scale = new Vector2((width - margin * 2.0f) / rowCount, (width - margin * 2.0f) / rowCount);
			Vector2 origin = new Vector2(-width / 2.0f + margin, height / 2.0f - margin);

			for (int i = 0; i < rowCount; i++) {
				for (int j = 0; j < colCount; j++) {
					float x = origin.x + i * scale.x + scale.x / 2.0f;
					float y = origin.y - j * scale.y + scale.y / 2.0f;
					Vector3 position = new Vector3(x, y, 0.0f);
					GameObject newBrick = Instantiate(_brick, position, Quaternion.identity);
					newBrick.transform.parent = transform.parent;
					newBrick.transform.localScale = scale * 0.8f;
				}
			}
		}
	}
}
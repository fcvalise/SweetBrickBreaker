using UnityEngine;

namespace Game.Level.Brick {
	public class BrickCreator : MonoBehaviour {
		private void Start() {
			BrickFactory factory = GetComponent<BrickFactory>();
			Camera camera = Camera.main;
			float height = LevelManager.instance.currentLevel.height;
			float width = height * camera.aspect;
			int rowCount = LevelManager.instance.currentLevel.brickRowCount;
			int colCount = LevelManager.instance.currentLevel.brickColCount;
			float deltaPos = width / (rowCount + 4);
			float margin = deltaPos * 2.0f;
			Vector2 origin = new Vector2(-width / 2.0f + margin, height / 2.0f - margin);

			for (int i = 0; i < rowCount; i++) {
				for (int j = 0; j < colCount; j++) {
					float x = origin.x + i * deltaPos + deltaPos / 2.0f;
					float y = origin.y - j * deltaPos - deltaPos / 2.0f;
					Vector3 position = new Vector3(x, y, 0.0f); 
					Vector2 scale = new Vector2(deltaPos * 0.8f, deltaPos * 0.8f);
					GameObject newBrick = factory.CreateRandomBrick(LevelManager.instance.currentLevel.allowedTypes, position, scale);
					newBrick.transform.parent = transform;
				}
			}
		}
	}
}
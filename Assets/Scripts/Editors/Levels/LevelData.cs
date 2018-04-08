using UnityEngine;
using Game.Level.Brick;

namespace Game.Editor {
	[System.Serializable]
	public class LevelData {
		public string levelName = "New Level";
		public float height = 0.0f;
		public int brickRowCount = 0;
		public int brickColCount = 0;
		public BrickFactory.BrickType[] allowedTypes = new BrickFactory.BrickType[0];
	}
}
using UnityEngine;
using System.Collections.Generic;

namespace Game.Level {
	public class BrickFactory : MonoBehaviour {
		public enum BrickType {
			Simple = 0,
			Life = 1,
			Static = 2,
			Count = 3
		}

		[SerializeField] private GameObject _brick;

		public GameObject CreateBrick(BrickType type, Vector2 position, Vector2 scale) {
			GameObject newBrick = Instantiate(_brick, position, Quaternion.identity);;
			newBrick.transform.localScale = scale;

			switch (type) {
				case BrickType.Simple:
					newBrick.AddComponent<SimpleBrick>();
				break;
				case BrickType.Life:
					newBrick.AddComponent<LifeBrick>();
				break;
				case BrickType.Static:
					newBrick.AddComponent<StaticBrick>();
				break;
			}
			return newBrick;
		}

		public GameObject CreateRandomBrick(Vector2 position, Vector2 scale) {
			BrickType type = (BrickType)Random.Range(0, (int)BrickType.Count);
			return CreateBrick(type, position, scale);
		}
	}
}
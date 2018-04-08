using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Game.Level.Brick {
	public class BrickFactory : MonoBehaviour {
		public enum BrickType {
			Simple = 0,
			Medium = 1,
			Static = 2,
			Count = 3
		}

		[SerializeField] private GameObject _brick;
		[Range(0.0f, 1.0f)][SerializeField] private float _mediumChance;
		[Range(0.0f, 1.0f)][SerializeField] private float _staticChance;

		public GameObject CreateBrick(BrickType type, Vector2 position, Vector2 scale) {
			GameObject newBrick = Instantiate(_brick, position, Quaternion.identity);;
			newBrick.transform.localScale = scale;

			switch (type) {
				case BrickType.Simple:
					newBrick.AddComponent<SimpleBrick>();
				break;
				case BrickType.Medium:
					newBrick.AddComponent<MediumBrick>();
				break;
				case BrickType.Static:
					newBrick.AddComponent<StaticBrick>();
				break;
			}
			return newBrick;
		}

		public GameObject CreateRandomBrick(BrickType[] types, Vector2 position, Vector2 scale) {
			if (IsTypeAllowed(types, BrickType.Static) && Random.value < _staticChance) {
				CreateBrick(BrickType.Static, position, scale);
			} else if (IsTypeAllowed(types, BrickType.Static) && Random.value < _mediumChance) {
				CreateBrick(BrickType.Medium, position, scale);
			}
			return CreateBrick(BrickType.Simple, position, scale);
		}

		private bool IsTypeAllowed(BrickType[] types, BrickType type) {
			foreach (BrickType compare in types) {
				if (compare == type) {
					return true;
				}
			}
			return false;
		}
	}
}
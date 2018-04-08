using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Game.Level.Brick {
	public class BrickFactory : MonoBehaviour {
		public enum BrickType {
			OneHp = 0,
			TwoHp = 1,
			Static = 2,
			Count = 3
		}

		[SerializeField] private GameObject _brick;
		[Range(0.0f, 1.0f)][SerializeField] private float _twoHpChance;
		[Range(0.0f, 1.0f)][SerializeField] private float _staticChance;

		public GameObject CreateBrick(BrickType type, Vector2 position, Vector2 scale) {
			GameObject newBrick = Instantiate(_brick, position, Quaternion.identity);;
			newBrick.transform.localScale = scale;

			switch (type) {
				case BrickType.OneHp:
					newBrick.AddComponent<OneHpBrick>();
				break;
				case BrickType.TwoHp:
					newBrick.AddComponent<TwoHPBrick>();
				break;
				case BrickType.Static:
					newBrick.AddComponent<StaticBrick>();
				break;
			}
			return newBrick;
		}

		public GameObject CreateRandomBrick(BrickType[] types, Vector2 position, Vector2 scale) {
			BrickType type = types[Random.Range(0, types.Length)];
			if (ArrayUtility.Contains(types, BrickType.Static) && Random.value < _staticChance) {
				CreateBrick(BrickType.Static, position, scale);
			} else if (ArrayUtility.Contains(types, BrickType.Static) && Random.value < _twoHpChance) {
				CreateBrick(BrickType.TwoHp, position, scale);
			}
			return CreateBrick(BrickType.OneHp, position, scale);
		}
	}
}
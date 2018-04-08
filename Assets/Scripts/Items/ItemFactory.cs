using UnityEngine;
using System.Collections.Generic;

namespace Game.Item {
	public class ItemFactory : MonoBehaviour {
		public enum ItemType {
			LifeBonus = 0,
			SizeBonus = 1,
			None
		}

		[SerializeField] private GameObject _item;

		public GameObject CreateItem(ItemType type, Vector2 position) {
			GameObject newItem = Instantiate(_item, position, Quaternion.identity);;

			switch (type) {
				case ItemType.LifeBonus:
					newItem.AddComponent<LifeBonus>();
				break;
				case ItemType.SizeBonus:
					newItem.AddComponent<SizeBonus>();
				break;
			}
			return newItem;
		}

		public GameObject CreateRandomItem(ItemType[] types, Vector2 position) {
			ItemType type = types[Random.Range(0, types.Length)];
			return CreateItem(type, position);
		}
	}
}
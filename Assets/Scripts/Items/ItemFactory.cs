using UnityEngine;
using System.Collections.Generic;

namespace Game.Item {
	public class ItemFactory : MonoBehaviour {
		public enum ItemType {
			LifeBonus = 0,
			SizeBonus = 1
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

		public GameObject CreateRandomItem(Vector2 position) {
			if (Random.value < 0.2f) {
				CreateItem(ItemType.LifeBonus, position);
			} else if (Random.value < 0.1f) {
				CreateItem(ItemType.SizeBonus, position);
			}
			return null; 
		}
	}
}
using UnityEngine;
using System.Collections.Generic;

namespace Game.Item {
	public class ItemFactory : MonoBehaviour {
		public enum ItemType {
			LifeBonus = 0,
			SizeBonus = 1
		}

		[SerializeField] private GameObject _item;
		[Range(0.0f, 1.0f)][SerializeField] private float _lifeBonusChance;
		[Range(0.0f, 1.0f)][SerializeField] private float _sizeBonusChance;

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
			if (Random.value < _lifeBonusChance) {
				CreateItem(ItemType.LifeBonus, position);
			} else if (Random.value < _sizeBonusChance) {
				CreateItem(ItemType.SizeBonus, position);
			}
			return null; 
		}
	}
}
using UnityEngine;
using System;
using Game.Level.Brick;
using Game.Item;

namespace Game.Level {
	[RequireComponent(typeof(ItemFactory))]
	public class BrickManager : MonoBehaviour {
		public delegate void DestroyEvent();
		public static event DestroyEvent OnDestroyed;

		private ItemFactory _itemFactory = null;
		private int _brickCount = 0;

		public void Start() {
			_itemFactory = GetComponent<ItemFactory>();
		}

		public void AddBrick(ABrick brick) {
			_brickCount++;
		}

		public void RemoveBrick(ABrick brick) {
			_brickCount--;
			_itemFactory.CreateItem(ItemFactory.ItemType.SizeBonus, brick.gameObject.transform.position);
			Destroy(brick.gameObject);
			if (OnDestroyed != null) {
				OnDestroyed();
			}
		}

		public int brickCount {
			get { return _brickCount; }
		}
	}
}
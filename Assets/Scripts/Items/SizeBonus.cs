using UnityEngine;
using Game.Player;

namespace Game.Item {
	public class SizeBonus : ADropableItem<PlayerSize> {
		private float _sizeBonus = 0.2f;
		private float _maxSize = 3.0f;

		public override void ApplyItem(PlayerSize playerSize) {
			float size = Mathf.Min(_maxSize, playerSize.currentSize + _sizeBonus);
			playerSize.UpdateSize(size);
		}
	}
}
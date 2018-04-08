using UnityEngine;
using Game.Player;

namespace Game.Item {
	public class SizeBonus : ADropableItem<PlayerSize> {
		private float _sizeBonus = 0.3f;
		private float _maxSize = 4.0f;

		private void Start() {
			GetComponent<MeshRenderer>().material.color = LevelManager.instance.playerColor;
		}

		public override void ApplyItem(PlayerSize playerSize) {
			float size = Mathf.Min(_maxSize, playerSize.currentSize + _sizeBonus);
			playerSize.UpdateSize(size);
		}
	}
}
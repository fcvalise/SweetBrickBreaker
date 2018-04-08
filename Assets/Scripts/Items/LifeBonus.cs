using UnityEngine;
using Game.Player;

namespace Game.Item {
	public class LifeBonus : ADropableItem<PlayerItem> {
		private void Start() {
			GetComponent<MeshRenderer>().material.color = LevelManager.instance.ballColor;
		}

		public override void ApplyItem(PlayerItem player) {
			LevelManager.instance.lifeManager.AddLife();
		}
	}
}
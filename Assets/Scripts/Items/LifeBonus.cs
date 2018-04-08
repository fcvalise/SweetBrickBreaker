using UnityEngine;
using Game.Player;

namespace Game.Item {
	public class LifeBonus : ADropableItem<PlayerItem> {
		public override void ApplyItem(PlayerItem player) {
			LevelManager.instance.lifeManager.AddLife();
		}
	}
}
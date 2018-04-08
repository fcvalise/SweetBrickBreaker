using UnityEngine;
using Game.Player;

namespace Game.Effect {
	public class LifeBonus : ACollidableEffect<PlayerEffect> {
		public override void ApplyEffect(PlayerEffect player) {
			LevelManager.instance.lifeManager.AddLife();
		}
	}
}
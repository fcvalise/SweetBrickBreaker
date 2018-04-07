using UnityEngine;

namespace Game.Level {
	public class SimpleBrick : ABrick {
		protected override void OnCollision() {
			Destroy(gameObject);
		}
	}
}
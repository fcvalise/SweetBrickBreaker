using UnityEngine;

namespace Game.Level.Brick {
	public class SimpleBrick : ABrick {
		protected override void OnCollision() {
			Destroy(gameObject);
		}

		protected override bool isDestructable {
			get { return true; }
		}
	}
}
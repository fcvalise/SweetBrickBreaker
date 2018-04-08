using UnityEngine;

namespace Game.Level.Brick {
	public class StaticBrick : ABrick {
		protected override void OnCollision() {}

		protected override bool isDestructable {
			get { return false; }
		}

		protected override Color color {
			get { return Color.black; }
		}
	}
}
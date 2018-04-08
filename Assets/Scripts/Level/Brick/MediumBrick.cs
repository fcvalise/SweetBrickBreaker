using UnityEngine;

namespace Game.Level.Brick {
	public class MediumBrick : AHpBrick {
		protected override int maxHp {
			get { return 2; }
		}

		protected override Color color {
			get { return new Color(0.5f, 0.5f, 0.5f, 1.0f); }
		}
	}
}
using UnityEngine;

namespace Game.Level.Brick {
	public class OneHpBrick : AHpBrick {
		protected override int maxHp {
			get { return 1; }
		}

		protected override Color color {
			get { return Color.white; }
		}
	}
}
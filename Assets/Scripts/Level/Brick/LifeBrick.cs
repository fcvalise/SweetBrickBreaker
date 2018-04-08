using UnityEngine;

namespace Game.Level.Brick {
	public class LifeBrick : ABrick {
		[SerializeField] private int _life = 2;

		protected override void OnCollision() {
			_life--;
			if (_life <= 0) {
				Destroy(gameObject);
			}
		}

		protected override bool isDestructable {
			get { return true; }
		}
	}
}
using UnityEngine;

namespace Game.Level {
	public class LifeBrick : ABrick {
		[SerializeField] private int _life = 2;

		protected override void OnCollision() {
			_life--;
			if (_life <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
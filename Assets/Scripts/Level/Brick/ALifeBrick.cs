using UnityEngine;
using System;

namespace Game.Level.Brick {
	public abstract class AHpBrick : ABrick {
		protected abstract int maxHp { get; }
		private int _hp = 0;

		private void Awake() {
			_hp = maxHp;
		}

		protected override void OnCollision() {
			_hp--;
			SetColor(Color.Lerp(Color.white, color, (float)_hp / (float)maxHp));
			if (_hp <= 0) {
				Destroy(gameObject);
			}
		}

		protected override bool isDestructable {
			get { return true; }
		}
	}
}
using UnityEngine;
using System;

namespace Game.Level.Brick {
	public abstract class AHpBrick : ABrick {
		protected abstract int maxHp { get; }
		private int _hp = 0;

		private void Awake() {
			_hp = maxHp;
			LevelManager.instance.brickManager.AddBrick(this);
		}

		protected override void OnCollision() {
			_hp--;
			SetColor(Color.Lerp(Color.white, color, (float)_hp / (float)maxHp));
			if (_hp <= 0) {
				LevelManager.instance.brickManager.RemoveBrick(this);
			}
		}
	}
}
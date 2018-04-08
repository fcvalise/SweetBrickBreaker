using UnityEngine;
using System;

namespace Game.Level.Brick {
	public abstract class ABrick : MonoBehaviour {
		protected abstract void OnCollision();
		protected abstract bool isDestructable { get; }

		private void Start() {
			if (isDestructable) {
				LevelManager.instance.brickManager.AddBrick();
			}
		}

		private void OnDestroy() {
			if (isDestructable) {
				LevelManager.instance.brickManager.RemoveBrick();
			}
		}

		private void OnCollisionEnter2D(Collision2D other) {
			OnCollision();
		}
	}
}
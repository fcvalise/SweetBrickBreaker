using UnityEngine;

namespace Game.Level {
	public abstract class ABrick : MonoBehaviour {
		protected abstract void OnCollision();

		private void OnCollisionEnter2D(Collision2D other) {
			OnCollision();
		}
	}
}
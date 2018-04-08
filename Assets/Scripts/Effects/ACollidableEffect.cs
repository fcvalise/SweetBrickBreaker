using UnityEngine;

namespace Game.Effect {
	public abstract class ACollidableEffect<T> : MonoBehaviour, IEffect<T> {
		public abstract void ApplyEffect(T t);

		private void OnTriggerEnter2D(Collider2D other) {
			T effect = other.gameObject.GetComponent<T>();
			if (effect != null) {
				ApplyEffect(effect);
				Destroy(gameObject);
			}
		}
	}
}
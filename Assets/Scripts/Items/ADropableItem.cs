using UnityEngine;

namespace Game.Item {
	public abstract class ADropableItem<T> : MonoBehaviour, IItem<T> {
		public abstract void ApplyItem(T t);

		private void OnTriggerEnter2D(Collider2D other) {
			T item = default(T);

			if (other.attachedRigidbody) {
				item = other.attachedRigidbody.GetComponent<T>();
			} else {
				item = other.gameObject.GetComponent<T>();
			}
			if (item != null) {
				ApplyItem(item);
				Destroy(gameObject);
			}
		}
	}
}
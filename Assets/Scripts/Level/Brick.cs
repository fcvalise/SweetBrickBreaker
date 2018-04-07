using UnityEngine;

namespace Game.Level {
	public class Brick : MonoBehaviour {
		private void OnCollisionEnter2D(Collision2D other) {
			Destroy(gameObject);
		}
	}
}
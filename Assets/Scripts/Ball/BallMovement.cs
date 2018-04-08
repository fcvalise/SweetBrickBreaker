using UnityEngine;

namespace Game.Ball {
	public class BallMovement : MonoBehaviour {
		[SerializeField] private float _speed = 10.0f;
		private Rigidbody2D _rigidbody = null;

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Fire() {
			transform.parent = null;
			_rigidbody.AddForce(new Vector2(_speed, _speed));
		}

		public void Stop() {
			_rigidbody.velocity = Vector2.zero;
		}

		private void FixedUpdate() {
			_rigidbody.velocity = _speed * (_rigidbody.velocity.normalized);
		}
	}
}
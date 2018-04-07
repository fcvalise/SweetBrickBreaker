using UnityEngine;

namespace Game.Ball {
	public class BallMovement : MonoBehaviour {
		// TODO : Access speed from scriptable object
		private float _speed = 100.0f;
		private bool _isAttached = true;
		private Rigidbody2D _rigidbody = null;

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update() {
			if (_isAttached && GameManager.instance.controller.fire) {
				transform.parent = null;
				_rigidbody.AddForce(new Vector2(_speed, _speed));
				_isAttached = false;
			}
		}
	}
}
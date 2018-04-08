using UnityEngine;
using Game.Player.Controller;

namespace Game.Player {
	public class PlayerMovement : MonoBehaviour {
		[SerializeField] float _speed = 1.0f;
		private IController _controller = null;
		private Rigidbody2D _rigidbody = null;

		private void Start() {
			_controller = GetComponent<IController>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate() {
			float velocityX = _speed * (_controller.position.x - transform.position.x);
			_rigidbody.velocity = new Vector2(velocityX, 0.0f);
		}
	}
}
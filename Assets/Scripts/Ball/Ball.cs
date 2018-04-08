using UnityEngine;
using Game.Player.Controller;

namespace Game.Ball {
	public class Ball : MonoBehaviour {
		[SerializeField] GameObject _player = null;
		private IController _controller = null;
		private BallMovement _ballMovement = null;
		private Vector2 _originLocalPos;
		private bool _isAttached = true;

		private void Awake() {
			_ballMovement = GetComponent<BallMovement>();
			_controller = _player.GetComponent<IController>();
			_originLocalPos = transform.localPosition;
		}

		private void Update() {
			if (_isAttached && _controller.fire) {
				_isAttached = false;
				_ballMovement.Fire();
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			_isAttached = true;
			transform.parent = _player.transform;
			transform.localPosition = _originLocalPos;
			_ballMovement.Stop();
			LevelManager.instance.lifeManager.RemoveLife();
		}

		public BallMovement movement {
			get { return _ballMovement; }
		}
	}
}
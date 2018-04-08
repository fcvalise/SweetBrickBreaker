using UnityEngine;

namespace Game.Player.Controller {
	public class TouchController : MonoBehaviour, IController {
		private Camera _camera;
		private Vector2 _position;

		private void Start() {
			_camera = Camera.main;
		}

		public Vector2 position {
			get {
				if (Input.touchCount > 0) {
					Vector2 pos = Input.GetTouch(0).position;
					_position = _camera.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0.0f));
				}
				return _position;
			}
		}

		public bool fire {
			get { return Input.touchCount > 0; }
		}
	}
}
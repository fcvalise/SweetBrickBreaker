using UnityEngine;
using Game.Player.Controller;

namespace Game.Player {
	public class PlayerMovement : MonoBehaviour {
		private IController _controller = null;

		private void Start() {
			_controller = GetComponent<IController>();
		}

		private void Update() {
			transform.SetX(_controller.position.x);
		}
	}
}
using UnityEngine;

namespace Game.Player {
	public class PlayerMovement : MonoBehaviour {
		private void Update() {
			transform.SetX(GameManager.instance.controller.position.x);
		}
	}
}
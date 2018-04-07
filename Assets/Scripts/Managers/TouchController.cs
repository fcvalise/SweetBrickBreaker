using UnityEngine;

namespace Game.Managers {
	public class TouchController : MonoBehaviour, IController {
		public Vector2 position {
			get { return Input.GetTouch(0).position; }
		}
	}
}
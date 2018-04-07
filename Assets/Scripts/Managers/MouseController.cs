using UnityEngine;

namespace Game.Managers {
	public class MouseController : MonoBehaviour, IController {
		public Vector2 position {
			get { return Input.mousePosition; }
		}
	}
}
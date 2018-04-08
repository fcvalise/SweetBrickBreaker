using UnityEngine;

namespace Game.Player.Controller {
	public class MouseController : MonoBehaviour, IController {
		public Vector2 position {
			get { 
				Camera camera = Camera.main;
				Vector2 pos = Input.mousePosition;
				return camera.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0.0f));
			}
		}

		public bool fire {
			get { return Input.GetMouseButton(0); }
		}
	}
}
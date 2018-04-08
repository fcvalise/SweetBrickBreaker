using UnityEngine;

namespace Game.Player.Controller {
	public interface IController {
		Vector2 position { get; }
		bool fire { get; }
	}
}
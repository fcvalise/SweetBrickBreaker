using UnityEngine;

namespace Game.Managers {
	public interface IController {
		Vector2 position { get; }
		bool fire { get; }
	}
}
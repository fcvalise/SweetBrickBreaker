using UnityEngine;

namespace Game.Managers {
	[RequireComponent(typeof(IController))]
	public class GameManager : MonoBehaviour {
		private static GameManager _instance = null;
		private static IController _controller = null;

		private void Awake() {
			if (_instance == null) {
				_instance = this;
			} else if (_instance != this) {
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
			InitGame();
		}

		private void InitGame() {
			_controller = gameObject.GetComponent<IController>();
		}

		public static GameManager instance {
			get { return _instance; }
		}

		public static IController controller {
			get { return _controller; }
		}
	}
}
using UnityEngine;

namespace Game.Managers {
	[RequireComponent(typeof(MouseController))]
	[RequireComponent(typeof(SceneLoader))]
	[RequireComponent(typeof(LevelManager))]
	public class GameManager : MonoBehaviour {
		private static GameManager _instance = null;
		private IController _controller = null;
		private LevelManager _levelManager = null;

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
			_levelManager = gameObject.GetComponent<LevelManager>();
		}

		public static GameManager instance {
			get { return _instance; }
		}

		public IController controller {
			get { return _controller; }
		}

		public LevelManager levelManager {
			get { return _levelManager; }
		}
	}
}
using UnityEngine;

namespace Game {
	public class Progress : MonoBehaviour {
		private static Progress _instance = null;
		private int _levelIndex;

		private void Awake() {
			if (_instance == null) {
				_instance = this;
			} else if (_instance != this) {
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}

		public static Progress instance {
			get { return _instance; }
		}

		public int levelIndex {
			get { return _levelIndex; }
			set { _levelIndex = value; }
		}
	}
}
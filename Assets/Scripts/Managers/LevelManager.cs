using UnityEngine;
using System;
using Game.Editor;

namespace Game.Managers {
	public class LevelManager : MonoBehaviour {
		[SerializeField] private LevelList _levelList = null;

		public delegate void LevelEvent();
		public static event LevelEvent OnLevelChange;
		public static event LevelEvent OnFinish;

		private int _index = 0;

		public void NextLevel() {
			_index++;
			if (OnLevelChange != null) {
				OnLevelChange();
			}
			if (_index >= _levelList.levels.Count) {
				_index = _levelList.levels.Count - 1;
				if (OnFinish != null) {
					OnFinish();
				}
			}
		}

		public LevelData currentLevel {
			get { return _levelList.levels[_index]; }
		}
	}
}
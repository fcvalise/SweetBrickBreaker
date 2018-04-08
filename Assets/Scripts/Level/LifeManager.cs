using UnityEngine;
using System;

namespace Game.Level {
	public class LifeManager : MonoBehaviour {
		public delegate void FailedEvent();
		public static event FailedEvent OnFailed;
		[SerializeField] private int _lifeCount = 5;

		public int lifeCount {
			get { return _lifeCount; }
		}

		public void AddLife() {
				_lifeCount++;
		}

		public void RemoveLife() {
			_lifeCount--;
			if (OnFailed != null) {
				OnFailed();
			}
		}
	}
}
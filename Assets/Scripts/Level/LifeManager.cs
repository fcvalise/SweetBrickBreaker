using UnityEngine;
using System;

namespace Game.Level {
	public class LifeManager : MonoBehaviour {
		public delegate void LifeEvent();
		public static event LifeEvent OnFailed;
		public static event LifeEvent OnBonus;
		[SerializeField] private int _lifeCount = 5;

		public int lifeCount {
			get { return _lifeCount; }
		}

		public void AddLife() {
			_lifeCount++;
			if (OnBonus != null) {
				OnBonus();
			}
		}

		public void RemoveLife() {
			_lifeCount--;
			if (OnFailed != null) {
				OnFailed();
			}
		}
	}
}
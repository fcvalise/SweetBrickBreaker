using UnityEngine;
using System;

namespace Game.Level {
	public class BrickManager : MonoBehaviour {
		public delegate void DestroyEvent();
		public static event DestroyEvent OnDestroyed;

		private int _brickCount;

		public int brickCount {
			get { return _brickCount; }
		}

		public void AddBrick() {
			_brickCount++;
		}

		public void RemoveBrick() {
			_brickCount--;
			if (OnDestroyed != null) {
				OnDestroyed();
			}
		}
	}
}
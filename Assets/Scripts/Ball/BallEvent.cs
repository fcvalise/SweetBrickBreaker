using UnityEngine;

namespace Game.Ball {
	public class BallEvent : MonoBehaviour {
		public delegate void BounceEvent();
		public static event BounceEvent OnBounced;

		private void OnCollisionEnter2D(Collision2D other) {
			if (OnBounced != null) {
				OnBounced();
			}
		}
	}
}
using UnityEngine;
using Game.Level;
using Game.Ball;

namespace Game {
	[RequireComponent(typeof(AudioSource))]
	public class Sounds : MonoBehaviour {
		[SerializeField] private AudioClip _bounced = null;
		[SerializeField] private AudioClip _failed = null;
		[SerializeField] private AudioClip _destroyed = null;
		[SerializeField] private AudioClip _bonus = null;

		private AudioSource _source = null;

		private void Start() {
			_source = GetComponent<AudioSource>();
			BrickManager.OnDestroyed += PlayDestroyed;
			LifeManager.OnFailed += PlayFailed;
			LifeManager.OnBonus += PlayBonus;
			BallEvent.OnBounced += PlayBounced;
		}

		private void OnDisable() {
			BrickManager.OnDestroyed -= PlayDestroyed;
			LifeManager.OnFailed -= PlayFailed;
			LifeManager.OnBonus -= PlayBonus;
			BallEvent.OnBounced -= PlayBounced;
		}

		private void PlayBounced() {
			_source.PlayOneShot(_bounced, 0.5f);
		}

		private void PlayFailed() {
			_source.PlayOneShot(_failed);
		}

		private void PlayDestroyed() {
			_source.PlayOneShot(_destroyed, 0.5f);
		}

		private void PlayBonus() {
			_source.PlayOneShot(_bonus, 0.7f);
		}
	}
}
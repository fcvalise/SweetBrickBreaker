using UnityEngine;
using Game.Level;
using Game.Ball;

namespace Game {
	[RequireComponent(typeof(AudioSource))]
	public class Sounds : MonoBehaviour {
		[SerializeField] private AudioClip _bounced = null;
		[SerializeField] private AudioClip _failed = null;
		[SerializeField] private AudioClip _destroyed = null;

		private AudioSource _source = null;

		private void Start() {
			_source = GetComponent<AudioSource>();
			BrickManager.OnDestroyed += PlayDestroyed;
			LifeManager.OnFailed += PlayFailed;
			BallEvent.OnBounced += PlayBounced;
		}

		private void OnDisable() {
			BrickManager.OnDestroyed -= PlayDestroyed;
			LifeManager.OnFailed -= PlayFailed;
			BallEvent.OnBounced -= PlayBounced;
		}

		private void PlayBounced() {
			_source.PlayOneShot(_bounced, 0.7f);
		}

		private void PlayFailed() {
			_source.PlayOneShot(_failed);
		}

		private void PlayDestroyed() {
			_source.PlayOneShot(_destroyed, 0.7f);
		}
	}
}
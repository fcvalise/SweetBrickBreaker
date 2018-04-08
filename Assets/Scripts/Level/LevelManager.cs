using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Game.Editor;
using Game.Level;
using Game.Level.Brick;

namespace Game {
	[RequireComponent(typeof(BrickManager))]
	[RequireComponent(typeof(LifeManager))]
	public class LevelManager : MonoBehaviour {
		[SerializeField] private LevelList _levelList = null;
		[SerializeField] private Color _playerColor;
		[SerializeField] private Color _ballColor;
		[SerializeField] private Color _backgroundColor;
		[SerializeField] private Material _playerMaterial;
		[SerializeField] private Material _ballMaterial;

		private static LevelManager _instance;
		private BrickManager _brickManager = null;
		private LifeManager _lifeManager = null;

		private void Awake() {
			if (_instance == null) {
				_instance = this;
			} else if (_instance != this) {
				Destroy(gameObject);
			}
			InitLevel();
		}

		private void InitLevel() {
			_brickManager = GetComponent<BrickManager>();
			_lifeManager = GetComponent<LifeManager>();
			BrickManager.OnDestroyed += CheckBrickCount;
			LifeManager.OnFailed += CheckLife;

			_playerColor = UnityEngine.Random.ColorHSV(0.0f, 0.3f, 0.4f, 0.6f, 1.0f, 1.0f);
			_ballColor = UnityEngine.Random.ColorHSV(0.3f, 0.6f, 0.3f, 0.6f, 1.0f, 1.0f);
			_backgroundColor = UnityEngine.Random.ColorHSV(0.6f, 1.0f, 0.1f, 0.2f, 1.0f, 1.0f);

			_playerMaterial.color = _playerColor;
			_ballMaterial.color = _ballColor;
		}

		public void NextLevel() {
			Progress.instance.levelIndex++;
			if (Progress.instance.levelIndex >= _levelList.levels.Count) {
				Progress.instance.levelIndex = _levelList.levels.Count - 1;
				SceneManager.LoadScene("Win");
			}
			SceneManager.LoadScene("NextLevel");
		}

		public void PreviousLevel() {
			Progress.instance.levelIndex--;
			if (Progress.instance.levelIndex <= 0) {
				Progress.instance.levelIndex = 0;
			}
			SceneManager.LoadScene("PreviousLevel");
		}

		private void CheckBrickCount() {
			if (_brickManager.brickCount <= 0) {
				NextLevel();
			}
		}

		private void CheckLife() {
			if (_lifeManager.lifeCount <= 0) {
				PreviousLevel();
			}
		}

		private void OnDisable() {
			BrickManager.OnDestroyed -= CheckBrickCount;
			LifeManager.OnFailed -= CheckLife;
		}

		public static LevelManager instance {
			get { return _instance; }
		}

		public LevelData currentLevel {
			get { return _levelList.levels[Progress.instance.levelIndex]; }
		}

		public BrickManager brickManager {
			get { return _brickManager; }
		}

		public LifeManager lifeManager {
			get { return _lifeManager; }
		}

		public Color playerColor {
			get { return _playerColor; }
		}

		public Color ballColor {
			get { return _ballColor; }
		}

		public Color backgroundColor {
			get { return _backgroundColor; }
		}
	}
}
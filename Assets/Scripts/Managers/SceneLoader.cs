using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Game.Managers {
	public class SceneLoader : MonoBehaviour {
		private void OnEnable() {
			LevelManager.OnLevelChange += LoadGameScene;
			LevelManager.OnFinish += LoadMenuScene;
		}

		private void OnDisable() {
			LevelManager.OnLevelChange -= LoadGameScene;
			LevelManager.OnFinish -= LoadMenuScene;
		}

		private void LoadGameScene() {
			SceneManager.LoadScene("Game");
		}

		private void LoadMenuScene() {
			SceneManager.LoadScene("Menu");
		}
	}
}
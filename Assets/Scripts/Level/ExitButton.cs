using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Level {
	public class ExitButton : MonoBehaviour {
		private void Update() {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene("Menu");
			}
		}
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToPlay : MonoBehaviour {
	private void Update () {
		if (Input.GetMouseButton(0)) {
			SceneManager.LoadScene("Game");
		}
	}
}

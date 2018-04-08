using UnityEngine;
using UnityEngine.UI;
using Game.Level;
using Game.Ball;

namespace Game {
	[RequireComponent(typeof(Text))]
	public class SimpleUI : MonoBehaviour {
		private Text _text;
		private float _originY;

		private void Start() {
			_text = GetComponent<Text>();
			_text.text = LevelManager.instance.currentLevel.levelName;
			_originY = _text.rectTransform.position.y;
			LifeManager.OnFailed += DisplayLife;
			LifeManager.OnBonus += DisplayLife;
		}

		private void OnDisable() {
			LifeManager.OnFailed -= DisplayLife;
			LifeManager.OnBonus -= DisplayLife;
		}

		private void Update() {
			_text.rectTransform.SetY(_text.rectTransform.position.y - Time.deltaTime * 100.0f);
		}

		private void DisplayLife() {
			_text.text = LevelManager.instance.lifeManager.lifeCount.ToString();
			_text.color = LevelManager.instance.ballColor; 
			_text.rectTransform.SetY(_originY);
		}
	}
}
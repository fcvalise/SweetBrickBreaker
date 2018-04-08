using UnityEngine;

namespace Game.Player {
	public class PlayerSize : MonoBehaviour {
		[SerializeField] private float _initialSize = 1.0f;
		[SerializeField] private GameObject _shoulderLeft;
		[SerializeField] private GameObject _shoulderRight;
		[SerializeField] private GameObject _body;

		private float _currentSize = 0.0f;

		private void Start() {
			UpdateSize(_initialSize);
		}

		public void UpdateSize(float size) {
			_shoulderLeft.transform.SetLocalX(-size / 2.0f);
			_shoulderRight.transform.SetLocalX(size / 2.0f);
			_body.transform.SetScaleX(size);
			_currentSize = size;
		}

		public float currentSize {
			get { return _currentSize; }
			set { _currentSize = value; }
		}
	}
}
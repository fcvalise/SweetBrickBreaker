using UnityEngine;

namespace Game.Level {
	public class CameraShake : MonoBehaviour {
		[SerializeField] float _speed = 20.0f;
		private Vector2 _velocity;
		private Vector2 _position;
		private Vector2 _target;
		private float _drag = 0.1f;
		private float _elasticity = 0.1f;

		private void Start() {
			_target = transform.position;
			BrickManager.OnDestroyed += ShakeDestroy; 
			LifeManager.OnFailed += ShakeFailed; 
		}

		private void OnDisable() {
			BrickManager.OnDestroyed -= ShakeDestroy;
			LifeManager.OnFailed -= ShakeFailed;
		}

		public void ShakeDestroy() {
			ShakeRandom(0.1f);
		}

		public void ShakeFailed() {
			ShakeRandom(0.2f);
		}

		public void Shake(float powerX, float powerY) {
			_velocity.x += powerX;
			_velocity.y += powerY;
		}

		public void ShakeRandom(float power) {
			_velocity = Polar(power, Random.value * Mathf.PI * 2);
		}

		public void Update() {
			float delta = Time.deltaTime * _speed;

			_velocity.x -= _velocity.x * _drag * delta;
			_velocity.y -= _velocity.y * _drag * delta;

			_velocity.x -= (_position.x) * _elasticity * delta;
			_velocity.y -= (_position.y) * _elasticity * delta;

			_position.x += (_velocity.x) * delta;
			_position.y += (_velocity.y) * delta;

			transform.position = new Vector3(_position.x, _position.y, transform.position.z);
		}

		private Vector2 Polar(float len, float ang) {
			return new Vector2(len * Mathf.Sin(ang), len * Mathf.Cos(ang));
		}
	}
}
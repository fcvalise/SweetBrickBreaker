/*
// https://assetstore.unity.com/packages/tools/physics/simple-ik-14938
*/
using UnityEngine;
using System.Collections;

namespace Game.Utils {
	public class InverseKinematic : MonoBehaviour {
		[SerializeField] private Transform _target;
		[SerializeField] private GameObject _bone1;
		[SerializeField] private GameObject _bone2;
		[SerializeField] private float _d1;
		[SerializeField] private float _d2;
		[SerializeField] private bool _inverted;
		private float _theta1 = 0;
		private float _theta2 = 0;
		private bool _outOfRange;

		public InverseKinematic(Transform target, GameObject bone1, GameObject bone2, float d1, float d2, bool isInverted) {
			_target = target;
			_bone1 = bone1;
			_bone2 = bone2;
			_d1 = d1;
			_d2 = d2;
			_inverted = isInverted;
			UpdateBones();
		}

		public void UpdateInfos(float d1, float d2, bool inverted) {
			_d1 = d1;
			_d2 = d2;
			_inverted = inverted;
			UpdateBones();
		}

		private void UpdateBones() {
			float rot1 = _bone1.transform.localEulerAngles.z;
			_bone1.transform.localPosition = Vector2.zero;
			_bone1.transform.localEulerAngles = new Vector3(0, 0, rot1);

			float rot2 = _bone2.transform.localEulerAngles.z;
			_bone2.transform.parent = _bone1.transform;
			_bone2.transform.localPosition = new Vector2(_d1, 0.0f);
			_bone2.transform.localEulerAngles = new Vector3(0, 0, rot2);
		}

		public void Update() {
			float dx = _target.position.x - _bone1.transform.position.x;
			float x = dx > 0 ? Mathf.Abs(dx) : -Mathf.Abs(dx);
			float dy = _target.position.y - _bone1.transform.position.y;
			float y = dy > 0 ? Mathf.Abs(dy) : -Mathf.Abs(dy);

			float num = Mathf.Pow(x, 2) + Mathf.Pow(y, 2) - Mathf.Pow(_d1, 2) - Mathf.Pow(_d2, 2);
			float denom = 2 * _d1 * _d2;

			_outOfRange = (Mathf.Abs(num / denom) > 1);

			float cos_theta2 = Mathf.Clamp(num / denom, -1, 1);

			_theta2 = Mathf.Acos(cos_theta2);

			if (_inverted)
				_theta2 = -_theta2;

			float atx = y * (_d1 + _d2 * Mathf.Cos(_theta2)) - x * (_d2 * Mathf.Sin(_theta2));
			float aty = x * (_d1 + _d2 * Mathf.Cos(_theta2)) + y * (_d2 * Mathf.Sin(_theta2));

			_theta1 = y == 0 && x == 0 ? 0 : Mathf.Atan2(atx, aty);
			_bone1.transform.localEulerAngles = new Vector3(0, 0, (Mathf.Rad2Deg * _theta1));
			_bone2.transform.localEulerAngles = new Vector3(0, 0, (Mathf.Rad2Deg * _theta2));
		}

		public Transform target {
			get { return _target; }
		}

		public GameObject bone1 {
			get { return _bone1; }
		}

		public GameObject bone2 {
			get { return _bone2; }
		}

		public bool outOfRange {
			get { return _outOfRange; }
		}
	}
}
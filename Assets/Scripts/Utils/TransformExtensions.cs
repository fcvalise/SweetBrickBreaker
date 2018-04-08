using UnityEngine;
using System.Collections;

public static class TransformExtensions {
	public static void SetX(this Transform transform, float x) {
		Vector3 position = transform.position;
		transform.position = new Vector3(x, position.y, position.z);
	}

	public static void SetY(this Transform transform, float y) {
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x, y, position.z);
	}

	public static void SetLocalX(this Transform transform, float x) {
		Vector3 position = transform.localPosition;
		transform.localPosition = new Vector3(x, position.y, position.z);
	}

	public static void SetLocalY(this Transform transform, float y) {
		Vector3 position = transform.localPosition;
		transform.localPosition = new Vector3(position.x, y, position.z);
	}

	public static void SetScaleX(this Transform transform, float x) {
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(x, scale.y, scale.z);
	}
}
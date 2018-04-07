using UnityEngine;
using System.Collections;

public static class ExtensionMethods {
	public static void SetX(this Transform transform, float x) {
		Vector3 position = transform.position;
		transform.position = new Vector3(x, position.y, position.z);
	}

	public static void SetY(this Transform transform, float y) {
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x, y, position.z);
	}
}
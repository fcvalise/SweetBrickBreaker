using UnityEngine;
using System.Collections;

public static class ColorExtensions {
	public static void SetAlpha(this Color color, float alpha) {
		Color tmp = color;
		tmp.a = alpha;
		color = tmp;
	}
}
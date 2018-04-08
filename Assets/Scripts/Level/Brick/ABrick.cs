using UnityEngine;
using System;
using Game.Item;

namespace Game.Level.Brick {
	public abstract class ABrick : MonoBehaviour {
		protected abstract void OnCollision();
		protected abstract Color color { get; }

		private Material _material = null;

		private void Start() {
			_material = GetComponent<MeshRenderer>().material;
			SetColor(color);
		}

		private void OnCollisionEnter2D(Collision2D other) {
			OnCollision();
		}

		protected void SetColor(Color newColor) {
			_material.color = newColor;
		}
	}
}
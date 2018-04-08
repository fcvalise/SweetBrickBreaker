using UnityEngine;
using System;

namespace Game.Level.Brick {
	public abstract class ABrick : MonoBehaviour {
		protected abstract void OnCollision();
		protected abstract bool isDestructable { get; }
		protected abstract Color color { get; }

		private Material _material = null;
		private int _life = 0;

		private void Start() {
			if (isDestructable) {
				LevelManager.instance.brickManager.AddBrick();
			}
			_material = GetComponent<MeshRenderer>().material;
			SetColor(color);
		}


		private void OnDestroy() {
			if (isDestructable) {
				LevelManager.instance.brickManager.RemoveBrick();
			}
		}

		private void OnCollisionEnter2D(Collision2D other) {
			OnCollision();
		}

		protected void SetColor(Color newColor) {
			_material.color = newColor;
		}
	}
}
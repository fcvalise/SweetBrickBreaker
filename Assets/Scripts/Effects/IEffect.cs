using UnityEngine;

namespace Game.Effect {
	public interface IEffect<T> {
		void ApplyEffect(T t);
	}
}
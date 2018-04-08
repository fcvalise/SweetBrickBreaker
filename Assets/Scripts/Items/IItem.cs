using UnityEngine;

namespace Game.Item {
	public interface IItem<T> {
		void ApplyItem(T t);
	}
}
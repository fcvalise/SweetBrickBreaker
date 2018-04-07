using UnityEngine;
using UnityEditor;

namespace Game.Editor {
	public class CreateLevelList {
		[MenuItem("Assets/Create/Level List")]
		public static LevelList Create() {
			LevelList asset = ScriptableObject.CreateInstance<LevelList>();

			AssetDatabase.CreateAsset(asset, "Assets/LevelList.asset");
			AssetDatabase.SaveAssets();
			return asset;
		}
	}
}
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
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
#endif
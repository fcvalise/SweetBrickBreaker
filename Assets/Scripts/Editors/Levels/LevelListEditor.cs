using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
namespace Game.Editor {
	public class LevelListEditor : EditorWindow {

		public LevelList _levelList;
		private int _viewIndex = 1;

		[MenuItem("Window/Level Editor %#e")]
		static void Init() {
			EditorWindow.GetWindow(typeof(LevelListEditor));
		}

		void OnEnable() {
			if (EditorPrefs.HasKey("ObjectPath")) {
				string objectPath = EditorPrefs.GetString("ObjectPath");
				_levelList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(LevelList)) as LevelList;
			}

		}

		void OnGUI() {
			GUILayout.BeginHorizontal();
			GUILayout.Label("Level Editor", EditorStyles.boldLabel);
			if (_levelList != null) {
				if (GUILayout.Button("Show Level List")) {
					EditorUtility.FocusProjectWindow();
					Selection.activeObject = _levelList;
				}
			}
			if (GUILayout.Button("Open Level List")) {
				OpenLevelList();
			}
			if (GUILayout.Button("New Level List")) {
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = _levelList;
			}
			GUILayout.EndHorizontal();

			if (_levelList == null) {
				GUILayout.BeginHorizontal();
				GUILayout.Space(10);
				if (GUILayout.Button("Create Level List", GUILayout.ExpandWidth(false))) {
					CreateNewLevelList();
				}
				if (GUILayout.Button("Open Level List", GUILayout.ExpandWidth(false))) {
					OpenLevelList();
				}
				GUILayout.EndHorizontal();
			}

			GUILayout.Space(20);

			if (_levelList != null) {
				GUILayout.BeginHorizontal();

				GUILayout.Space(10);

				if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) {
					if (_viewIndex > 1)
						_viewIndex--;
				}
				GUILayout.Space(5);
				if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) {
					if (_viewIndex < _levelList.levels.Count) {
						_viewIndex++;
					}
				}

				GUILayout.Space(60);

				if (GUILayout.Button("Add Level", GUILayout.ExpandWidth(false))) {
					AddItem();
				}
				if (GUILayout.Button("Delete Level", GUILayout.ExpandWidth(false))) {
					DeleteItem(_viewIndex - 1);
				}

				GUILayout.EndHorizontal();
				if (_levelList.levels == null)
					Debug.Log("wtf");
				if (_levelList.levels.Count > 0) {
					GUILayout.BeginHorizontal();
					_viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Level", _viewIndex, GUILayout.ExpandWidth(false)), 1, _levelList.levels.Count);
					EditorGUILayout.LabelField("of   " + _levelList.levels.Count.ToString() + "  levels", "", GUILayout.ExpandWidth(false));
					GUILayout.EndHorizontal();

					_levelList.levels[_viewIndex - 1].levelName = EditorGUILayout.TextField("Level Name", _levelList.levels[_viewIndex - 1].levelName as string);
					_levelList.levels[_viewIndex - 1].height = EditorGUILayout.FloatField("Level Height", _levelList.levels[_viewIndex - 1].height);
					_levelList.levels[_viewIndex - 1].brickRowCount = EditorGUILayout.IntField("Bick Row Count", _levelList.levels[_viewIndex - 1].brickRowCount);
					_levelList.levels[_viewIndex - 1].brickColCount = EditorGUILayout.IntField("Brick Column Count", _levelList.levels[_viewIndex - 1].brickColCount);
				} else {
					GUILayout.Label("This Level List is Empty.");
				}
			}
			if (GUI.changed) {
				EditorUtility.SetDirty(_levelList);
			}
		}

		void CreateNewLevelList() {
			_viewIndex = 1;
			_levelList = CreateLevelList.Create();
			if (_levelList) {
				_levelList.levels = new List<LevelData>();
				string relPath = AssetDatabase.GetAssetPath(_levelList);
				EditorPrefs.SetString("ObjectPath", relPath);
			}
		}

		void OpenLevelList() {
			string absPath = EditorUtility.OpenFilePanel("Select Level List", "", "");
			if (absPath.StartsWith(Application.dataPath)) {
				string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
				_levelList = AssetDatabase.LoadAssetAtPath(relPath, typeof(LevelList)) as LevelList;
				if (_levelList.levels == null)
					_levelList.levels = new List<LevelData>();
				if (_levelList) {
					EditorPrefs.SetString("ObjectPath", relPath);
				}
			}
		}

		void AddItem() {
			LevelData newLevel = new LevelData();
			newLevel.levelName = "New Item";
			_levelList.levels.Add(newLevel);
			_viewIndex = _levelList.levels.Count;
		}

		void DeleteItem(int index) {
			_levelList.levels.RemoveAt(index);
		}
	}
}
#endif
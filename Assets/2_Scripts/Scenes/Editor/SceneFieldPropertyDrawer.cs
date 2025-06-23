#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Cf_Episode
{
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty sceneAsset = property.FindPropertyRelative("sceneAsset");

            sceneAsset.objectReferenceValue =
                EditorGUI.ObjectField(position, label, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

            if (!sceneAsset.objectReferenceValue)
                return;
            
            SerializedProperty sceneName = property.FindPropertyRelative("sceneName");

            sceneName.stringValue = sceneAsset.objectReferenceValue.name;
            
            SerializedProperty sceneRelativePath = property.FindPropertyRelative("sceneRelativePath");
            SerializedProperty sceneAbsolutePath = property.FindPropertyRelative("sceneAbsolutePath");

            string relativePath = AssetDatabase.GetAssetPath(sceneAsset.objectReferenceValue);
            string absolutePath = Path.GetFullPath(relativePath);

            sceneRelativePath.stringValue = relativePath;
            sceneAbsolutePath.stringValue = absolutePath;
        }
    }
}

#endif
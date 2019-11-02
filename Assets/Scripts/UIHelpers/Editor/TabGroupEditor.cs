using UIHelpers;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TabGroup))]
public class TabGroupEditor : Editor
{
    private SerializedProperty _buttonsProperty;
    private SerializedProperty _windowsProperty;
    private SerializedProperty _presenterProperty;

    private void OnEnable()
    {
        _buttonsProperty = serializedObject.FindProperty("_tabButtons");
        _windowsProperty = serializedObject.FindProperty("_tabWindows");
        _presenterProperty = serializedObject.FindProperty("_presenter");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal("box");
        EditorGUIUtility.labelWidth = 80;
        EditorGUILayout.PropertyField(_presenterProperty);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Set from children"))
        {
            ((TabGroup) serializedObject.targetObject).AddButtonsFromChildren();
        }
        
        EditorGUILayout.Space();
        
        EditorGUIUtility.labelWidth = 1;
        EditorGUILayout.BeginHorizontal("box");
        EditorGUILayout.PropertyField(_buttonsProperty, true);
        EditorGUILayout.PropertyField(_windowsProperty, true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties();
    }
}

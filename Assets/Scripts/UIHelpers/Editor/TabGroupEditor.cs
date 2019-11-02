using UIHelpers;
using UnityEditor;

[CustomEditor(typeof(TabGroup))]
public class TabGroupEditor : Editor
{
    private SerializedProperty _buttonsProperty;
    private SerializedProperty _windowsProperty;
    private SerializedProperty _defaultColorProperty;
    private SerializedProperty _hoverColorProperty;
    private SerializedProperty _selectColorProperty;
    
    private void OnEnable()
    {
        _buttonsProperty = serializedObject.FindProperty("_tabButtons");
        _windowsProperty = serializedObject.FindProperty("_tabWindows");
        _defaultColorProperty = serializedObject.FindProperty("colorDefault");
        _hoverColorProperty = serializedObject.FindProperty("colorOnHover");
        _selectColorProperty = serializedObject.FindProperty("colorOnSelected");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginVertical();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(_defaultColorProperty);
        EditorGUILayout.PropertyField(_hoverColorProperty);
        EditorGUILayout.PropertyField(_selectColorProperty);
        
        EditorGUILayout.Space();
        
        EditorGUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 1;
        EditorGUILayout.PropertyField(_buttonsProperty, true);
        EditorGUILayout.PropertyField(_windowsProperty, true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties();
    }
}

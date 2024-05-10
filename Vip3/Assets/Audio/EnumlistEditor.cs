using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnumToAudio))]
public class EnumlistEditor : Editor
{
    private SerializedProperty itemsProperty;

    SerializedProperty audioClipProperty;
    EnumToAudio enumToAudio;
 
    private void OnEnable()
    {    
        // Initialize the SerializedProperty for the 'items' list
        itemsProperty = serializedObject.FindProperty("audioList");
        enumToAudio = (EnumToAudio)target;
    }
    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        EditorGUILayout.Space();

        Sound[] enumValues = (Sound[])Enum.GetValues(typeof(Sound));


        for (int i = 0; i < enumValues.Length; i++)
        {
            Sound enumValue = enumValues[i];

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(enumValue.ToString(), GUILayout.Width(100)); // Display enum value as label

            SerializedProperty audioClipProperty = itemsProperty.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(audioClipProperty, GUIContent.none); // Display AudioClip field

            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// NOTE put in a "Editor" folder
[CustomPropertyDrawer(typeof(FloatBar),true)]
public class PropDrawFloatBar: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //FloatBar var = (FloatBar)attribute;

        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty max = property.FindPropertyRelative("max");
        SerializedProperty min = property.FindPropertyRelative("min");
        SerializedProperty current = property.FindPropertyRelative("current");

        float delta = 0;

        var pos = new Rect(position.x + delta, position.y, position.width * 0.12f, position.height);
        EditorGUI.LabelField(pos, property.name);
        delta += pos.width;

        pos = new Rect(position.x + delta, position.y, position.width * 0.58f, position.height);
        EditorGUI.Slider(pos, current, min.floatValue, max.floatValue, GUIContent.none);
        delta += pos.width;

        pos = new Rect(position.x + delta, position.y, position.width * 0.075f, position.height);
        EditorGUI.LabelField(pos, "Min");
        delta += pos.width;

        pos = new Rect(position.x + delta, position.y, position.width * 0.075f, position.height);
        EditorGUI.PropertyField(pos, min, GUIContent.none);
        delta += pos.width;

        pos = new Rect(position.x + delta, position.y, position.width * 0.075f, position.height);
        EditorGUI.LabelField(pos, "Max");
        delta += pos.width;

        pos = new Rect(position.x + delta, position.y, position.width * 0.075f, position.height);
        EditorGUI.PropertyField(pos, max, GUIContent.none);
        delta += pos.width;

        EditorGUI.EndProperty();
        
    }
}
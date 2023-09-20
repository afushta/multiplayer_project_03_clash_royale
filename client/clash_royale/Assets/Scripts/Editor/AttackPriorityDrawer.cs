using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AttackPriority))]
public class AttackPriorityDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string fullPathName = property.propertyPath + "._targetType";
        SerializedProperty targetType = property.serializedObject.FindProperty(fullPathName);
        int flag = targetType.enumValueFlag;
        List<string> types = new List<string>();
        if (flag == ~0) types.Add("All");
        else if (flag == 0) types.Add("None");
        else
        {
            foreach(UnitType value in Enum.GetValues(typeof(UnitType)))
            {
                int iValue = (int)value;
                if (iValue == 0) continue;

                if ((flag & iValue) == iValue) types.Add(value.ToString());
            }
        }
        string newLabel = string.Join(", ", types);
        EditorGUI.PropertyField(position, property, new GUIContent(newLabel, label.tooltip), true);
    }
}

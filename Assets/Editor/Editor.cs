using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine;

// IngredientDrawer
[CustomPropertyDrawer(typeof(AttackDescriptor))]
public class AttackDescriptorDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var HitstunRect = new Rect(position.x, position.y, 200, 20f);
        var DamageRect = new Rect(position.x , position.y+ 25f, 200, 20f);

        var testtest = new Rect(position.x, position.y + 50f, 200, 20f);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(HitstunRect, property.FindPropertyRelative("hitstun"), new GUIContent("Hitstun duration"));
        EditorGUI.PropertyField(DamageRect, property.FindPropertyRelative("damage"), new GUIContent("Damage"));
        EditorGUI.PropertyField(testtest, property.FindPropertyRelative("text"), new GUIContent("test"));

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
    {
        return 70f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScrollMaterial))]
public class DropDownBox : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScrollMaterial script = (ScrollMaterial)target;

        GUIContent TextureTypes = new GUIContent("TextureTypes");
        script.TextureIndex = EditorGUILayout.Popup(TextureTypes, script.TextureIndex, script.TextureTypes);
    }
}

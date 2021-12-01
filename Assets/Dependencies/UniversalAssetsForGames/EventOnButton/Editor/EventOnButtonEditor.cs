using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventOnButton))]
public class EventOnButtonEditor : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        EventOnButton myScript = (EventOnButton)target;
        if (GUILayout.Button("Do!")) {
            myScript.WhenPress();
        }
    }

}
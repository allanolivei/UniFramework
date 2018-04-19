﻿namespace UniFramework.Events
{
#if UNITY_EDITOR
#if !ODIN_INSPECTOR
    using UnityEditor;

    using UnityEngine;

    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Invoke"))
                e.Invoke();
        }
    }
#endif
#endif
}
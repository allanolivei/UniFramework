#if UNITY_EDITOR && ODIN_INSPECTOR
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using System.Linq;

public class GameEventManager : OdinMenuEditorWindow
{
    [TableList]
    public static List<GameEventListener> events = new List<GameEventListener>();

    [MenuItem("Tools/UniFramework/GameEvent Listeners")]
    private static void OpenWindow()
    {
        var window = GetWindow<GameEventManager>();
        window.titleContent.text = "Listeners";
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree(true);
        tree.DefaultMenuStyle.IconSize = 28.00f;
        tree.Config.DrawSearchToolbar = true;

        var evs = GetEvents();

        Dictionary<string, int> listenerAmount = new Dictionary<string, int>();

        for (int i = 0; i < evs.Count; i++)
        {
            string key;
            if (evs[i].Event != null)
                key = evs[i].name + " > " + evs[i].Event.name;
            else
                key = evs[i].name + " > NULL " + i;

            if (listenerAmount.ContainsKey(key))
            {
                listenerAmount[key] += 1;
            }
            else
            {
                listenerAmount.Add(key, 0);
            }

            if (listenerAmount[key] != 0)
                tree.Add(key + " (" + listenerAmount[key] + ")", evs[i]);
            else
                tree.Add(key, evs[i]);
        }

        tree.SortMenuItemsByName();
        tree.MenuItems.AddIcons(EditorIcons.Flag);

        return tree;
    }

    public List<GameEventListener> GetEvents()
    {
        var evs = FindObjectsOfType<GameEventListener>();

        events.Clear();
        for (int i = 0; i < evs.Length; i++)
        {
            events.Add(evs[i]);
        }

        return events;
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuItem selected = null;
        if (MenuTree != null && MenuTree.MenuItems.Count > 0)
        {
            selected = MenuTree.Selection.FirstOrDefault();
            var toolbarHeight = MenuTree.Config.SearchToolbarHeight;

            // Draws a toolbar with the name of the currently selected menu item.

            SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
            {
                if (selected != null)
                {
                    //GUILayout.Label(((GameEventListener)selected.ObjectInstance).name + " > " + selected.Name);
                    //GUILayout.Label(selected.Name);

                    if (SirenixEditorGUI.ToolbarButton(new GUIContent("Select GameObject")))
                    {
                        Selection.activeGameObject = (((GameEventListener)selected.ObjectInstance).gameObject);
                    }
                }

                if (SirenixEditorGUI.ToolbarButton(new GUIContent("Reload Tree")))
                {
                    ForceMenuTreeRebuild();
                }
            }
            SirenixEditorGUI.EndHorizontalToolbar();
        }
        else {
            if (SirenixEditorGUI.ToolbarButton(new GUIContent("Reload Tree")))
            {
                ForceMenuTreeRebuild();
            }
        }
    }

    protected override void DrawEditor(int index)
    {
        GameEventListener obj = (GameEventListener)CurrentDrawingTargets[index];

        if (obj != null)
        {
            string key;
            if (obj.Event != null)
                key = obj.name + " > " + obj.Event.name;
            else
                key = obj.name + " > NULL " + index;

            SirenixEditorGUI.BeginBox(key);
            {
                base.DrawEditor(index);
            }
            SirenixEditorGUI.EndBox();
        }        
    }
}
#endif
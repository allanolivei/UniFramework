#if UNITY_EDITOR && ODIN_INSPECTOR
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using System.Linq;

public class UniExplorer : OdinMenuEditorWindow
{
    [TableList]
    public static List<ScriptableVariable> events = new List<ScriptableVariable>();

    [MenuItem("Tools/UniFramework/UniExplorer")]
    private static void OpenWindow()
    {
        var window = GetWindow<UniExplorer>();
        window.titleContent.text = "UniExplorer";
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree(true);
        tree.DefaultMenuStyle.IconSize = 28.00f;
        tree.Config.DrawSearchToolbar = true;

        tree.AddAllAssetsAtPath("GameEvent", "ScriptableObjects/GameEvents", typeof(GameEvent), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/GameEvent Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Bool", "ScriptableObjects/Variables", typeof(BoolVariable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/BoolVariable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Int", "ScriptableObjects/Variables", typeof(IntVariable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/IntVariable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Float", "ScriptableObjects/Variables", typeof(FloatVariable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/FloatVariable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("String", "ScriptableObjects/Variables", typeof(StringVariable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/StringVariable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Color", "ScriptableObjects/Variables", typeof(ColorVariable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/ColorVariable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Vector2", "ScriptableObjects/Variables", typeof(Vector2Variable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/Vector2Variable Icon.png", typeof(Texture2D)));

        tree.AddAllAssetsAtPath("Vector3", "ScriptableObjects/Variables", typeof(Vector3Variable), true)
            .AddIcons((Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/Vector3Variable Icon.png", typeof(Texture2D)));

        //tree.MenuItems.AddIcons<GameEvent>(x => EditorIcons.Bell.Raw);
        //tree.MenuItems.AddIcons(EditorIcons.Bell);

        return tree;
    }

    public List<ScriptableVariable> GetVars()
    {
        var evs = FindObjectsOfType<ScriptableVariable>();

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

                    //if (SirenixEditorGUI.ToolbarButton(new GUIContent("Select GameObject")))
                    //{
                    //    Selection.activeGameObject = (((ScriptableVariable)selected.ObjectInstance).gameObject);
                    //}
                }

                if (SirenixEditorGUI.ToolbarButton(new GUIContent("Reload Tree")))
                {
                    ForceMenuTreeRebuild();
                }
            }
            SirenixEditorGUI.EndHorizontalToolbar();
        }
        else
        {
            if (SirenixEditorGUI.ToolbarButton(new GUIContent("Reload Tree")))
            {
                ForceMenuTreeRebuild();
            }
        }
    }

    protected override void DrawEditor(int index)
    {
        ScriptableObject obj = (ScriptableObject)CurrentDrawingTargets[index];
        SirenixEditorGUI.BeginBox(obj.name);
        {
            base.DrawEditor(index);
        }        
        SirenixEditorGUI.EndBox();
    }
}
#endif
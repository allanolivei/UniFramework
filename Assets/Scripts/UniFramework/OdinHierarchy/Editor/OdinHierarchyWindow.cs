namespace UniFramework.Utility.Editor
{
#if ODIN_INSPECTOR
    /// <summary>
    /// Odin Hierarchy
    /// Sirawat Pitaksarit / 5argon
    /// Exceed7 Experiments 
    /// Contact : http://5argon.info, http://exceed7.com, 5argon@exceed7.com
    /// </summary>

    using Sirenix.OdinInspector.Editor;
    using Sirenix.Utilities;
    using Sirenix.Utilities.Editor;
    using UnityEditor;
    using UnityEngine;

    public class OdinHierarchyWindow : OdinEditorWindow
    {
        private static OdinHierarchyWindow window;

        [MenuItem("Window/Odin Hierarchy")]
        private static void Open()
        {
            window = GetWindow<OdinHierarchyWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
            window.titleContent = new GUIContent("Odin Hierarchy");
        }

        public void Refresh() => OnEnable();

        protected override object GetTarget()
        {
            if (OdinHierarchyDrawer.ohsStatic != null)
            {
                return OdinHierarchyDrawer.ohsStatic;
            }
            else
            {
                //It works but is this how we supposed to use GetTarget to draw custom messages??
                return new OdinHierarchySettings.Error();
            }
        }

        protected override void OnBeginDrawEditors()
        {
            EditorApplication.RepaintHierarchyWindow();
        }
    }
#endif
}
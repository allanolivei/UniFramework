namespace UniFramework.Setters
{
    using TMPro;
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/2D and 3D/TextMesh Setter")]
    public class TextMesh3DSetter : Setter
    {

        public ScriptableVariable variable;
        public TextMeshPro text;
        public string format;
        public string prefix;
        public string suffix;
        public float valueToAddIfIntOrFloat;

        public override void Set()
        {
            if (variable.GetType().ToString() != "StringVariable")
            {
                var varContent = variable.DynamicGet();
                if (varContent is int || varContent is float)
                {
                    varContent += valueToAddIfIntOrFloat;
                }
                try
                {
                    text.SetText($"{prefix}{varContent.ToString(format)}{suffix}");
                }
                catch (System.Exception)
                {
                    text.SetText($"{prefix}{varContent.ToString()}{suffix}");
                }
            }
            else
                text.SetText($"{prefix}{variable.DynamicGet()}{suffix}");
        }
    }
}

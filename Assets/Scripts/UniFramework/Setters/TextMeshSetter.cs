namespace UniFramework.Setters
{
    using TMPro;
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/UI/TextMesh UGUI Setter")]
    public class TextMeshSetter : Setter
    {

        public ScriptableVariable variable;
        public TextMeshProUGUI text;
        public string format;

        public override void Set()
        {
            if (variable.GetType().ToString() != "StringVariable")
            {
                try
                {
                    text.SetText(variable.DynamicGet().ToString(format));
                }
                catch (System.Exception)
                {
                    text.SetText(variable.DynamicGet().ToString());
                }
            }
            else
                text.SetText(variable.DynamicGet());
        }
    }
}

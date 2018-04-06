using TMPro;
using UnityEngine;

[AddComponentMenu("Setter/2D and 3D/TextMesh Setter")]
public class TextMesh3DSetter : Setter
{

    public ScriptableVariable variable;
    public TextMeshPro text;
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

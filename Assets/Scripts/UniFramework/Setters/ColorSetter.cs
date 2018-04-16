namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Color Setter")]
    public class ColorSetter : Setter
    {

        public ColorReference newColor;
        public ColorVariable variable;

        public override void Set()
        {
            variable.Value = newColor.Value;
        }
    }
}

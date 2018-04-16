namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/String Setter")]
    public class StringSetter : Setter
    {

        public StringReference newValue;
        public StringVariable variable;

        public override void Set()
        {
            variable.SetValue(newValue.Value);
        }
    }
}

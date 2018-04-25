namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Int To Float Setter")]
    public class IntToFloatSetter : Setter
    {

        public IntReference newValue;
        public FloatVariable variable;

        public override void Set()
        {
            variable.SetValue(newValue.Value);
        }
    }
}

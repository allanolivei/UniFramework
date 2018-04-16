namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Float Setter")]
    public class FloatSetter : Setter
    {

        public FloatReference newValue;
        public FloatVariable variable;

        public override void Set()
        {
            variable.SetValue(newValue.Value);
        }
    }
}

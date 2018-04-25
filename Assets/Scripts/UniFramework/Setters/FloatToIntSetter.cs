namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Float To Int Setter")]
    public class FloatToIntSetter : Setter
    {

        public FloatReference newValue;
        public IntVariable variable;

        public override void Set()
        {
            variable.SetValue((int)newValue.Value);
        }
    }
}

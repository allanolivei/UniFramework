namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Float From Array Setter")]
    public class SetFloatFromArray : SetValueFromArray<FloatVariable, FloatReference>
    {
        public override void SetSpecificValue(FloatReference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Bool From Array Setter")]
    public class SetBoolFromArray : SetValueFromArray<BoolVariable, BoolReference>
    {
        public override void SetSpecificValue(BoolReference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

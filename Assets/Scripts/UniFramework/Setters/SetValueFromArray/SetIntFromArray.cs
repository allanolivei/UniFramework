namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Int From Array Setter")]
    public class SetIntFromArray : SetValueFromArray<IntVariable, IntReference>
    {
        public override void SetSpecificValue(IntReference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/String From Array Setter")]
    public class SetStringFromArray : SetValueFromArray<StringVariable, StringReference>
    {
        public override void SetSpecificValue(StringReference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

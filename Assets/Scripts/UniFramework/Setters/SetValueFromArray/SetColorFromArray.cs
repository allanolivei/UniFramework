﻿namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Color From Array Setter")]
    public class SetColorFromArray : SetValueFromArray<ColorVariable, ColorReference>
    {
        public override void SetSpecificValue(ColorReference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

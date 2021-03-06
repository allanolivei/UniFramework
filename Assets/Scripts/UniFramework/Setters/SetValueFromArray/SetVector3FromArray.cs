﻿namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Vector3 From Array Setter")]
    public class SetVector3FromArray : SetValueFromArray<Vector3Variable, Vector3Reference>
    {
        public override void SetSpecificValue(Vector3Reference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Vector2 From Array Setter")]
    public class SetVector2FromArray : SetValueFromArray<Vector2Variable, Vector2Reference>
    {
        public override void SetSpecificValue(Vector2Reference newValue)
        {
            value.SetValue(newValue);
        }
    }
}

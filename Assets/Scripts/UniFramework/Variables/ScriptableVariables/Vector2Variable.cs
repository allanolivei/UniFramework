﻿namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Vector2", menuName = "Variables/Vector2")]
    public class Vector2Variable : ScriptableVariable
    {

        public Vector2 Value;

        public override dynamic DynamicGet()
        {
            return Value;
        }

        public override void DynamicSet(dynamic newValue)
        {
            try
            {
                SetValue(newValue);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void SetValue(Vector2 newValue)
        {
            Value = newValue;
        }
    }
}

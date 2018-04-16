namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Float", menuName = "Variables/Float")]
    public class FloatVariable : ScriptableVariable
    {

        public float Value;

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

        public void SetValue(float newValue)
        {
            Value = newValue;
        }

        public void Add(float x)
        {
            Value += x;
        }

        public void Subtract(float x)
        {
            Value -= x;
        }

        public void Multiply(float x)
        {
            Value *= x;
        }

        public void Divide(float x)
        {
            Value /= x;
        }
    }
}

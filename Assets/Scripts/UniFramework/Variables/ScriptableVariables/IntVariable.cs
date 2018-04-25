namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Int", menuName = "Variables/Int")]
    public class IntVariable : ScriptableVariable
    {

        public int Value;

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

        public void SetValue(int newValue)
        {
            Value = newValue;
        }

        public void Add(int x)
        {
            Value += x;
        }

        public void Subtract(int x)
        {
            Value -= x;
        }

        public void Multiply(int x)
        {
            Value *= x;
        }

        public void Divide(int x)
        {
            Value /= x;
        }
    }
}

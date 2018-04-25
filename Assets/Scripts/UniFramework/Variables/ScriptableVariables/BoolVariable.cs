namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Bool", menuName = "Variables/Bool")]
    public class BoolVariable : ScriptableVariable
    {
        public bool Value;

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

        public void SetValue(bool newValue)
        {
            Value = newValue;
        }
    }
}

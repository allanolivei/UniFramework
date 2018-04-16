namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "String", menuName = "Variables/String")]
    public class StringVariable : ScriptableVariable
    {
        public string Value;

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

        public void SetValue(string newValue)
        {
            Value = newValue;
        }
    }
}

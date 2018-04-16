namespace UniFramework.Variables
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Color", menuName = "Variables/Color")]
    public class ColorVariable : ScriptableVariable
    {

        public Color Value;

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

        public void SetValue(Color newValue)
        {
            Value = newValue;
        }
    }
}

namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;

    public class SetValueFromArray<ScriptableVar, ScriptableVarType> : MonoBehaviour where ScriptableVar : ScriptableVariable
    {
        public int currentIndex;
        public ScriptableVar value;
        public ScriptableVarType[] possibleValues;

        public void Next()
        {
            Set(currentIndex + 1);
        }

        public void Previous()
        {
            Set(currentIndex - 1);
        }

        public virtual void Set(int index)
        {
            currentIndex = Mathf.Clamp(index, 0, possibleValues.Length - 1);
            SetSpecificValue(possibleValues[currentIndex]);
        }

        public virtual void SetSpecificValue(ScriptableVarType newValue)
        {
            value.DynamicSet(newValue);
        }

        public void SetNewPossibleValues(ScriptableVarType[] newPossibleValues)
        {
            possibleValues = newPossibleValues;
        }

        public ScriptableVarType GetCurrentValue()
        {
            return possibleValues[currentIndex];
        }
    }
}


namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("")]
    public class SetValueFromArray<ScriptableVar, ScriptableRef> : Setter
        where ScriptableVar : ScriptableVariable
    {
        public IntReference currentIndex;
        public ScriptableVar value;
        public ScriptableRef[] possibleValues;

        public void Next()
        {
            Set(currentIndex + 1);
        }

        public void Previous()
        {
            Set(currentIndex - 1);
        }

        public override void Set()
        {
            Set(currentIndex);
        }

        public virtual void Set(int index)
        {
            currentIndex.Value = Mathf.Clamp(index, 0, possibleValues.Length - 1);
            SetSpecificValue(possibleValues[currentIndex]);
        }

        public virtual void SetSpecificValue(ScriptableRef newValue)
        {
            value.DynamicSet(newValue);
        }

        public void SetNewPossibleValues(ScriptableRef[] newPossibleValues)
        {
            possibleValues = newPossibleValues;
        }

        public ScriptableRef GetCurrentValue()
        {
            return possibleValues[currentIndex];
        }
    }
}


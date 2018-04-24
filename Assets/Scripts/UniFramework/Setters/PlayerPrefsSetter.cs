namespace UniFramework.Setters
{
#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif
    using UniFramework.SmartDebug;
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/PlayerPrefs/PlayerPrefs Setter")]
    public class PlayerPrefsSetter : Setter
    {

        public PrefToSave[] prefsToSave;
        [Tooltip("If true, values lower or equal to the amount found for the given key will NOT be saved")]
        public bool ignoreLowerOrEqualsToPrefs;
        [Tooltip("If true, values higher or equal to the amount found for the given key will NOT be saved")]
        public bool ignoreHigherOrEqualsToPrefs;

        public override void Set()
        {
            for (int i = 0; i < prefsToSave.Length; i++)
            {
                if (prefsToSave[i].valueType == PrefToSave.ValueType.Integer)
                {
                    if (((ignoreHigherOrEqualsToPrefs && prefsToSave[i].intValue.Value >= PlayerPrefs.GetInt(prefsToSave[i].key)) ||
                        (ignoreLowerOrEqualsToPrefs && prefsToSave[i].intValue.Value <= PlayerPrefs.GetInt(prefsToSave[i].key))) == false)
                    {
                        PlayerPrefs.SetInt(prefsToSave[i].key, prefsToSave[i].intValue.Value);
                        SmartDebug.Log($"PlayerPrefs {prefsToSave[i].key} set to {prefsToSave[i].intValue.Value}", SmartDebug.LogFilter.Save);
                    }
                }
                else if (prefsToSave[i].valueType == PrefToSave.ValueType.Float)
                {
                    if (((ignoreHigherOrEqualsToPrefs && prefsToSave[i].floatValue.Value >= PlayerPrefs.GetFloat(prefsToSave[i].key)) ||
                        (ignoreLowerOrEqualsToPrefs && prefsToSave[i].floatValue.Value <= PlayerPrefs.GetFloat(prefsToSave[i].key))) == false)
                    {
                        PlayerPrefs.SetFloat(prefsToSave[i].key, prefsToSave[i].floatValue.Value);
                        SmartDebug.Log($"PlayerPrefs {prefsToSave[i].key} set to {prefsToSave[i].floatValue.Value}", SmartDebug.LogFilter.Save);
                    }
                }
                else if (prefsToSave[i].valueType == PrefToSave.ValueType.String)
                {
                    PlayerPrefs.SetString(prefsToSave[i].key, prefsToSave[i].stringValue.Value);
                    SmartDebug.Log($"PlayerPrefs {prefsToSave[i].key} set to {prefsToSave[i].stringValue.Value}", SmartDebug.LogFilter.Save);
                }
            }
        }
    }

    [System.Serializable]
    public class PrefToSave
    {
        public enum ValueType { Integer, Float, String }

#if ODIN_INSPECTOR
        [EnumToggleButtons]
#endif
        public ValueType valueType;
        public string key;

#if !ODIN_INSPECTOR
        public IntReference intValue;
        public FloatReference floatValue;
        public StringReference stringValue;
#else
        [ShowIf("IsInt")]
        public IntReference intValue;
        [ShowIf("IsFloat")]
        public FloatReference floatValue;
        [ShowIf("IsString")]
        public StringReference stringValue;

        private bool IsInt()
        {
            return valueType == ValueType.Integer;
        }

        private bool IsFloat()
        {
            return valueType == ValueType.Float;
        }

        private bool IsString()
        {
            return valueType == ValueType.String;
        }
#endif
    }
}
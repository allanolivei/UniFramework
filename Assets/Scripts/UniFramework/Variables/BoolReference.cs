﻿namespace UniFramework.Variables
{
    using System;

    [Serializable]
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference()
        { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public bool Value
        {
            get
            {
                if (UseConstant)
                {
                    return ConstantValue;
                }
                else
                {
                    return Variable.Value;
                }
            }
            set
            {
                if (UseConstant)
                {
                    ConstantValue = value;
                }
                else
                {
                    Variable.Value = value;
                }
            }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}
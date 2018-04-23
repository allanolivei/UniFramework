﻿namespace UniFramework.Variables
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3Reference()
        { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Vector3 Value
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

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}

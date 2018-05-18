﻿namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class CheckCollisionEnter : MonoBehaviour
    {
        public StringReference nameToCheck;
        public StringReference tagToCheck;
        public UnityEvent onCollision;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Check(collision.gameObject.name, collision.gameObject.tag);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Check(collision.gameObject.name, collision.gameObject.tag);
        }

        public void Check(string name, string tag)
        {
            if (string.IsNullOrEmpty(nameToCheck) == false && name.Contains(nameToCheck))
            {
                onCollision.Invoke();
            }
            else if (string.IsNullOrEmpty(tagToCheck) == false && tag.Contains(tagToCheck))
            {
                onCollision.Invoke();
            }
        }

        public void Invoke()
        {
            onCollision.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableVariable : ScriptableObject {

    public virtual dynamic DynamicGet()
    {
        return null;
    }

    public virtual void DynamicSet(dynamic newValue)
    {
        Debug.Log("DynamicSet not implemented!");
    }
}

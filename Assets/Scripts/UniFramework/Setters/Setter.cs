using UnityEngine;

[AddComponentMenu("")]
public class Setter : MonoBehaviour {

    public bool setOnAwake;
    public bool setOnStart;
    public bool setOnUpdate;

    void Awake()
    {
        if (setOnAwake)
        {
            Set();
        }
    }

    void Start () {
        if (setOnStart)
        {
            Set();
        }
    }
	
	void Update () {
        if (setOnUpdate)
        {
            Set();
        }
    }

    public virtual void Set()
    {

    }
}

using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 testV;

    private void Start()
    {
        Debug.Log($"Original: {testV.ToString()}; OriginalTOVString: {testV.ToV3String()}; WithX5: {testV.WithX(5)}");
        object obj = new object();
        string line = "aaa";
        Debug.Log(line);
        line.UnityStringToBytes();
        Debug.Log(line);
        Debug.Log(line.UnityStringToBytes().ToStringPretty());
    }
}

using UnityEngine;
[ExecuteAlways]
public class fpsLock : MonoBehaviour
{
    [ExecuteAlways]
    void Start()
    {
        Application.targetFrameRate = 30;
    }
}

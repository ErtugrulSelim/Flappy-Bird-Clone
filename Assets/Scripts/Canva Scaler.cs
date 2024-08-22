using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaScaler : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    private void Start()
    {
        if(canvasScaler == null)
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }
    }
    void Update()
    {
    }
}

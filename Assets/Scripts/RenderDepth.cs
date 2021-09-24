using UnityEngine;

[ExecuteInEditMode]
public class RenderDepth : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }
}

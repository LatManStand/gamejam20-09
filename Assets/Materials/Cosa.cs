using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Cosa : MonoBehaviour
{
    public SkinnedMeshRenderer mr;
    //public Material materialResaltado;
    MaterialPropertyBlock bloc;
    public Color color;

    [ContextMenu("Cambia")]
    void Cambia()
    {
        //mr.sharedMaterial.SetColor("_Tint", Color.black);
        bloc = new MaterialPropertyBlock();
        mr.GetPropertyBlock(bloc);
        bloc.SetColor("_Tint", Color.black);
        mr.SetPropertyBlock(bloc);
    }

    private void Update()
    {
        Shader.SetGlobalColor("_Tint", color);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceBackgroundScript : MonoBehaviour
{
    public float bgSpaceScrollSpeed = 0.1f;
    private MeshRenderer bgSpace_meshRenderer;
    private float Yaxis_Scroll;
    void Awake()
    {
        bgSpace_meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        Scroll();
    }
    private void Scroll()
    {
        Yaxis_Scroll = Time.time * bgSpaceScrollSpeed;
        Vector2 offsetVectors = new Vector2(0f, Yaxis_Scroll);
        bgSpace_meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offsetVectors);
    }
}

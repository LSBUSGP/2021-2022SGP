using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ScrollMaterial : MonoBehaviour
{

    public MeshRenderer MR;
    [Range(-1, 1)]
    [SerializeField] private float ScrollRateX, ScrollRateY;

    [HideInInspector] public int TextureIndex = 0;
    [HideInInspector] public string[] TextureTypes = new string[] { "_MainTex", "_MainTex1" };

    public Color TextureColor = new Color(1,1,1,1);
        
    void Start()
    {
    }

    private void OnRenderObject()
    {
        MR = GetComponent<MeshRenderer>();

        Vector2 s = new Vector2(ScrollRateX, ScrollRateY);

        //MR.material.SetTexture(TextureTypes[TextureIndex],ScrollTex);
        MR.material.SetColor("_Color",TextureColor);
        MR.material.mainTextureOffset += s * Time.deltaTime;
    }
}

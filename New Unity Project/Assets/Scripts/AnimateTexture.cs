using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";

    private Vector2 uvOffset = Vector2.zero;
    private Renderer render;

    void Awake()
    {
        render = GetComponent<Renderer>();
    }
    void Update()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (render.enabled)
        {
            render.material.SetTextureOffset(textureName, uvOffset);
        }
    }
}

using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public float slowDownRate;
    private float baseRate;
    public string textureName = "_MainTex";

    private Vector2 uvOffset = Vector2.zero;
    private Renderer render;

    void Awake()
    {
        baseRate = uvAnimationRate.y;
        uvAnimationRate.y = 0;
        render = GetComponent<Renderer>();
    }
    void Update()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (render.enabled)
        {
            render.material.SetTextureOffset(textureName, uvOffset);
        }

        if (BigDog.instance.currentState == BigDog.bigDogStates.fallen ||
            BigDog.instance.currentState == BigDog.bigDogStates.immobile ||
            BigDog.instance.currentState == BigDog.bigDogStates.dead)
        {
            uvAnimationRate.y += slowDownRate;
        }
        else
        {
            uvAnimationRate.y -= slowDownRate;
        }
        uvAnimationRate.y = Mathf.Clamp(uvAnimationRate.y, baseRate, 0);
    }
}

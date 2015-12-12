using UnityEngine;
using System.Collections;
using DG.Tweening;
public class ScreenShake : MonoBehaviour
{
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    public bool test;
    void Update()
    {
        if(test)
        {
            shake();
            test = false;
        }
    }
    public void shake()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness);
    }
}

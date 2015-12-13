using UnityEngine;
using System.Collections;
using DG.Tweening;
public class ScreenShake : MonoBehaviour
{
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    private Tween currentShake;

    public void shake()
    {
        if (currentShake == null || !currentShake.IsPlaying())
        {
            currentShake = transform.DOShakePosition(duration, strength, vibrato, randomness);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour
{
    public float maxLean;
    public float leanSpeed;
    public float leanRecoverySpeed;

    public float maxMoveDist;
    public float speed;

    private Controller currentInput;

    void Start()
    {
        currentInput = new Controller();
    }
    void Update()
    {
        leanMove(currentInput.horAxis());
        lean(currentInput.rawHorAxis());
    }

    void leanMove(float value)
    {
        Vector3 moveVect = Vector3.right * value * speed;
        transform.Translate(moveVect, Space.World);
        transform.position = Vector3.ClampMagnitude(transform.position, maxMoveDist);
    }

    void lean(float value)
    {
        value = value * -1;
        Vector3 targetRot;
        float currentLeanSpeed;
        if (value != 0)
        {
            targetRot = new Vector3(0, 0, maxLean * value);
            currentLeanSpeed = leanSpeed;
        }
        else
        {
            targetRot = Vector3.zero;
            currentLeanSpeed = leanRecoverySpeed;
        }
        Quaternion target = Quaternion.Euler(targetRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, currentLeanSpeed);
    }
}

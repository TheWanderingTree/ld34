using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour, IActionController
{
    public bool enableActions
    {
        get;
        set;
    }
    public float maxLean;
    public float leanSpeed;
    public float ambientLean;

    public float maxMoveDist;
    public float speed;
    public float allowMoveAngle;

    private Controller currentInput;

    private float currentValue;
    private float currentLean;
    private float currentLeanAngle;
    public float currentDirection
    {
        get;
        private set;
    }

    private Rigidbody rigid;

    public float clearInjectionDelay;
    private float currentClearDelay;
    public float leanInjection;

    public float timeToFall;
    public float canFallRange;
    public float currentTimeToFall
    {
        get;
        private set;
    }
    public bool hasFallen
    {
        get;
        private set;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        currentInput = new Controller();
        enableActions = true;
        currentTimeToFall = timeToFall;
    }
    void Update()
    {
        if (enableActions)
        {
            lean(currentInput.horAxis());
        }

        if (leanInjection != 0)
        {
            if (currentClearDelay > 0)
            {
                currentClearDelay -= Time.deltaTime;
            }
            else
            {
                currentClearDelay = clearInjectionDelay;
            }

            if (currentClearDelay <= 0)
            {
                leanInjection = 0;
            }
        }
    }

    void lean(float value)
    {
        value = value * -1;
        if(value != 0)
        {
            currentValue = value;
        }
        currentLean = value * leanSpeed * Time.deltaTime;

        Vector3 targetRot = new Vector3(0, 0, (currentLean + (ambientLean * currentDirection)));
        Vector3 injectedRot = new Vector3(0, 0, leanInjection);
        transform.Rotate(targetRot + injectedRot);
        Vector3 eulers = transform.rotation.eulerAngles;

        if (eulers.z < 180)
        {
            currentDirection = 1;
            float zAng = Mathf.Clamp(eulers.z, 0, maxLean);
            transform.rotation = Quaternion.Euler(eulers.x, eulers.y, zAng);
            currentLeanAngle = zAng / maxLean;
            if(zAng >= maxLean - canFallRange)
            {
                beginToFall(true);
            }
            else
            {
                beginToFall(false);
            }
        }
        else if(eulers.z > 180)
        {
            currentDirection = -1;
            float zAng = Mathf.Clamp(eulers.z, 360 - maxLean, 360);
            transform.rotation = Quaternion.Euler(eulers.x, eulers.y, zAng);
            currentLeanAngle = Mathf.Abs(360 - zAng) / maxLean;

            if (zAng <= 360 - maxLean + canFallRange)
            {
                beginToFall(true);
            }
            else
            {
                beginToFall(false);
            }
        }
        Vector3 moveVect = -Vector3.right * currentDirection * speed * currentLeanAngle * Time.deltaTime;
        rigid.velocity = moveVect;
        transform.position = Vector3.ClampMagnitude(transform.position, maxMoveDist);
    }

    void beginToFall(bool falling)
    {
        if(falling)
        {
            currentTimeToFall -= Time.deltaTime;
            if(currentTimeToFall <= 0)
            {
                hasFallen = true;
            }
        }
        else
        {
            currentTimeToFall = timeToFall;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour
{
    public float outputDamage;

    private Vector3 initScale;
    private float initMass;

    public static Bag instance
    {
        get;
        private set;
    }

    void Awake()
    {
        initInstance();
        initScale = transform.localScale;
        initMass = GetComponent<Rigidbody>().mass;
    }

    void initInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<Status>())
        {
            hit.GetComponent<Status>().hostileInteraction(outputDamage);
        }
    }
    public void modBagSize(float increase)
    {
        transform.localScale  += new Vector3(increase, increase, increase);
        float clampScale = Mathf.Clamp(transform.localScale.x, initScale.x, 2);
        transform.localScale = new Vector3(clampScale, clampScale, clampScale);
        Vector3 anchor = GetComponent<HingeJoint>().anchor;
        GetComponent<HingeJoint>().anchor = anchor;
        GetComponent<Rigidbody>().mass += initMass * 5 * increase;
    }
}

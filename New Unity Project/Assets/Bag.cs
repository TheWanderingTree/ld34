using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour
{
    public float outputDamage;
    public float bagControlForce;
    private Vector3 initScale;
    private float initMass;

    private Rigidbody rigid;
    public static Bag instance
    {
        get;
        private set;
    }

    private Controller currentControl;

    void Awake()
    {
        initInstance();
        rigid = GetComponent<Rigidbody>();
        initScale = transform.localScale;
        initMass = rigid.mass;

        currentControl = new Controller();
    }

    void initInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    void FixedUpdate()
    {
        rigid.AddForce(transform.right * currentControl.rHorAxis() * bagControlForce);
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
        rigid.mass += initMass * 5 * increase;
        rigid.mass = Mathf.Clamp(rigid.mass, initMass, 300);
    }
}

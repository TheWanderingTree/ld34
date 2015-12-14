using UnityEngine;
using UnityEngine.UI;

public class ApplyForceIndicator : MonoBehaviour
{
    public bool left;
    private Controller control;

    void Start()
    {
        control = new Controller();
    }
    void Update()
    {
        if (left)
        {
            float amount = Mathf.Floor(control.rHorAxis());
            GetComponent<Image>().fillAmount = -amount;
        }
        else
        {
            float amount = Mathf.Ceil(control.rHorAxis());
            GetComponent<Image>().fillAmount = amount;
        }
    }
}

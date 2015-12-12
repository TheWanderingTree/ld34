using UnityEngine;
using System.Collections;

public class Controller
{
    public float horAxis()
    {
        return Input.GetAxis(Inputs.horAxis);
    }

    public float rawHorAxis()
    {
        return Mathf.Round(Input.GetAxisRaw(Inputs.horAxis));
    }

    public float A()
    {
        return Input.GetAxis(Inputs.A);
    }
}

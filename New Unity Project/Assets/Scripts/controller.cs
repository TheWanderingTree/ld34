using UnityEngine;
using System.Collections;

public class Controller
{
    public float horAxis()
    {
        return Input.GetAxis(Inputs.horAxis);
    }

    public float rHorAxis()
    {
        return Input.GetAxis(Inputs.rHorAxis);
    }
    public float rVerAxis()
    {
        return Input.GetAxis(Inputs.rVerAxis);
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

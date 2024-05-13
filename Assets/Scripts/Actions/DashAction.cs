using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class DashAction : IAction
{
    private Dash _dash;

    public DashAction(Dash dash)
    {
        _dash = dash;
    }
    public void Execute()
    {
        _dash.UseDash();
        //Debug.Log("dodged! totally! trust me bro!");
    }
}

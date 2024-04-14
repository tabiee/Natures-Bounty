using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class DodgeAction : IAction
{
    private DodgeRoll _dodgeRoll;

    public DodgeAction(DodgeRoll dodgeRoll)
    {
        _dodgeRoll = dodgeRoll;
    }
    public void Execute()
    {
        _dodgeRoll.Dodge();
        //Debug.Log("dodged! totally! trust me bro!");
    }
}

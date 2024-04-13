using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete
public class Dodge : IAction
{
    private DodgeAbility _rollForward;

    public Dodge(DodgeAbility rollForward)
    {
        _rollForward = rollForward;
    }
    public void Execute()
    {
        _rollForward.DodgeRoll();
        Debug.Log("dodged! totally! trust me bro!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//invoker
public class ActionWheel
{
    IAction _onAction;

    public ActionWheel(IAction onAction)
    {
        _onAction = onAction;
    }

    public void UseAction()
    {
        _onAction.Execute();
    }
}

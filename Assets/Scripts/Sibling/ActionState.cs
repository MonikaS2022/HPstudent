using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : BaseState
{
    MoveState moveState;

    public ActionState(SiblingController siblingController) : base("Action", siblingController)
    {

    }

    public override BaseState CheckTransition()
    {
        return moveState;
    }

}

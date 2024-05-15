using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    [HideInInspector] public string stateName;
    protected SiblingController stateMachine;

    public BaseState(string stateName, SiblingController stateMachine)
    {
        this.stateName = stateName;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public abstract BaseState CheckTransition();
    public virtual void Exit() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActionState : BaseState
{
    MoveState moveState;

    [SerializeField] float actionTime = 1f;
    [SerializeField] float actionCounter = 0f;
    [SerializeField] bool acting;

    public ActionState(SiblingController siblingController) : base("Action", siblingController)
    {

    }

    private void Awake()
    {
        moveState = GetComponent<MoveState>();
    }

    public override void Enter()
    {
        base.Enter();

        acting = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();


        if (acting)
        {

            actionCounter += Time.deltaTime;
            if (actionCounter >= actionTime)
            {
                acting = false;
                actionCounter = 0f;
                actionTime = Random.Range(1, 3);
            }
        }
    }

    public override BaseState CheckTransition()
    {
        if (acting) return null;

        else return moveState;
    }

}

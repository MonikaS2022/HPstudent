using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SiblingController : MonoBehaviour
{
    BaseState currentState;

    [HideInInspector] public MoveState moveState;
    [HideInInspector] public ActionState actionState;

    private void Awake()
    {
        moveState = GetComponent<MoveState>();
        actionState = GetComponent<ActionState>();


    }

    protected BaseState GetInitialState()
    {
        return moveState;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            CheckTransition();
            currentState.UpdateLogic();
        }
    }


    public void CheckTransition()
    {
        BaseState state = currentState.CheckTransition();

        if (state != null)
        {
            //Debug.Log("Entered Transition Check!");
            currentState.Exit();

            currentState = state;
            currentState.Enter();
        }
    }
}

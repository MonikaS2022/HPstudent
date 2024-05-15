using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MoveState : BaseState
{
    //[SerializeField] Vector3 _target;
    [SerializeField] Transform[] waypoints;
    int currentIndex = 0;

    NavMeshAgent navMeshAgent;

    [SerializeField] float waitTime = 1f;
    [SerializeField] float waitCounter = 0f;
    [SerializeField] bool waiting;

    [SerializeField] int speed;

    ActionState action;

    public MoveState(SiblingController siblingController) : base("Move", siblingController)
    {

    }

    private void Awake()
    {
        action = GetComponent<ActionState>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (waiting)
        {
            waitCounter += Time.deltaTime;
            Debug.Log("Waiting");
            if (waitCounter < waitTime)
            {
                return;
            }
            waiting = false;
        }

        Transform waypoint = waypoints[currentIndex];
        if (Vector3.Distance(transform.position, waypoint.position) < 0.1f)
        {
            //transform.position = waypoint.position;
            navMeshAgent.SetDestination(waypoint.position);

            waitCounter = 0f;
            waiting = true;

            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);
            //transform.LookAt(waypoint.position);

            navMeshAgent.SetDestination(waypoint.position);
        }

    }

    public override BaseState CheckTransition()
    {
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MoveState : BaseState
{
    //[SerializeField] Vector3 _target;
    [SerializeField] Transform[] waypoints;
    Vector3 destination;
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
    bool hasDestination = false;

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        Transform waypoint = waypoints[currentIndex];
        if (!hasDestination)
        {
            destination = waypoint.position;
            navMeshAgent.SetDestination(waypoint.position);
            hasDestination = true;

        }

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
        else if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            //transform.position = waypoint.position;

            hasDestination = false;

            waitCounter = 0f;
            waiting = true;

            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);
            //transform.LookAt(waypoint.position);

            //navMeshAgent.SetDestination(waypoint.position);
        }

    }

    public override BaseState CheckTransition()
    {
        return null;
    }
}

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
    int tempValue = 0;

    NavMeshAgent navMeshAgent;

    [SerializeField] float waitTime = 1f;

    [SerializeField] int speed;

    [SerializeField] ActionState action;

    public MoveState(SiblingController siblingController) : base("Move", siblingController)
    {

    }

    private void Awake()
    {
        action = GetComponent<ActionState>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentIndex = Random.Range(0, waypoints.Length);
        tempValue = Random.Range(0, waypoints.Length);
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

            tempValue = Random.Range(0, waypoints.Length);
            if (currentIndex == tempValue)
            {
                currentIndex = Random.Range(0, waypoints.Length);
            }
            else
                currentIndex = tempValue;

        }

    }

    public override BaseState CheckTransition()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {

            hasDestination = false;

            currentIndex = (currentIndex + 1) % waypoints.Length;

            return action;

        }
        else
            return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 0.5f;
    private Vector3 _right;
    private Vector3 _forward;
    [SerializeField] private bool _jump = false;

    bool isMoving = false;
    public Animator animator;
    Vector3 heading;

    MouseBehaviour mouseBehaviour;
    float speed = 2f;
    NavMeshAgent navMeshAgent;
    Vector3 destination;
    bool canMove;

    float distanceToDestination;

    private void Start()
    {
        mouseBehaviour = new MouseBehaviour();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _forward = Camera.main.transform.forward;
        _forward.y = 0f;
        _forward = Vector3.Normalize(_forward);
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {
            destination = mouseBehaviour.GetMouseInWorld();
            NavMeshHit hit;

            if (NavMesh.SamplePosition(destination, out hit, 1.0f, NavMesh.AllAreas))
                canMove = true;
        }
        else
        {
            //isMoving = false;
        }

        if (canMove)
            ClickMove();

        distanceToDestination = Vector3.Distance(transform.position, destination);

        if (distanceToDestination < 1f)
        {
            isMoving = false;
        }


        if (Input.GetButtonDown("Jump") && !_jump)
        {
            
        }
        else
        {
            //if (!Input.anyKey)
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {

                Move();
            }
            else
            {
                //isMoving = false;
            }
        }
        animator.SetBool("isMoving", isMoving);
    }


    void ClickMove()
    {
        isMoving = true;
        if (mouseBehaviour.GetMouseInWorld() != Vector3.zero)
        {
            var dir = (destination - transform.position).normalized;
            var velocity = speed * Time.deltaTime * dir;

            navMeshAgent.SetDestination(destination);
            
        }
        canMove = false;
    }

    //public void DrawGizmo()
    //{
    //    Gizmos.DrawWireSphere(destination, 0.5f);
    //    Gizmos.DrawLine(transform.position, destination);
    //}

    void Move()
    {
        //_rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        isMoving = true;

        Vector3 rightMovement = _right * _speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = _forward * _speed * Time.deltaTime * Input.GetAxis("Vertical");

        heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

    }

    
}

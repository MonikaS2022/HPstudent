using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 0.5f;
    private Vector3 _right;
    private Vector3 _forward;
    [SerializeField] private bool _jump = false;
    [SerializeField] private float _jumpHeight = 8f;
    [SerializeField] private float _jumpSpeed = 10f;
    bool isMoving = false;
    public Animator animator;
    Vector3 heading;


    private void Start()
    {
        _forward = Camera.main.transform.forward;
        _forward.y = 0f;
        _forward = Vector3.Normalize(_forward);
        _right = Quaternion.Euler(new Vector3(0, 90,0)) * _forward;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        animator.SetBool("isMoving", isMoving); 
       
        if(Input.GetButtonDown("Jump") && !_jump)
       {
            StartCoroutine(Jump());    
       }
        else
        {
            if (!Input.anyKey)
            {
                isMoving = false;
            }
            else
            {
                
                Move();
            }
        }
    }

 


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

    IEnumerator Jump()
    {
        float originalHeight = transform.position.y;
        //float maxHeight = originalHeight + _jumpHeight;
        //_rb.useGravity = false;

        _jump = true;
       

        
        _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        yield return null;

        /*
        while(transform.position.y < maxHeight)
        { 
            transform.position += transform.up * Time.deltaTime * _jumpSpeed;
            yield return null;
        
        }
        */
        //_rb.useGravity = true;

        while (transform.position.y > originalHeight)
        {
            //transform.position -= transform.up * Time.deltaTime * _jumpSpeed;
            yield return null;
        }

       // _rb.useGravity = true;
        _jump = false;
        yield return null;
    }
}

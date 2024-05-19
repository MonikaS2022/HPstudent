using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Player_Controller : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float relativeWeight = 500;
    [SerializeField] Camera minigame_2_camera;
    CharacterController characterController;
    Rigidbody rigidBody;
    Vector3 input;

    Quaternion rotationLock;
    Vector3 positionLock;

    // Start is called before the first frame update
    void Start()
    {
        rotationLock = transform.rotation;
        positionLock = transform.position;
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Survival.Instance.inMinigame2)
        {
            return;
        }



        GatherInput();
        Move();


        transform.position = new Vector3(transform.position.x, positionLock.y, positionLock.z);
        transform.rotation = rotationLock;
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
    }

    private void Move()
    {
        //input.y = 0;
        //characterController.Move(input * movementSpeed * Time.deltaTime);
        //rigidBody.AddForce(input * movementSpeed * Time.deltaTime * 1000);
        rigidBody.velocity  = (input * movementSpeed * Time.deltaTime * relativeWeight);
    }



}

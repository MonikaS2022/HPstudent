using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Player_Controller : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] Camera minigame_2_camera;
    CharacterController characterController;
    Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
    }

    private void Move()
    {
        input.y = 0;
        characterController.Move(input * movementSpeed * Time.deltaTime);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Switch : MonoBehaviour
{
    GameObject player;
    GameObject sibling;

    bool readyToSwitch = true;

    [SerializeField] float switchTimer = 2f;
    [SerializeField] float interactionRange = 4f;
    [SerializeField] bool beingUsed = false;
    [SerializeField] Camera mainCam;
    [SerializeField] Camera gameCam;
    [SerializeField] M_Systems systems;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sibling = GameObject.FindGameObjectWithTag("Sibling");
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(sibling.transform.position, transform.position) < interactionRange/2 && !Survival.Instance.inMinigame)
        {
            SetBeingUsed();
        }
        else
        {
            SetNotBeingUsed();
        }

        if (!readyToSwitch || beingUsed)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {

            if (Vector3.Distance(player.transform.position, transform.position) < interactionRange
                && !Survival.Instance.inMinigame1 
                && !Survival.Instance.inMinigame2 
                && !Survival.Instance.inMinigame3)
            {
                Debug.Log("Entering Minigame");
                gameCam.enabled = true;
                mainCam.enabled = false;
                Survival.Instance.inMinigame = true;

                systems.StartGame();
            }
            else if (Survival.Instance.inMinigame1
                || Survival.Instance.inMinigame2
                || Survival.Instance.inMinigame3)
            {
                Debug.Log("Leaving Minigame");
                gameCam.enabled = false;
                mainCam.enabled = true;
                Survival.Instance.inMinigame = false;
                systems.StopGame();
            }

            StartCoroutine(SwitchCD(switchTimer));
            readyToSwitch = false;
        }
    }

    public IEnumerator SwitchCD(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        readyToSwitch = true;
    }
    //when a area is entered make the switch unusable
    public void SetBeingUsed()
    {
        beingUsed = true;
    }

    //when a area is exited make the switch usable
    public void SetNotBeingUsed()
    {
        beingUsed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Switch : MonoBehaviour
{
    GameObject player;

    bool readyToSwitch = true;

    [SerializeField] float switchTimer = 2f;
    [SerializeField] float interactionRange = 4f;
    [SerializeField] Camera mainCam;
    [SerializeField] Camera gameCam;
    [SerializeField] M_Systems systems;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!readyToSwitch)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {

            if (Vector3.Distance(player.transform.position, transform.position) < interactionRange && !Survival.Instance.inMinigame)
            {
                gameCam.enabled = true;
                mainCam.enabled = false;
                Survival.Instance.inMinigame = true;
                systems.StartGame();
            }

            else if (Survival.Instance.inMinigame)
            {
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
}

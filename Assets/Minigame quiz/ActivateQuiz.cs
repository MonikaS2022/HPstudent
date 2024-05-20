using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuiz : M_Systems
{

    [SerializeField] QuizManager qm;
    bool inQuiz = false; 

    public override void StartGame()
    {
        Survival.Instance.inMinigame3 = true;
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A) && inQuiz == false)
        //{
        //    qm.StartGame();
        //    inQuiz = true; 
        //}
        //else if(Input.GetKeyDown(KeyCode.M) && inQuiz == true)
        //{
        //    qm.EndGame();
        //    inQuiz = false; 
        //}
    }

}

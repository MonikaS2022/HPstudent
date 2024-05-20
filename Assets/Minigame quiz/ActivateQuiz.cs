using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuiz : MonoBehaviour
{

    [SerializeField] QuizManager qm;
    bool inQuiz = false; 


    void Update()
    {
//enter game, change with sibling for etc. 
        if(Input.GetKeyDown(KeyCode.A) && inQuiz == false)
        {
            qm.StartGame();
            inQuiz = true; 
        }
        else if(Input.GetKeyDown(KeyCode.M) && inQuiz == true)
        {
            qm.EndGame();
            inQuiz = false; 
        }
    }

}

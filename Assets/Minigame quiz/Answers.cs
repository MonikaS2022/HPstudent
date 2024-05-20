using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager qm;




    public void Answer()
    {
        if (isCorrect)
        {
            //corr
            //qm.rightButton.gameObject.SetActive(true);
            qm.Correct();
            Debug.Log("Rätt");
            Survival.Instance.IncreaseKnowledge(20);
        }
        else
        {
            //false
            //qm.wrongButton.gameObject.SetActive(true);
            qm.Correct();
            Debug.Log("Fel");
        }
    }
}

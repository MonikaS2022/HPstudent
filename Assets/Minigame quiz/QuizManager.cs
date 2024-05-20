using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] Camera quizCam;
    [SerializeField] Canvas canvas;

    public Text questionText;
    public Button[] options;
    public List<QnA> qna;
    int prev;

    public int currentQuestion;

    public GameObject rightButton;
    public GameObject wrongButton;


    void GenereteQuestion()
    {
        currentQuestion = Random.Range(0, qna.Count);
        if(currentQuestion == prev)
        {
            currentQuestion++;
        }
        prev = currentQuestion;
        questionText.text = qna[currentQuestion].questiontext;

        SetAnswer();

        if (qna.Count <= 0)
        {
            //end game
            EndGame();
        }

    }


    public void correct()
    {
        
        GenereteQuestion();


    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].answers[i];

            if (qna[currentQuestion].correctAnswer == i)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    public void StartGame()
    {
        GenereteQuestion();
        canvas.enabled = true;
        quizCam.enabled = true;
        rightButton.gameObject.SetActive(false);
        wrongButton.gameObject.SetActive(false);

    }

    public void EndGame()
    {
        canvas.enabled = false;
        quizCam.enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] public bool isAnsweringQuestion;
    [SerializeField] public bool timeOut;
    [SerializeField] float timePerQuestion;
    [SerializeField] float timeShowAnswer;
    float timerValue;
    public bool loadNextQuestion;
    public float fillFraction;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion) {
            if (timerValue > 0) {
                fillFraction = timerValue / timePerQuestion;
            }
            else {
                timeOut = true;
                isAnsweringQuestion = false;
                timerValue = timeShowAnswer;
            }
        }
        else {
            if (timerValue > 0) {
                fillFraction = timerValue / timeShowAnswer;
            }
            else {
                timeOut = false;
                isAnsweringQuestion = true;
                timerValue = timePerQuestion;
                loadNextQuestion = true;
            }
        }
        //Debug.Log(timerValue);
    }

    public void CancelTimer() {
        timerValue = 0;
    }
}

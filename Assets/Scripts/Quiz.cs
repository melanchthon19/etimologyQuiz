using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] List<QuestionSO> questions;
    [SerializeField] TextMeshProUGUI questionText;
    QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswered;

    [Header("Button Sprites")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Sounds")]
    [SerializeField] AudioClip clipWrong;
    [SerializeField] AudioClip clipCorrect;
    AudioSource audioSource;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Awake() {
        score = FindObjectOfType<Score>();
        audioSource = GetComponent<AudioSource>();
        timer = GetComponent<Timer>();
    }

    void Start() {      
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update() {
        DisplayImage();
        DisplayTimeOut();
        if (timer.loadNextQuestion) {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
    }

    void GetNextQuestion() {
        if (questions.Count > 0) {
            GetRandomQuestion();
            SetDefaultButtonSprites();
            SetButtonsState(true);
            DisplayQuestion();
            score.IncrementQuestionsSeen();
            progressBar.value++;
        }
        else {
            isComplete = true;
        }
    }

    void GetRandomQuestion() {
        int index = Random.Range(0, questions.Count);
        question = questions[index];
        questions.RemoveAt(index);
    }

    void DisplayScore() {
        scoreText.text = "Score: " + score.CalculateScore() + "%";
    }

    void DisplayImage() {
        timerImage.fillAmount = timer.fillFraction;
        
        if (timer.isAnsweringQuestion) {
            timerImage.enabled = true;
        } else {
            SetButtonsState(false);
            timerImage.enabled = false;
        }

    }

    void DisplayTimeOut() {
        if (timer.timeOut && !hasAnswered) {
            questionText.text = "Time's out!";
            audioSource.PlayOneShot(clipWrong);
            timer.timeOut = false;
        }
    }

    void DisplayQuestion() {
        TextMeshProUGUI buttonText;
        questionText.text = question.GetQuestion();
        hasAnswered = false;
        for (int i=0; i<answerButtons.Length; i++) {
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonsState(bool state) {
        Button button;
        for (int i=0; i<answerButtons.Length; i++) {
            button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public void OnAnswerSelected(int index) {
        hasAnswered = true;
        correctAnswerIndex = question.GetCorrectAnswerIndex();
    
        if (index == correctAnswerIndex) {
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            questionText.text = "Correct!";
            
            audioSource.PlayOneShot(clipCorrect);
            score.IncrementCorrectAnswers();
        }
        else {
            questionText.text = "Incorrect...";
            audioSource.PlayOneShot(clipWrong);
        }
        
        SetButtonsState(false);
        timer.CancelTimer();
        DisplayScore();
    }

    void SetDefaultButtonSprites() {
        Image buttonImage;
        for (int i=0; i<answerButtons.Length; i++) {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}

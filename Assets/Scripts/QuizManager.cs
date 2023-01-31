using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    Quiz quiz;
    EndGame endGame;

    // Start is called before the first frame update
    private void Awake() {
        quiz = FindObjectOfType<Quiz>();
        endGame = FindObjectOfType<EndGame>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete) {
            quiz.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);
            endGame.ShowEndScreen();
        }
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenu() {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void OnQuitLevel() {
        Application.Quit();
    }
}

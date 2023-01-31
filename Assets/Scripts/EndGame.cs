using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    Score score;

    void Start() {
        score = FindObjectOfType<Score>();
    }

    public void ShowEndScreen() {
        finalScoreText.text = "Congratulations!\nYou got " + score.CalculateScore() + "%";
    }
}

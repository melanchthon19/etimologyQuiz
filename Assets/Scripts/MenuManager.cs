using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject creditsImage;
    [SerializeField] GameObject whatsgoImage;
    [SerializeField] GameObject playLevelImage;

    public void OnQuit() {
        Application.Quit();
    }

    public void OnCredits() {
        whatsgoImage.SetActive(false);
        playLevelImage.SetActive(false);
        if (creditsImage.activeSelf == false) {
            creditsImage.SetActive(true);
        } else {
            creditsImage.SetActive(false);
        }
    }

    public void OnWhatsGoingOn() {
        creditsImage.SetActive(false);
        playLevelImage.SetActive(false);
        if (whatsgoImage.activeSelf == false) {
            whatsgoImage.SetActive(true);
        } else {
            whatsgoImage.SetActive(false);
        }
    }

    public void OnPlay() {
        creditsImage.SetActive(false);
        whatsgoImage.SetActive(false);
        if (playLevelImage.activeSelf == false) {
            playLevelImage.SetActive(true);
        } else {
            playLevelImage.SetActive(false);
        }
    }

    public void OnPlaySpanish() {
        SceneManager.LoadScene("SpanishLevel");
    }

    public void OnPlayEnglish() {
        SceneManager.LoadScene("EnglishLevel");
    }
}

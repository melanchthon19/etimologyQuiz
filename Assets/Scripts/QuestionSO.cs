using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "QuestionSO", order = 0)]
public class QuestionSO : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question here";
    enum Languages{empty, guaraní, catalán, gallego, inglés, árabe, italiano, francés, neerlandés, sueco, mapudungun, quechua, aimara};
    [SerializeField] Languages[] answers = new Languages[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion() {
        return question;
    }

    public string GetAnswer(int index) {
        return answers[index].ToString();
    }

    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }

}

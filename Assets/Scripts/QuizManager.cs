using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUi quizUi;
    [SerializeField] private QuizDataTable quizDataTable;
    private List<Question> questions;
    private Question selectedQuestion;
    [SerializeField]
    private PlayerControl player;


    // Start is called before the first frame update
    void Start()
    {
        questions = quizDataTable.question;
        //SelectQuestion();
    }

    public void SelectQuestion(bool usingTool)
    {
        int val = Random.Range(0,questions.Count);
        selectedQuestion = questions[val];
        quizUi.SetQuestion(selectedQuestion);
        if (usingTool)
        {
            quizUi.hintUi(selectedQuestion);
        }
        
       
    }
    public bool Answer(string answered)
    {
        bool correctAns = false;
        player.money -= 3000;
        if (answered == selectedQuestion.correctAns) // yes
        {
            correctAns = true;
            player.credit += 3;

        }
        else //no
        {
           
        }
        UpdateState();
        return correctAns;
    }

    public void UpdateState()
    {
        player.creditText.text = player.credit.ToString();
        player.moneyText.text = player.money.ToString();
    }
}



[System.Serializable]
public class Question
{
    public string questionInfo;
    public List<string> options;
    public string correctAns;
    public QuestionType questionType;
}

[System.Serializable]
public enum QuestionType{
    GeneralHard, // 困難通識
    GeneralEasy,
    RequiredEasy, 
    RequiredHard // 困難必修
}

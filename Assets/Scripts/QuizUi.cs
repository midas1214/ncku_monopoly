using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUi : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager; 
    [SerializeField] private TextMeshProUGUI questionInfo;
    [SerializeField] private List<Button> options;
    [SerializeField] private GameObject questionBox;
    [SerializeField] private Dialoge dialogeBox;
    [SerializeField] private Color correctCol, wrongCol, normalCol,hintCol;
    private Question question;
    private bool answered;


    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(()=>OnClick(localButton));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        questionInfo.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }
        answered = false;
    }

    public void hintUi(Question question)
    {
        this.question = question;
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].name == question.correctAns)
            {
                options[i].image.color = hintCol;
            }
        }
    }

    private void OnClick(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);
            if (val) // correct
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
            StartCoroutine(Delay(1.5f));
        }
    }
    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        dialogeBox.resetDialogeBox();
    }
}

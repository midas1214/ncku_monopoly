using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoge : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nowEvent;
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private selectCardUi selectCardUi;
    [SerializeField] private GameObject questionBox;
    [SerializeField] private GameObject eventBox;
    [SerializeField] private GameObject shopBox;
    [SerializeField] private GameObject selectCardBox;


    // Start is called before the first frame update
    void Start()
    {
        questionBox.SetActive(false);
        eventBox.SetActive(false);
        shopBox.SetActive(false);
        selectCardBox.SetActive(false);
    }

    public void setDialoge(int e)
    {
        switch (e)
        {
            case 0:
                nowEvent.text = "通識";
                questionBox.SetActive(true);
                quizManager.SelectQuestion();
                break;
            case 1:
                nowEvent.text = "必選修";
                questionBox.SetActive(true);
                quizManager.SelectQuestion();
                break;
            case 2:
                nowEvent.text = "機會";
                eventBox.SetActive(true);
                eventManager.SelectEvent();
                break;
            case 3:
                nowEvent.text = "命運";
                eventBox.SetActive(true);
                eventManager.SelectEvent();
                break;
            case 4:
                nowEvent.text = "扣錢";
                selectCardBox.SetActive(true);
                selectCardUi.SetCard(2);
                break;
            case 5:
                nowEvent.text = "加錢";
                selectCardBox.SetActive(true);
                selectCardUi.SetCard(1);
                break;
            case 6:
                nowEvent.text = "成大醫院";
                break;
            case 7:
                nowEvent.text = "起點";
                break;
            case 8:
                nowEvent.text = "商店";
                shopBox.SetActive(true);
                break;


        }

    }
    public void resetDialogeBox()
    {
        questionBox.SetActive(false);
        eventBox.SetActive(false);
        shopBox.SetActive(false);
        selectCardBox.SetActive(false);
        nowEvent.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

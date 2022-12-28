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
    [SerializeField] private GameObject startBox;

    [SerializeField]
    private PlayerControl player;


    // Start is called before the first frame update
    void Start()
    {
        questionBox.SetActive(false);
        eventBox.SetActive(false);
        shopBox.SetActive(false);
        selectCardBox.SetActive(false);
        startBox.SetActive(true);
    }

    public void setDialoge(int e)
    {
        switch (e)
        {
            case 0:
                
                questionBox.SetActive(true);
                if (player.usingTool == true && player.nowUsingTool == 0) 
                {
                    nowEvent.text = "通識   正在使用槍手道具";
                    quizManager.SelectQuestion(true);
                    player.GetComponent<BackpackManager>().finishUseTool();
                    player.usingTool = false;
                }
                else if (player.usingTool == false)
                {
                    nowEvent.text = "通識";
                    quizManager.SelectQuestion(false);
                }
                
                break;
            case 1:
                
                questionBox.SetActive(true);
                if (player.usingTool == true && player.nowUsingTool ==0) 
                {
                    nowEvent.text = "必選修   正在使用槍手道具";
                    quizManager.SelectQuestion(true);
                    player.GetComponent<BackpackManager>().finishUseTool();
                    player.usingTool = false;
                }
                else if (player.usingTool == false)
                {
                    nowEvent.text = "必選修";
                    quizManager.SelectQuestion(false);
                }
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
                nowEvent.text = "炸彈";
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
                resetDialogeBox();
                break;
            case 7:
                nowEvent.text = "起點";
                startBox.SetActive(true);
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
        startBox.SetActive(false);
        RollDice.coroutineAllow = true;
        //Cursor.lockState = CursorLockMode.None;
        nowEvent.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class selectCardUi : MonoBehaviour
{
    [SerializeField] private List<Button> options;
    [SerializeField] public TextMeshProUGUI result;
    [SerializeField] private Dialoge dialogeBox;
    [SerializeField] private PlayerControl player;
    [SerializeField] private Sprite card;
    [SerializeField] private List<Sprite> coverCard;
    List<int> resultList;
    private List<int> addMoney = new List<int>() { 1000, 3000, 6000, 0 };
    private List<int> cutMoney = new List<int>() { -1000, -2000, -500, -1500 };

    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.image.sprite = coverCard[i];
            localButton.onClick.AddListener(() => OnClick(localButton));
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
    public void SetCard(int type)
    {
        if (type ==1) // add money
        {
            resultList = ShuffleList.ShuffleListItems<int>(addMoney);
        } 
        else // cut money
        {
            resultList = ShuffleList.ShuffleListItems<int>(cutMoney);
        }
       
        for (int i = 0; i < options.Count; i++)
        {
            options[i].name = resultList[i].ToString();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        result.text = "請選擇一張卡片";
    }

    void UpdateState()
    {
        player.moneyText.text = player.money.ToString();

    }

    private void OnClick(Button btn)
    {
        btn.GetComponentInChildren<TextMeshProUGUI>().text = btn.name;
        btn.image.sprite = card;
        player.money += Int16.Parse(btn.name);
        player.ShowMoneyCreditChange(Int16.Parse(btn.name), "money");

        if (Int16.Parse(btn.name) < 0)
        {
            result.text = "損失 " + btn.name +" 元";
            player.playAudioClip(8);
        }
        else
        {
            player.playAudioClip(4);
            result.text = "恭喜獲得 " + btn.name + " 元";
        }
        UpdateState();

        options.ForEach(delegate (Button b)
        {
            b.onClick.RemoveAllListeners();
        });
        //Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(Delay(1.5f));
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        dialogeBox.resetDialogeBox();
        //Cursor.lockState = CursorLockMode.None;
        options.ForEach(delegate (Button b)
        {
            b.onClick.AddListener(() => OnClick(b));
        });
        result.text = "";
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            options[i].image.sprite = coverCard[i];
        }

    }
}

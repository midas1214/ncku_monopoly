using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

using UnityEngine.UI;
using TMPro;
using System;

public class selectCardUi : MonoBehaviour
{
    [SerializeField] private List<Button> options;
    [SerializeField] public TextMeshProUGUI result;
    [SerializeField] private Dialoge dialogeBox;
    [SerializeField] private PlayerControl player;
    List<int> resultList;
    private List<int> addMoney = new List<int>() { 1000, 3000, 6000, 0 };
    private List<int> cutMoney = new List<int>() { -1000, -2000, -500, -1500 };

    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
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
        result.text = "";
    }

    void UpdateState()
    {
        player.moneyText.text = player.money.ToString();
    }

    private void OnClick(Button btn)
    {
       btn.GetComponentInChildren<TextMeshProUGUI>().text = btn.name;
        player.money += Int16.Parse(btn.name);

        if (Int16.Parse(btn.name) < 0)
        {
            result.text = "損失 " + btn.name +" 元";
        }
        else
        {
            result.text = "恭喜獲得 " + btn.name + " 元";
        }
        UpdateState();
        

        StartCoroutine(Delay(1.5f));
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        dialogeBox.resetDialogeBox();
        result.text = "";
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

    }
}

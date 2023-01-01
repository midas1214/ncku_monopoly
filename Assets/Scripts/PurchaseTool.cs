using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseTool : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI cheat;
    [SerializeField] public TextMeshProUGUI dice;
    [SerializeField] public TextMeshProUGUI tainan;
    [SerializeField] public TextMeshProUGUI cheatC;
    [SerializeField] public TextMeshProUGUI diceC;
    [SerializeField] public TextMeshProUGUI tainanC;
    [SerializeField] public TextMeshProUGUI info;

    [SerializeField] private List<Button> options;

   [SerializeField]
    private PlayerControl player;

    public int cheatCost;
    public int diceCost;
    public int tainanCost;


    // Start is called before the first frame update
    void Start()
    {
        cheat.text = cheatCost.ToString() + " 元";
        dice.text = diceCost.ToString() + " 元";
        tainan.text = tainanCost.ToString() + " 元";
        UpdateState();
    }

    void UpdateState()
    {
        cheatC.text = "目前持有 " + player.cheat.ToString() + " 個";
        diceC.text = "目前持有 " + player.diceControl.ToString() + " 個";
        tainanC.text = "目前持有 " + player.tainanCredit.ToString() + " 個";
        player.GetComponent<QuizManager>().UpdateState();
    }

    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClick(localButton));
        }
    }

    private void OnClick(Button btn)
    {
        if (btn.name == "purchase0")
        {
            if (player.money-cheatCost < 0)
            {
                info.text = "金額不足";
            }
            else
            {
                info.text = "購買 小雞上工 成功";
                player.money -= cheatCost;
                player.cheat++;
                player.ShowMoneyCreditChange(-cheatCost,"money");
            }
        }
        else if (btn.name == "purchase1")
        {
            if (player.money - diceCost < 0)
            {
                info.text = "金額不足";

            }
            else
            {
                info.text = "購買 骰子計數器 成功";
                player.money -= diceCost;
                player.diceControl++;

                player.ShowMoneyCreditChange(-diceCost, "money");
            }

        }
        else if (btn.name == "purchase2")
        {
            if (player.money - tainanCost < 0)
            {
                info.text = "金額不足";
            }
            if (player.tainanCredit != 0)
            {
                info.text = "該學分已修畢，不得再購買";
                player.GetComponent<BackpackManager>().tainan.text = "已修畢";
            }
            else
            {
                player.playAudioClip(7);
                info.text = "購買 踏溯台南學分 成功";
                player.money -= tainanCost;
                player.tainanCredit++;
                player.ShowMoneyCreditChange(-tainanCost, "money");
                player.ShowMoneyCreditChange(+10, "credit");
            }
        }
        UpdateState() ;
        player.GetComponent<BackpackManager>().UpdateState();
    }
}

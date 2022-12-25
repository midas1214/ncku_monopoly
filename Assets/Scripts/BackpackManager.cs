using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackpackManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI cheat;
    [SerializeField] public TextMeshProUGUI dice;
    [SerializeField] public TextMeshProUGUI tainan;
    [SerializeField] public TextMeshProUGUI info;
    [SerializeField] public TextMeshProUGUI pickName;
    [SerializeField]
    private PlayerControl player;

    [SerializeField] private List<Button> options;  // 道具
    [SerializeField] private Button useTool; //裝備
    [SerializeField] private List<Sprite> tool;
    private int nowPick;
    [SerializeField] private Image nowTool;

    public GameObject backpack;

    // Start is called before the first frame update
    void Start()
    {
        UpdateState();
        nowTool.enabled = false; // 顯示圖片隱藏
       
    }

    public void UpdateState()
    {
        cheat.text = player.cheat.ToString() + " 個";
        dice.text = player.diceControl.ToString() + " 個";
        tainan.text = player.tainanCredit.ToString() + " 個";
        pickName.text = "小雞上工";
        info.text = "在答題時使用，將會提示正確答案";
        nowPick = 0;
    }
    public void finishUseTool()
    {
        nowTool.enabled = false;
    }
    
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClick(localButton));
        }
       
        useTool.onClick.AddListener(() => OnClick(useTool));

    }

    private void OnClick(Button btn)
    {
       if (btn.name == "Cheat")
        {
            pickName.text = "小雞上工";
            info.text = "在答題時使用，將會提示正確答案";
            nowPick = 0;
        }
        else if (btn.name == "DiceControl")
        {
            pickName.text = "骰子計數器";
            info.text = "擲骰子前使用，可以決定下次要走幾步";
            nowPick = 1;
        }
        else if (btn.name == "TainanCredit")
        {
            pickName.text = "踏溯台南學分";
            info.text = "為必修學分";
            nowPick = 2;
        }
       else if (btn.name == "Use")
        {
            if (nowPick == 0 && player.cheat !=0)
            { 
                nowTool.enabled = true;
                nowTool.sprite = tool[nowPick];
                player.cheat--;
                player.usingTool = true;
                player.nowUsingTool = nowPick;

                backpack.SetActive(false); UpdateState();
            }
            else if (nowPick == 1 && player.diceControl !=0)
            {

                nowTool.enabled = true;
                nowTool.sprite = tool[nowPick];
                player.diceControl--;
                player.usingTool = true;
                player.nowUsingTool = nowPick;

                backpack.SetActive(false); UpdateState();
            }
            else if (nowPick ==2 && player.tainanCredit !=0)
            {

                nowTool.enabled = true;
                nowTool.sprite = tool[nowPick];
                player.tainanCredit--;
                player.usingTool = true;
                player.nowUsingTool = nowPick;

                backpack.SetActive(false); UpdateState();
            }

           
            
        }
    }
}

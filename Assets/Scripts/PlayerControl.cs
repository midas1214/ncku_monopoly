using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private static GameObject player;

    public static int diceThrown = 0;
    public int nowEvent;
    public Dialoge dialoge; // dialoge 匡中的資訊

    public ChaDatabase chaDatabase; 

    public SpriteRenderer spriteRenderer; // 腳色的圖片
    public TextMeshProUGUI characterName; // 角色的名字
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI moneyText;
    private int nowPick = 0;  // 選到哪一個角色

    // 持有道具數量
    public int credit;
    public int money;
    public int cheat = 0;
    public int tainanCredit =0 ;
    public int diceControl =0 ;
    public bool usingTool = false; // 是否裝備道具
    public int nowUsingTool = 0;

    public static int playerStartPoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GameControl");
        player.GetComponent<MovePlayer>().moveallow = false;
        
        if (!PlayerPrefs.HasKey("nowPick"))
        {
            nowPick = 0;
        }
        else
        {
            load();
        }
        updateCha(nowPick);
    }
    private void updateCha(int select)
    {
        Character character = chaDatabase.GetCharacter(select);
        characterName.text = character.characterName;
        spriteRenderer.sprite = character.character;
        credit = character.credit;
        money = character.money;
        creditText.text = credit.ToString();
        moneyText.text = money.ToString();
    }
    private void load()
    {
        nowPick = PlayerPrefs.GetInt("nowPick");
    }

    int checkEvent(int pPoint)
    {
        int e = 0;
        if(pPoint == 1 || pPoint ==2 || pPoint == 7 || pPoint == 10 || pPoint == 15 || pPoint == 16 || pPoint == 24 || pPoint == 29 || pPoint == 30 || pPoint == 31 || pPoint == 36 || pPoint == 43)
        {
            // 通識
            e = 0;
        }
        else if (pPoint == 8 || pPoint == 9 || pPoint == 12 || pPoint == 17 || pPoint == 21 || pPoint == 22 || pPoint == 26 || pPoint == 27 || pPoint == 32 || pPoint == 33 || pPoint == 41 || pPoint == 42 || pPoint == 38 )
        {
            // 必選修
            e = 1;
        }
        else if (pPoint == 3 || pPoint == 14 || pPoint == 35)
        {
            // 機會
            e = 2;
        }
        else if (pPoint == 6 || pPoint == 23 || pPoint == 40)
        {
            // 命運
            e = 3;
        }
        else if (pPoint == 5 || pPoint == 13 || pPoint == 20 || pPoint == 28 || pPoint == 39)
        {
            // 扣錢
            e = 4;
        }
        else if (pPoint == 4 || pPoint == 11 || pPoint == 19 || pPoint == 34 || pPoint == 37 )
        {
            //加錢
            e = 5;
        }
        else if (pPoint == 18)
        {
            // 成大醫院
            e = 6;
        }
        else if (pPoint == 0)
        {
            // 起點
            e = 7;
        }
        else if (pPoint == 25)
        {
            // 商店
            e = 8;
        }
        return e;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<MovePlayer>().waypointIndex > playerStartPoint + diceThrown - player.GetComponent<MovePlayer>().nextLap * player.GetComponent<MovePlayer>().waypoints.Length) //走到指定點了
        {
            if (player.GetComponent<MovePlayer>().nextLap == 1) // 過一圈
            {
                player.GetComponent<MovePlayer>().nextLap = 0;
                money += 2000;
            }
            player.GetComponent<MovePlayer>().moveallow = false; //停止走路
            playerStartPoint = player.GetComponent<MovePlayer>().waypointIndex - 1;
            nowEvent = checkEvent(playerStartPoint);
            dialoge.GetComponent<Dialoge>().setDialoge(nowEvent);
        }
    }

    public static void MovePlayer()
    {
        player.GetComponent<MovePlayer>().moveallow = true;
    }
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    public TextMeshProUGUI changeCreditText;
    public TextMeshProUGUI changeMoneyText;
    public TextMeshProUGUI characterGradeText;
    private int nowPick = 0;  // 選到哪一個角色

    // 持有道具數量
    public int credit;
    public int money;
    public int cheat = 0;
    public int tainanCredit =0 ;
    public int diceControl =0 ;
    public bool usingTool = false; // 是否裝備道具
    public int nowUsingTool = 0;
    public int lapCount = 1; // 第幾圈

    public static int playerStartPoint = 0;

    // 音效
    [SerializeField] private List<AudioClip> audioclip;
    
    [SerializeField] private AudioSource audioll;

    [SerializeField]
    private Color add;
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
        tainanCredit = 0;
        diceControl = 0;
        usingTool = false; // 是否裝備道具
        nowUsingTool = 0;
        lapCount = 1; // 第幾圈
        playerStartPoint = 0;
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
        characterGradeText.text = "(大一)";
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
                lapCount ++;
                if (lapCount == 2)
                {
                    characterGradeText.text = "(大二)";
                }
                else if (lapCount == 3)
                {
                    characterGradeText.text = "(大三)";
                }
                else if (lapCount == 4)
                {
                    characterGradeText.text = "(大四)";
                }
                player.GetComponent<MovePlayer>().nextLap = 0;
            }
            player.GetComponent<MovePlayer>().moveallow = false; //停止走路
            playerStartPoint = player.GetComponent<MovePlayer>().waypointIndex - 1;
            nowEvent = checkEvent(playerStartPoint);
            dialoge.GetComponent<Dialoge>().setDialoge(nowEvent);
        }
        if ((player.GetComponent<MovePlayer>().waypointIndex == 26) && !player.GetComponent<MovePlayer>().allowPassShop) // shop
        {
            player.GetComponent<MovePlayer>().allowPassShop = true;
            player.GetComponent<MovePlayer>().moveallow = false; //停止走路
            playerStartPoint = player.GetComponent<MovePlayer>().waypointIndex - 1;
            nowEvent = checkEvent(playerStartPoint);
            dialoge.GetComponent<Dialoge>().setDialoge(nowEvent);
        }
        if ((player.GetComponent<MovePlayer>().waypointIndex == 1) && !player.GetComponent<MovePlayer>().allowPassGo) // shop
        {
            player.GetComponent<MovePlayer>().allowPassGo = true;
            player.GetComponent<MovePlayer>().moveallow = false; //停止走路
            playerStartPoint = player.GetComponent<MovePlayer>().waypointIndex - 1;
            nowEvent = checkEvent(playerStartPoint);
            dialoge.GetComponent<Dialoge>().setDialoge(nowEvent);
        }
        if (money < 0 || (lapCount == 5 && (credit < 128 || tainanCredit == 0))) // lose 
        {
            SceneManager.LoadScene(4);
        }
        else if (lapCount == 5 && credit >= 128)
        {
            SceneManager.LoadScene(3);
        }
    }

    public static void MovePlayer()
    {
        player.GetComponent<MovePlayer>().moveallow = true;
    }

    public void playAudioClip(int type)
    {
        audioll.PlayOneShot(audioclip[type]);
        // 0 : 答對
        // 1 : 錯誤
        // 2 : 加錢
        // 3 : 扣錢
        // 4 : 挖哭挖哭
        // 5 : 安尼雅驚訝
        // 6 : 約兒驚訝
        // 7 : 約兒讚美
        // 8 : 洛伊德吃驚
        // 9 : 安尼雅撒嬌
        // 10 : 羅伊德好
        // 11 : 約而讚美2
        // 12 : 安尼雅 椰
        // 13 : 收銀
    }

    public void ShowMoneyCreditChange(int change, string type)
    {

        switch(type)
        {
            case "money":
                if (change >= 0)
                {

                    changeMoneyText.color = add;
                    changeMoneyText.text = "+" + change.ToString();
                    StartCoroutine(Delay(changeMoneyText, 3f));
                }
                else
                {
                    changeMoneyText.color = Color.red;
                    changeMoneyText.text = change.ToString();
                    StartCoroutine(Delay(changeMoneyText, 3f));
                }
                break;
            case "credit":
                if (change >= 0)
                {
                   
                    changeCreditText.color = add;
                    changeCreditText.text = "+" + change.ToString();
                    StartCoroutine(Delay(changeCreditText, 3f));
                }
                else
                {
                    
                    changeCreditText.color = Color.red;
                    changeCreditText.text = change.ToString();
                    StartCoroutine(Delay(changeCreditText, 3f));
                }
                break;
        }
    }
    IEnumerator Delay(TextMeshProUGUI changeText, float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        changeText.text = "";
    }
}


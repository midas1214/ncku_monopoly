using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private static GameObject player;
    public static int diceThrown = 0;
    public int nowEvent;
    public Dialoge dialoge;
    
    public static int playerStartPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Unknown");
        player.GetComponent<MovePlayer>().moveallow = false;
    }

    int checkEvent(int pPoint)
    {
        int e = 0;
        if(pPoint == 1 || pPoint ==2 || pPoint == 7 || pPoint == 10 || pPoint == 15 || pPoint == 22 || pPoint == 27 || pPoint == 28 || pPoint == 29 || pPoint == 34 || pPoint == 39)
        {
            // 通識
            e = 0;
        }
        else if (pPoint == 8 || pPoint == 9 || pPoint == 12 || pPoint == 16 || pPoint == 20 || pPoint == 24 || pPoint == 25 || pPoint == 30 || pPoint == 31 || pPoint == 35 || pPoint == 38 )
        {
            // 必選修
            e = 1;
        }
        else if (pPoint == 3 || pPoint == 14 || pPoint == 33 )
        {
            // 機會
            e = 2;
        }
        else if (pPoint == 6 || pPoint == 21 || pPoint == 37)
        {
            // 命運
            e = 3;
        }
        else if (pPoint == 5 || pPoint == 13 || pPoint == 19 || pPoint == 26 || pPoint == 36)
        {
            // 扣錢
            e = 4;
        }
        else if (pPoint == 4 || pPoint == 11 || pPoint == 18 || pPoint == 32)
        {
            //加錢
            e = 5;
        }
        else if (pPoint == 17)
        {
            // 成大醫院
            e = 6;
        }
        else if (pPoint == 0)
        {
            // 起點
            e = 7;
        }
        else if (pPoint == 23)
        {
            // 商店
            e = 8;
        }
        return e;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<MovePlayer>().waypointIndex > playerStartPoint + diceThrown) //走到指定點了
        {
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

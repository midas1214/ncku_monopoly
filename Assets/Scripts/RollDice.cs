using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public Sprite[] diceSprite;
    private SpriteRenderer rend;
    public static bool coroutineAllow = true;
    public GameObject gameControl;
    public PlayerControl player;
    public GameObject ChooseDiceDialogBox;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = diceSprite[5];
        player = gameControl.GetComponent<PlayerControl>();
    }

    private void OnMouseDown()
    {
        if (coroutineAllow)
        {
            if (player.nowUsingTool == 1 && player.usingTool)
            {
                ChooseDiceDialogBox.SetActive(true);
            }
            else
            {
                StartCoroutine(RollTheDice());
            }
        }
    }
    public IEnumerator RollTheDice()
    {
        coroutineAllow = false;
        int randomSide = 0;
        for (int i = 0; i < 20; i++)
        {
            randomSide = Random.Range(0, 6);
            rend.sprite = diceSprite[randomSide];
            yield return new WaitForSeconds(0.05f);
        }
        PlayerControl.diceThrown = randomSide + 1;
        if (player.nowUsingTool == 1 && player.usingTool)
        {
            rend.sprite = diceSprite[ChooseDiceUi.numberChosen];
            PlayerControl.diceThrown = ChooseDiceUi.numberChosen + 1;
            player.usingTool = false;
            player.GetComponent<BackpackManager>().finishUseTool();
        }
        PlayerControl.MovePlayer();
    }
}

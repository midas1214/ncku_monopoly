using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    public Sprite[] diceSprite;
    private SpriteRenderer rend;
    public static bool coroutineAllow = true;
    public GameObject gameControl;
    public PlayerControl player;
    public GameObject ChooseDiceDialogBox;

    [SerializeField] private Button dice;
    // Start is called before the first frame update
    void Start()
    {
        coroutineAllow = true;
        rend = GetComponent<SpriteRenderer>();
        dice.image.sprite = diceSprite[5];
        player = gameControl.GetComponent<PlayerControl>();
    }

    void Awake()
    {
        dice.onClick.AddListener(() => OnClick(dice)); 
    }

    private void OnClick(Button btn)
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
            dice.image.sprite = diceSprite[randomSide];
            yield return new WaitForSeconds(0.05f);
        }
        PlayerControl.diceThrown = randomSide + 1;
        if (player.nowUsingTool == 1 && player.usingTool)
        {
            dice.image.sprite = diceSprite[ChooseDiceUi.numberChosen];
            PlayerControl.diceThrown = ChooseDiceUi.numberChosen + 1;
            player.usingTool = false;
            player.GetComponent<BackpackManager>().finishUseTool();
        }
        PlayerControl.MovePlayer();
    }
}

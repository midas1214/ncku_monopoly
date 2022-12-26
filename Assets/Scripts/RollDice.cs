using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public Sprite[] diceSprite;
    private SpriteRenderer rend;
    public static bool coroutineAllow = true;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = diceSprite[5];
    }

    private void OnMouseDown()
    {
        if (coroutineAllow)
        {
            StartCoroutine("RollTheDice");
        }
    }
    private IEnumerator RollTheDice()
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
        PlayerControl.MovePlayer();
    }
}

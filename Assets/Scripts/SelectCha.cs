using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCha : MonoBehaviour
{
    public ChaDatabase chaDatabase;

    public TextMeshProUGUI nameText;

    public SpriteRenderer spriteRenderer;

    private int nowPick=0;

    // Start is called before the first frame update
    void Start()
    {
        updateCha(nowPick);
    }

    public void nextOption()
    {
        nowPick++;
        if (nowPick >= chaDatabase.characterCount)
        {
            nowPick = 0;
        }
        updateCha(nowPick);
    }
    public void backOption()
    {
        nowPick--;
        if (nowPick <= 0)
        {
            nowPick = chaDatabase.characterCount-1;
        }
        updateCha(nowPick);
    }

    private void updateCha(int select)
    {
        Character character = chaDatabase.GetCharacter(select);
        nameText.text = character.characterName;
        spriteRenderer.sprite = character.character;
    }
}

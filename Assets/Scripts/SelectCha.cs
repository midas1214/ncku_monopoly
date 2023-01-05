using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectCha : MonoBehaviour
{
    public ChaDatabase chaDatabase;
    public AudioSource Audio;

    public TextMeshProUGUI nameText;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private List<AudioClip> clip;

    private int nowPick=0;

    // Start is called before the first frame update
    void Start()
    {
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

    void playChaClip(int type)
    {
        Audio.PlayOneShot(clip[type]);
    }

    public void nextOption()
    {
        nowPick++;
        if (nowPick >= chaDatabase.characterCount)
        {
            nowPick = 0;
        }
        Audio.Stop();
        playChaClip(nowPick);
        updateCha(nowPick);

        save();
    }
    public void backOption()
    {
        nowPick--;
        if (nowPick < 0)
        {
            nowPick = chaDatabase.characterCount-1;
        }

        Audio.Stop();
        playChaClip(nowPick);
        updateCha(nowPick);
        save();
    }

    private void updateCha(int select)
    {
        Character character = chaDatabase.GetCharacter(select);
        nameText.text = character.characterName;
        spriteRenderer.sprite = character.character;
    }

    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    private void load()
    {
        nowPick = PlayerPrefs.GetInt("nowPick");
    }

    private void save()
    {
        PlayerPrefs.SetInt("nowPick",nowPick);
    }
 }

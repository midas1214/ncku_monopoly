using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackpackButtonClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject backpack;
    public bool backpackShow = false;
    [SerializeField]
    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        //backpack = GameObject.Find("Backpack");
        backpack.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (backpackShow)
        {
            backpackShow = false;
            backpack.SetActive(false);
            player.GetComponent<BackpackManager>().UpdateState();
        }
        else
        {
            backpackShow = true;
            backpack.SetActive(backpackShow);

        }
    }
}

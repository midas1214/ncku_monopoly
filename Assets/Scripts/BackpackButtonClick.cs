using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackpackButtonClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject backpack;
    public bool backpackShow = false;
    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.Find("Backpack");
    }

    // Update is called once per frame
    void Update()
    {
        backpack.SetActive(backpackShow);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (backpackShow)
        {
            backpackShow = false;
        }
        else
        {
            backpackShow = true;
        }
    }
}

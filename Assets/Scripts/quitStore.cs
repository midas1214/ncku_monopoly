using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class quitStore : MonoBehaviour, IPointerClickHandler
{
    public GameObject shopBox;
    [SerializeField] public TextMeshProUGUI nowEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        shopBox.SetActive(false);
        nowEvent.text = "";
        RollDice.coroutineAllow = true;
    }
}

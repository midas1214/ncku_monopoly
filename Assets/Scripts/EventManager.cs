using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private EventUi eventUi;
    [SerializeField] private EventDataTable eventDataTable; // 機會命運共用資料
    private List<Event> events;
    private Event selectedEvent;
    [SerializeField]
    private PlayerControl player;


    // Start is called before the first frame update
    void Start()
    {
        events = eventDataTable._event;
    }
    public void SelectEvent()
    {
        int val = Random.Range(0, events.Count);
        selectedEvent = events[val];
        eventUi.SetEvent(selectedEvent);
        if (selectedEvent.eventType == EventType.Money)
        {
            player.money += selectedEvent.val;
        }
        else
        {
            player.credit += selectedEvent.val;
        }
        UpdateState();
    }
    void UpdateState()
    {
        player.creditText.text = player.credit.ToString();
        player.moneyText.text = player.money.ToString();
    }
}

[System.Serializable]
public class Event
{
    public string eventInfo;
    public int val; //金錢或學分的變量
    public EventType eventType;
}

[System.Serializable]
public enum EventType
{ 
    Money,
    Credit
}

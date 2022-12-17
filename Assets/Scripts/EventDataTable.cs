using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "EventData")]
public class EventDataTable : ScriptableObject
{
    public List<Event> _event;
}

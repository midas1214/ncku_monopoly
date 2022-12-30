using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI eventInfo;
    [SerializeField] private Dialoge dialogeBox;
    [SerializeField] private Button btn; // 確定鍵
    private Event _event;
    // Start is called before the first frame update
    void Start()
    {
        Button localButton = btn;
        localButton.onClick.AddListener(() => OnClick(localButton));
    }

    public void SetEvent(Event _event)
    {
        this._event= _event;
        eventInfo.text = _event.eventInfo;
    }

    private void OnClick(Button btn)
    {
        
        StartCoroutine(Delay(1f));
       
    }
    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        dialogeBox.resetDialogeBox();

    }


    // Update is called once per frame
    void Update()
    {


    }
}

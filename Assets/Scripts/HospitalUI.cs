using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HospitalUI : MonoBehaviour
{
    [SerializeField] private Button btn; // 確定鍵
    [SerializeField]
    private PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        Button localButton = btn;
        localButton.onClick.AddListener(() => OnClick(localButton));
    }

    private void OnClick(Button btn)
    {
        player.credit += 10;
        player.ShowMoneyCreditChange(10,"credit");
        player.GetComponent<QuizManager>().UpdateState();

        StartCoroutine(Delay(1f));

    }
    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        player.GetComponent<Dialoge>().resetDialogeBox();

    }

}

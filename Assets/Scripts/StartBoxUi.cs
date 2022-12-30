using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StartBoxUi : MonoBehaviour
{

    [SerializeField] private Button option;
    [SerializeField]
    private PlayerControl player;

    void Awake()
    {
        
        option.onClick.AddListener(() => OnClick(option));
        
    }
    private void OnClick(Button btn)
    {
        player.money += 3000;
        player.GetComponent<QuizManager>().UpdateState();
        StartCoroutine(Delay(1.5f));
        player.ShowMoneyCreditChange(3000, "money");
        
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        player.GetComponent<Dialoge>().resetDialogeBox();

    }
}

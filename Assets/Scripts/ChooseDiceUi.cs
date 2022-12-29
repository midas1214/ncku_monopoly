using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDiceUi : MonoBehaviour
{
    [SerializeField] private List<Button> options;
    [SerializeField] private GameObject dialogeBox;
    [SerializeField] private GameObject dice;
    public static int numberChosen = 0;
    private void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClick(localButton));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick(Button btn)
    {
        numberChosen = options.IndexOf(btn);
        dialogeBox.SetActive(false);
        StartCoroutine(dice.GetComponent<RollDice>().RollTheDice());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoge : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nowEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setDialoge(int e)
    {
        switch (e)
        {
            case 0:
                nowEvent.text = "通識";
                break;
            case 1:
                nowEvent.text = "必選修";
                break;
            case 2:
                nowEvent.text = "機會";
                break;
            case 3:
                nowEvent.text = "命運";
                break;
            case 4:
                nowEvent.text = "扣錢";
                break;
            case 5:
                nowEvent.text = "加錢";
                break;
            case 6:
                nowEvent.text = "成大醫院";
                break;
            case 7:
                nowEvent.text = "起點";
                break;
            case 8:
                nowEvent.text = "商店";
                break;


        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

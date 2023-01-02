using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        startBGM.Instance.gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }
}

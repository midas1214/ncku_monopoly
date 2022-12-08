using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class CameraZoom : MonoBehaviour , IPointerClickHandler

{
    public Camera Cam;
    public float zoomSpeed = 2;
    bool zoom = false;
    public TextMeshProUGUI text;
    private void Start()
    {
        Cam = Camera.main;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (zoom == false)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,3,zoomSpeed);
            text.text = "地圖放大";
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 1.6f, zoomSpeed);
            text.text = "地圖縮小";
        }
        zoom = !zoom;
    }

    
}

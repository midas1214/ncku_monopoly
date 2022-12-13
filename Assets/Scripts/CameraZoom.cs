using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class CameraZoom : MonoBehaviour , IPointerClickHandler

{
    public Camera mainCam;
    public Camera farCam;
    public GameObject cam1;
    public GameObject cam2;

    public Canvas cameraCanvas;

    public float zoomSpeed = 2;
    bool zoom = false;
    public TextMeshProUGUI text;
    private void Start()
    {
        mainCam = Camera.main;
        cameraCanvas = gameObject.GetComponentInParent<Canvas>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (zoom == false)
        {
            mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize,3,zoomSpeed);
            cam2.SetActive(true);
            cam1.SetActive(false);
            text.text = "地圖放大";
            cameraCanvas.worldCamera = farCam;
        }
        else
        {
            mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, 1.6f, zoomSpeed);
            cam2.SetActive(false);
            cam1.SetActive(true);
            text.text = "地圖縮小";
            cameraCanvas.worldCamera = mainCam;
        }
        zoom = !zoom;
    }

    
}

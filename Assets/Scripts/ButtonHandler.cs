using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    private DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private ZoomInObject[] zoomInObjects;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
    }

    public void OnRightClickArrow()
    {
       
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {

        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {
        
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage.State.normal;

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
        }
    }
}
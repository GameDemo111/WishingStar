using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject playerCameraObject;
    public GameObject globalCameraObject;
    public GameObject gridManager;
    private Camera playerCamera;
    private Camera globalCamera;
    public bool isGlobalView = false;


    void Start()
    {
        playerCamera = playerCameraObject.GetComponent<Camera>();
        globalCamera = globalCameraObject.GetComponent<Camera>();
        playerCameraObject.SetActive(true);
        globalCameraObject.SetActive(false);

        if (gridManager != null)
        {
            gridManager.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isGlobalView = !isGlobalView;
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (isGlobalView)
        {
            playerCameraObject.SetActive(false);
            globalCameraObject.SetActive(true);
            if (gridManager != null)
            {
                gridManager.SetActive(true);
            }
        }
        else
        {
            playerCameraObject.SetActive(true);
            globalCameraObject.SetActive(false);
            if (gridManager != null)
            {
                gridManager.SetActive(false);
            }
        }
    }
}

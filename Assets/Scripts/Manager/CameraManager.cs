using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{   public Camera playerCamera;
    public Camera globalCamera;
    public GameObject gridManager;

    private bool isGlobalView = false;

    void Start()
    {
        playerCamera.enabled = true;
        globalCamera.enabled = false;

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
            playerCamera.enabled = false;
            globalCamera.enabled = true;
            if (gridManager != null)
            {
                gridManager.SetActive(true);
            }
        }
        else
        {
            playerCamera.enabled = true;
            globalCamera.enabled = false;
            if (gridManager != null)
            {
                gridManager.SetActive(false);
            }
        }
    }
}

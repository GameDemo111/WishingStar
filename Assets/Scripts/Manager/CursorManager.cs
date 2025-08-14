using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    private bool isSelecting = false;
    private GameObject selectedObject = null;
    
    
    void Start()
    {

    }

    
    
    void Update()
    {
        Collider2D hit = objectAtMousePosition();

        if (Input.GetMouseButtonDown(0))
        {
            if (hit != null && hit.CompareTag("Interactive"))
            {
                GameObject clickedObj = hit.gameObject;

                if (selectedObject == null)
                {
                    // 第一次点击：选中
                    SelectObject(clickedObj);
                }
                else if (clickedObj != selectedObject)
                {
                    // 第二次点击另一个物体：交换位置
                    SwapPositions(selectedObject, clickedObj);
                    DeselectObject(); // 交换后取消选中
                }
                else
                {
                    // 点击自己：取消选中
                    DeselectObject();
                }
            }
            else
            {
                // 点击空白：取消选中
                DeselectObject();
            }
        }

        if (selectedObject != null)
        {
            // R键旋转
            if (Input.GetKeyDown(KeyCode.R))
            {
                selectedObject.transform.Rotate(0, 0, 90);
            }
            // 右键取消选中
            if (Input.GetMouseButtonDown(1))
            {
                DeselectObject();
            }
        }
    }

    #region 选中
    private void SelectObject(GameObject obj)
    {
        selectedObject = obj;
        obj.GetComponent<SpriteRenderer>().color = Color.red;
    }

    #endregion
    #region 取消选择
    private void DeselectObject()
    {
        if (selectedObject != null)
        {
            selectedObject.GetComponent<SpriteRenderer>().color = Color.white;
            selectedObject = null;
        }
    }

    #endregion
    #region 交换位置
    private void SwapPositions(GameObject a, GameObject b)
    {
        Vector3 temp = a.transform.position;
        a.transform.position = b.transform.position;
        b.transform.position = temp;
    }

    #endregion
    private Collider2D objectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public CameraManager cameraManager;
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //private bool isSelecting = false;
    private GameObject selectedObject = null;
    
    
    void Start()
    {

    }

    
    
    void Update()
    {
        Collider2D hit = objectAtMousePosition();
        // 先判断有没有主摄像机
        if (Camera.main == null)
        {
            Debug.LogError("场景里找不到 Tag 为 MainCamera 的摄像机！");
            return;
        }
        // Debug.Log($"鼠标世界坐标：{mouseWorldPos}  碰撞体：{(hit == null ? "无" : hit.name)}");

        if (cameraManager.isGlobalView)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit != null && hit.CompareTag("Puzzle"))
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
            // 右键取消选中
            if (Input.GetMouseButtonDown(1))
            {
                DeselectObject();
            }
            // if (selectedObject != null)
            // {
            //     // R键旋转
            //     if (Input.GetKeyDown(KeyCode.R))
            //     {
            //         selectedObject.transform.Rotate(0, 0, 90);
            //     }
            // }
        }
        
    }

    #region 选中
    private void SelectObject(GameObject obj)
    {
        selectedObject = obj;
        selectedObject.GetComponent<SpriteRenderer>().color = new Color( 1, 0, 0, 0.3f);;
    }

    #endregion
    #region 取消选择
    private void DeselectObject()
    {
        selectedObject.GetComponent<SpriteRenderer>().color = new Color( 1, 1, 1, 0.3f);
        if (selectedObject != null)
        {
            selectedObject = null;
        }
    }

    #endregion
    #region 交换位置
    private void SwapPositions(GameObject a, GameObject b)
    {
        //如果a和b的子物体没有Player
        if (a.GetComponentInChildren<PlayerManager>() == null && b.GetComponentInChildren<PlayerManager>() == null)
        {
            Vector3 temp = a.transform.position;
            a.transform.position = b.transform.position;
            b.transform.position = temp;
            a.GetComponent<SpriteRenderer>().color = new Color( 1, 1, 1, 0.3f);
            b.GetComponent<SpriteRenderer>().color = new Color( 1, 1, 1, 0.3f);
        }
        
        
    }

    #endregion
    
    //获取鼠标位置上的物体
    private Collider2D objectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}

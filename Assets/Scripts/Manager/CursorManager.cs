using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("引用")]
    [SerializeField] private CameraManager cameraManager;   // 拖到 Inspector

    [Header("配置")]
    [SerializeField] private Color selectedColor = new Color(1, 0, 0, 0.3f);
    [SerializeField] private Color normalColor  = new Color(1, 1, 1, 0.3f);

    private Camera MainCam => Camera.main;                  // 缓存写法，减少 Get 开销
    private Vector3 MouseWorldPos
    {
        get
        {
            if (MainCam == null)
            {
                Debug.LogError("场景里找不到 MainCamera！");
                return Vector3.zero;
            }
            return MainCam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private GameObject selectedObject;

    /* -------------------------------------------------------------------- */

    private void Update()
    {
        if (!cameraManager.isGlobalView) return;    // 早期返回，减少嵌套

        if (Input.GetMouseButtonDown(0)) HandleLeftClick();
        if (Input.GetMouseButtonDown(1)) HandleRightClick();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DeselectObject();
            return;
        }
    }

    /* ----------------------------  事件处理  ----------------------------- */

    private void HandleLeftClick()
    {
        Collider2D hit = Physics2D.OverlapPoint(MouseWorldPos);

        // 点击空白
        if (hit == null || !hit.CompareTag("Puzzle"))
        {
            DeselectObject();
            return;
        }

        GameObject clicked = hit.gameObject;

        // 第一次选中
        if (selectedObject == null)
        {
            SelectObject(clicked);
            return;
        }

        // 点自己
        if (clicked == selectedObject)
        {
            DeselectObject();
            return;
        }

        // 点另一个：交换
        SwapAndReset(selectedObject, clicked);
        DeselectObject();

        
    }

    private void HandleRightClick() => DeselectObject();

    /* ----------------------------  功能封装  ----------------------------- */

    private void SelectObject(GameObject obj)
    {
        selectedObject = obj;
        SetSpriteColor(obj, selectedColor);
    }

    private void DeselectObject()
    {
        if (selectedObject == null) return;
        SetSpriteColor(selectedObject, normalColor);
        selectedObject = null;
    }

    /// <summary>
    /// 交换位置，并把双方颜色恢复成默认
    /// </summary>
    private void SwapAndReset(GameObject a, GameObject b)
    {
        // 任何一方底下有 Player 就不允许交换
        if (a.GetComponentInChildren<PlayerManager>() != null ||
            b.GetComponentInChildren<PlayerManager>() != null)
            return;

        Vector3 tmp = a.transform.position;
        a.transform.position = b.transform.position;
        b.transform.position = tmp;

        SetSpriteColor(a, normalColor);
        SetSpriteColor(b, normalColor);
    }

    /* ----------------------------  工具方法  ----------------------------- */

    /// <summary>
    /// 安全地设置 SpriteRenderer 颜色
    /// </summary>
    private static void SetSpriteColor(GameObject go, Color color)
    {
        if (go == null) return;
        var sr = go.GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = color;
    }
}
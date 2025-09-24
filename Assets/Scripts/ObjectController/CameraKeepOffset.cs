using UnityEngine;

/// <summary>
/// 把脚本挂在 MainCamera 上（它是角色的子物体）。
/// 运行时无论角色怎样移动、旋转，相机都会保持在初始的*局部*位置与角度。
/// </summary>
[DisallowMultipleComponent]
public class CameraKeepOffset : MonoBehaviour
{
    [Tooltip("目标角色")]
    public Transform target; // 拖拽角色到这里

    [Tooltip("是否也锁定旋转")]
    public bool lockRotation = true;

    private Vector3 offset;
    private Quaternion initRot;

    public bool isLock = false;

    void Start()
    {
        isLock = true;
        // 记录初始偏移（世界坐标）
        offset = transform.position - target.position;
        initRot = transform.rotation;
    }

    private void LateUpdate()
    {
        if (isLock)
        {
            transform.position = target.position + offset;
            if (lockRotation)
            {
                transform.rotation = initRot;
            }
        }
    }
}
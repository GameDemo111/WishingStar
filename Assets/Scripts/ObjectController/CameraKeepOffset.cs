using UnityEngine;

/// <summary>
/// 把脚本挂在 MainCamera 上（它是角色的子物体）。
/// 运行时无论角色怎样移动、旋转，相机都会保持在初始的*局部*位置与角度。
/// </summary>
[DisallowMultipleComponent]
public class CameraKeepOffset : MonoBehaviour
{
    [Tooltip("是否也锁定旋转")]
    public bool lockRotation = true;

    private Vector3 initLocalPos;
    private Quaternion initLocalRot;
    public bool isLock = false;

    private void Awake()
    {
        isLock = true;
        // 记录一开始相对于父物体（角色）的局部坐标
        initLocalPos = transform.localPosition;
        initLocalRot = transform.localRotation;
    }

    private void LateUpdate()
    {
        if (isLock)
        {
            // 每帧把局部坐标写死，父级无论如何运动相机都纹丝不动
            transform.localPosition = initLocalPos;
            if (lockRotation)
                transform.localRotation = initLocalRot;
        }
        
    }
}
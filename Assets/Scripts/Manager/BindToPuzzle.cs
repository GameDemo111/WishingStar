using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToPuzzle : MonoBehaviour
{
    // 记录当前所在的拼图
    private Transform currentPuzzle;
    private Vector3 originalScale;   // 角色最初的世界缩放

    private void Awake()
    {
        originalScale = transform.lossyScale;
    }

    private void LateUpdate()
    {
        // 如果已经挂在某拼图下，强制保持原始大小
        if (currentPuzzle != null)
            transform.localScale = Vector3.Scale(
                originalScale,
                new Vector3(1f / currentPuzzle.lossyScale.x,
                            1f / currentPuzzle.lossyScale.y,
                            1f / currentPuzzle.lossyScale.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Puzzle")) return;

        if (currentPuzzle != null && currentPuzzle != other.transform)
            transform.SetParent(null, true);

        transform.SetParent(other.transform, true);
        currentPuzzle = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Puzzle") && other.transform == currentPuzzle)
        {
            transform.SetParent(null, true);
            currentPuzzle = null;
            transform.localScale = originalScale;   // 还原
        }
    }
}

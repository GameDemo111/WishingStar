using System.Collections;
using UnityEngine;

public class MapTutorials : MonoBehaviour
{
    [Tooltip("主摄像机")]
    public Camera mainCamera;

    [Tooltip("从当前位置到目标位置所需时间")]
    public float moveDuration = 1.2f;

    [Tooltip("移动曲线")]
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private bool isMoving = false;        // 防止重复进入
    private PlayerManager playerManager;
    private Vector3 startPos;

    private void Start()
    {
        startPos = mainCamera.transform.position;
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerManager.canMove = false;
            mainCamera.GetComponent<CameraKeepOffset>().isLock = false;
            
            Vector3 target = new Vector3(-9F, 0F, -10F);

            StartCoroutine(MoveCamera(target));

        }
    }

    private IEnumerator MoveCamera(Vector3 endPos)
    {
        isMoving = true;
        float timer = 0f;

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            float t = curve.Evaluate(timer / moveDuration);
            mainCamera.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
        mainCamera.transform.position = endPos;

        yield return new WaitForSeconds(1.5f);

        timer = 0f;
        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            float t = curve.Evaluate(timer / moveDuration);
            mainCamera.transform.position = Vector3.Lerp(endPos, startPos, t);
            yield return null;
        }
        mainCamera.transform.position = startPos;

        playerManager.canMove = true;
        mainCamera.GetComponent<CameraKeepOffset>().isLock = true;
        Destroy(gameObject);
    }
}
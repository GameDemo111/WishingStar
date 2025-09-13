using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject fadeObject;     // 淡出对象
    // public GameObject music;          // 背景音乐对象
    private AsyncOperation mainLoadOp; // Main 场景的异步加载句柄
    public string sceneName;          // 场景名

    void Awake()
    {
        fadeObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
        // DontDestroyOnLoad(music);
    }

    void Start()
    {
        if (string.IsNullOrWhiteSpace(sceneName))
            return;
        // 标题一出现就开始后台加载 Main
        StartCoroutine(PreloadMainScene());

    }

    // 提前异步加载 Main 场景
    private System.Collections.IEnumerator PreloadMainScene()
    {
        mainLoadOp = SceneManager.LoadSceneAsync(sceneName);
        mainLoadOp.allowSceneActivation = false;   // 不让它立刻切过去
        yield return mainLoadOp;                   // 等待加载完成（仍在后台）
    }

    // UI 按钮调用：真正开始游戏
    public void OnStartGame()
    {
        fadeObject.SetActive(true);          // 1. 立即黑屏

        // 2. 等 1 秒后再执行后面逻辑
        StartCoroutine(WaitThenLoad());
    }

    // UI 按钮调用：退出
    public void OnExit()
    {
        fadeObject.SetActive(true);
        StartCoroutine(WaitThenExit());
    }

    private IEnumerator WaitThenLoad()
    {
        yield return new WaitForSeconds(1f); // 3. 等待 1 秒

        if (mainLoadOp != null)
        {
            mainLoadOp.allowSceneActivation = true;  // 4a. 异步场景激活
        }
        else
        {
            SceneManager.LoadScene(sceneName);           // 4b. 同步加载兜底
        }
    }

    private IEnumerator WaitThenExit()
    {
        yield return new WaitForSeconds(1f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
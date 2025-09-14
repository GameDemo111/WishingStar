using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    public float target;
    public float current;
    public GameObject final;
    private bool isEnter;

    void Update()
    {
        CheckFinal();
    }

    private void CheckFinal()
    {
        if (current != target)
        {
            final.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            final.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("终点已打开");
            if (isEnter)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("NB");
                    SceneManager.LoadScene("关卡选择");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEnter = false;
        }
    }
}

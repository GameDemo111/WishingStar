using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float levelID;
    private bool isUnlocked;
    private bool isCompleted;
    // Start is called before the first frame update
    void Start()
    {
        if (levelID == 1)
        {
            isUnlocked = true;
        }
        else
        {
            isUnlocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked && isCompleted)
        {

        }
    }

    public void UnlockLevel()
    {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (levelManager.levelID == levelID++)
        {
            levelManager.isUnlocked = true;
        }

    }

    public void CompleteLevel()
    {
        isCompleted = true;
    }

    public void EnterLevel()
    {
        SceneManager.LoadScene(levelID.ToString());
    }
}

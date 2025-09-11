using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public GameObject[] objectsToActivate;
    private bool isEnter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            SetActive();
        }
        else
        {
            SetInactive();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    public void SetActive()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            //obj.GetComponent<>
        }
    }

    public void SetInactive()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class End : MonoBehaviour
{
    public Star star;
    private bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Judge();
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

    private void Judge()
    {
        if (isEnter)
        {
            if (star.collected) Debug.Log("You Win!");
            else Debug.Log("You don't have the star!");
        }
    }
}

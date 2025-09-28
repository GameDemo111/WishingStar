using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public FinalManager finalManager;
    private void Start()
    {
        finalManager = GameObject.Find("FinalManager").GetComponent<FinalManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finalManager.current += 1;
            Destroy(gameObject);
        }
    }
}

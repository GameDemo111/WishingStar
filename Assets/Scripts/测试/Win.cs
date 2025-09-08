using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<DoorManager>().currentState == DoorManager.DoorState.Normal)
            {
                Debug.Log("门关闭!");
            }
            else if (gameObject.GetComponent<DoorManager>().currentState == DoorManager.DoorState.happy)
            {
                Debug.Log("门开了! 你赢了");
            }
            
        }
    }
}

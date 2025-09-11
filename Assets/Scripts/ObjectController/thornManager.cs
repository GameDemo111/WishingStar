using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thornManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDie();
        }
    }
    public void PlayerDie()
    { }

}
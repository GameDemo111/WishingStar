using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    GameObject sprite;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {
        sprite.SetActive(true);
    }
    private void OMouseExit()
    {
        sprite.SetActive(false);
    }
}

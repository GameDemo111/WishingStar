using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;



public class ButtonToPlaneManager : MonoBehaviour
{
    public PlaneManager targetObject;
    public Emotion currentState = Emotion.Normal;
    public bool canBeTouch;

    private void Start()
    {

    }

    void Update()
    {
        if (canBeTouch)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (targetObject.currentState == PlaneManager.Emotion.Normal)
                {
                    targetObject.SetState(PlaneManager.Emotion.happy);
                    //targetObject.currentState = PlaneManager.Emotion.happy;
                }
                else
                {
                    targetObject.SetState(PlaneManager.Emotion.Normal);
                    //targetObject.currentState = PlaneManager.Emotion.Normal;
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBeTouch = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBeTouch = false;
        }
    }
}
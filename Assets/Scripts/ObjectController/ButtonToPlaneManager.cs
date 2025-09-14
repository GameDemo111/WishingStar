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
        canBeTouch = true;
    }

    void Update()
    {
        if (canBeTouch) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (targetObject.currentState == PlaneManager.Emotion.Normal)
                {
                    targetObject.currentState = PlaneManager.Emotion.happy;
                }
                else
                {
                    targetObject.currentState = PlaneManager.Emotion.Normal;
                }
                    
            }
        }
    }
}
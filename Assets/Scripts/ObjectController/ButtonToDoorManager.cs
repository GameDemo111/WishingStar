using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;



public class ButtonToDoorController : MonoBehaviour
{
    public DoorManager targetObject;
    public Emotion currentState = Emotion.Normal; 
    public float autoCloseDelay = 5f;

    public bool _isOpen= false;
    public bool isOpen
    {
        get { return _isOpen; }
        set
        {
            _isOpen = value;
            if (value)
            {
                ButtonOpen?.Invoke();
            }
            else
            {
                ButtonClose?.Invoke();
            }
        }
    }

    public bool CanBeTouch=false;

    public UnityEvent ButtonOpen;
    public UnityEvent ButtonClose;
    private float timer = 0f;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    void Update()
    {
        if (CanBeTouch) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                switch (currentState)
                {
                    case Emotion.Normal:
                        if (targetObject != null)
                        {
                            targetObject.ChangeDoor();
                            
                        }
                        break;
                    case Emotion.happy:
                        if (targetObject != null)
                        {
                            if (targetObject.isOpen != true)
                            {
                                targetObject.ChangeDoor();
                             }
                        }
                        break;
                    case Emotion.sad:
                        if (targetObject != null)
                        {
                            if (targetObject.isOpen != true)
                            {
                                targetObject.ChangeDoor();
                             }
                        }
                        timer = 0f;
                        break;
                }
            }
        }
        if (targetObject != null && targetObject.currentState == Emotion.Normal)
        {
            switch (currentState)
            {
                case Emotion.Normal:
                    break;
                case Emotion.sad:
                    if (targetObject.isOpen)
                    {
                        timer += Time.deltaTime;
                        if (timer >= autoCloseDelay)
                        {
                            timer = 0f;
                            targetObject.TryClose();
                        }
                    }
                    break;
                case Emotion.happy:
                    if (targetObject != null)
                        {
                            if (targetObject.isOpen != true)
                            {
                                targetObject.ChangeDoor();
                             }
                        }
                    break;
            }
        }else{
            if(currentState == Emotion.sad){
                if(isOpen){
                    timer += Time.deltaTime;
                    if (timer >= autoCloseDelay)
                    {
                        isOpen = false;
                        timer = 0f;
                        ButtonClose?.Invoke();
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanBeTouch = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanBeTouch = false;
        }
    }
}
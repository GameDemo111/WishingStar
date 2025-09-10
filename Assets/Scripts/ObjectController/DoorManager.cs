using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Emotion currentState;
    private Animator doorAnimator;
    private bool isOpen;
    private bool canOpen;
    private void Start()
    {
        isOpen = false;
        canOpen = true;
        doorAnimator = GetComponent<Animator>();
        UpdateDoorState();
    }
    private void UpdateDoorState()
    {
        switch (currentState)
        {
            case Emotion.Normal:
                HandleNormalState();
                break;
            case Emotion.happy:
                HandleHappyState();
                break;
            case Emotion.sad:
                HandleSadState();
                break;
            case Emotion.anger:
                HandleAngerState();
                break;
        }
    }
    private void HandleNormalState()
    {
        canOpen = true;
        CloseDoor();
    }

    private void HandleHappyState()
    {
        canOpen = true;
        OpenDoor();
    }

    private void HandleSadState()
    {
        canOpen = false;
    }
    private void HandleAngerState()
    {
    }
    public void SetDoorState(Emotion newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        UpdateDoorState();
    }
    // public void TryOpenDoor()
    // {
    //     if (currentState == DoorState.Normal)
    //     {
    //         if (isopen != true)
    //         {
    //             OpenDoor();
    //         }
    //     }
    //     if (currentState == DoorState.happy)
    //     {
    //         if (isopen != true)
    //         {
    //             OpenDoor();
    //         }
    //     }
    //     if (currentState == DoorState.sad)
    //     {
    //         return;
    //     }
    //     if (currentState == DoorState.anger)
    //     {
    //         if (isopen != true)
    //         {
    //             OpenDoor();
    //         }
    //     }
    // }
    private void OpenDoor()
    {
        if (canOpen)
        {
            isOpen = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("门已打开");
            //动画接口
        }
        
        
    }

    // public void TryCloseDoor()
    // {
    //     if (currentState == DoorState.Normal)
    //     {
    //         if (isopen != false)
    //         {
    //             CloseDoor();
    //         }
    //     }
    //     if (currentState == DoorState.happy)
    //     {
    //         return;
    //     }
    //     if (currentState == DoorState.sad)
    //     {
    //         if (isopen != false)
    //         {
    //             CloseDoor();
    //         }
    //     }
    //     if (currentState == DoorState.anger)
    //     {
    //         if (isopen != false)
    //         {
    //             CloseDoor();
    //         }
    //     }
    // }
    private void CloseDoor()
    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //动画接口
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EmotionZone emotionZone = collision.GetComponent<EmotionZone>();
        if (emotionZone != null)
        {
            if (emotionZone.currentState == Emotion.happy)
            {
                SetDoorState(Emotion.happy);
            }
            else if (emotionZone.currentState == Emotion.sad)
            {
                SetDoorState(Emotion.sad);
            }
            else if (emotionZone.currentState == Emotion.anger)
            {
                SetDoorState(Emotion.anger);
            }
            else
            {
                SetDoorState(Emotion.Normal);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetDoorState(Emotion.Normal);
    }
}
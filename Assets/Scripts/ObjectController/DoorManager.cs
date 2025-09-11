using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class DoorManager : MonoBehaviour
{
    public Emotion currentState;
    private Animator doorAnimator;
    public bool isOpen;
    private Coroutine closeCoroutine;
    public float delay = 2f;
    private void Start()
    {
        isOpen = false;
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
    }

    private void HandleHappyState()
    {
        TryOpen();
    }

    private void HandleSadState()
    {
        TryClose();
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
    public void TryOpen()
    {
        if (currentState == Emotion.Normal)
        {
            if (isOpen != true)
            {
                OpenDoor();
            }
        }
        if (currentState == Emotion.happy)
        {
            if (isOpen != true)
            {
                OpenDoor();
            }
        }
        if (currentState == Emotion.sad)
        {
            return;
        }
        if (currentState == Emotion.anger)
        {
            return;
        }
    }
    private IEnumerator DelayedClose()
    {
        yield return new WaitForSeconds(delay);
        CloseDoor();
    }
    public void OpenDoor()
    {
            isOpen = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log("门已打开");
            //动画接口


    }

    public void TryClose()
    {
        if (currentState == Emotion.Normal)
        {
            if (isOpen != false)
            {
                CloseDoor();
            }
        }
        if (currentState == Emotion.happy)
        {
            return;
        }
        if (currentState == Emotion.sad)
        {
            if (isOpen != false)
            {
                CloseDoor();
            }
        }
        if (currentState == Emotion.anger)
        {
            return;
        }
    }
    public void CloseDoor()
    {
        isOpen = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
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
    public void ChangeDoor()
    {
        if (isOpen)
        {
            TryClose();
        }
        else TryOpen();
    }
}
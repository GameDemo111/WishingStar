using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorState
    {
        Normal,
        happy,
        sad,
        anger
    }
    public DoorState currentState;
    public Vector3 Position;
    private Animator doorAnimator;
    private bool isopen;
    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        UpdateDoorState();
    }
    private void UpdateDoorState()
    {
        switch (currentState)
        {
            case DoorState.Normal:
                HandleNormalState();
                break;
            case DoorState.happy:
                HandlehappyState();
                break;
            case DoorState.sad:
                HandlesadState();
                break;
            case DoorState.anger:
                HandleangerState();
                break;
        }
    }
    private void HandleNormalState()
    {
    }

    private void HandlehappyState()
    {
    }

    private void HandlesadState()
    {
    }
    private void HandleangerState()
    {
    }
    public void SetDoorState(DoorState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        UpdateDoorState();
    }
    public void TryOpenDoor()
    {
        if (currentState == DoorState.Normal)
        {
            if (isopen != true)
            {
                OpenDoor();
            }
        }
        if (currentState == DoorState.happy)
        {
            if (isopen != true)
            {
                OpenDoor();
            }
        }
        if (currentState == DoorState.sad)
        {
            return;
        }
        if (currentState == DoorState.anger)
        {
            if (isopen != true)
            {
                OpenDoor();
            }
        }
    }
    private void OpenDoor()
    {
        isopen = true;
        //动画接口
    }

    public void TryCloseDoor()
    {
        if (currentState == DoorState.Normal)
        {
            if (isopen != false)
            {
                CloseDoor();
            }
        }
        if (currentState == DoorState.happy)
        {
            return;
        }
        if (currentState == DoorState.sad)
        {
            if (isopen != false)
            {
                CloseDoor();
            }
        }
        if (currentState == DoorState.anger)
        {
            if (isopen != false)
            {
                CloseDoor();
            }
        }
    }
    private void CloseDoor()
    {
        isopen = false;
        //动画接口
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Emotion currentState;
    private Vector3 originalPosition;
    private int currentWaypointIndex = 0;
    public Vector3[] waypoints;
    private Rigidbody2D rb;
    public float moveSpeed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void UpdateDoorState()
    {
        switch (currentState)
        {
            case Emotion.Normal:
                HandleNormalState();
                break;
            case Emotion.happy:
                HandlehappyState();
                break;
            case Emotion.sad:
                HandlesadState();
                break;
            case Emotion.anger:
                HandleangerState();
                break;
        }
    }
    private void HandleNormalState()
    {
    }

    private void HandlehappyState()
    {
        StartCoroutine(MovePlane());
    }

    private void HandlesadState()
    {
    }
    private void HandleangerState()
    {
    }

    private IEnumerator MovePlane()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            yield return null;
        }
    }
    
    
    public void SetDoorState(Emotion newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        UpdateDoorState();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlaneManager planeManager = collision.GetComponent<PlaneManager>();
        if (planeManager != null)
        {
            if (planeManager.currentState == PlaneManager.Emotion.happy)
            {
                SetDoorState(Emotion.happy);
            }
            else if (planeManager.currentState == PlaneManager.Emotion.sad)
            {
                SetDoorState(Emotion.sad);
            }
            else if (planeManager.currentState == PlaneManager.Emotion.anger)
            {
                SetDoorState(Emotion.anger);
            }
            else
            {
                SetDoorState(Emotion.Normal);
            }
        }

    }
}

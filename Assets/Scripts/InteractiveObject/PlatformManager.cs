using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public enum PlatformState
    {
        Normal,
        happy,
        sad,
        anger
    }

    public PlatformState currentState;
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
            case PlatformState.Normal:
                HandleNormalState();
                break;
            case PlatformState.happy:
                HandlehappyState();
                break;
            case PlatformState.sad:
                HandlesadState();
                break;
            case PlatformState.anger:
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
    
    
    public void SetDoorState(PlatformState newState)
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
            if (planeManager.currentState == PlaneManager.PlaneState.happy)
            {
                SetDoorState(PlatformState.happy);
            }
            else if (planeManager.currentState == PlaneManager.PlaneState.sad)
            {
                SetDoorState(PlatformState.sad);
            }
            else if (planeManager.currentState == PlaneManager.PlaneState.anger)
            {
                SetDoorState(PlatformState.anger);
            }
            else
            {
                SetDoorState(PlatformState.Normal);
            }
        }

    }
}

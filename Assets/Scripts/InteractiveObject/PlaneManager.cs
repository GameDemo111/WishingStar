using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class PlaneManager : MonoBehaviour
{
    public enum Emotion
    {
        Normal,
        happy,
        sad,
        anger
    }
    public Emotion currentState;
    public Vector3 Position;
    private Animator PlaneAnimator;
    // private Rigidbody2D rb;
    // private Vector3 originalPosition;
    // // private int currentWaypointIndex = 0;
    // public Vector3[] waypoints;
    public bool isFalling = false;
    private bool isMoving = false;
    public float moveSpeed = 2f;
    public float fallSpeed = 5f;
    public float delayBeforeFall = 2f;
    public float topThreshold = 0.7f;
    public UnityEvent StepOnPlatform;
    public UnityEvent LeavePlatform;
    // private void Start()
    // {
    //     PlaneAnimator = GetComponent<Animator>();

    //     // rb = GetComponent<Rigidbody2D>();
    //     // originalPosition = transform.position;
    //     // if (currentState == PlaneState.happy)
    //     // {
    //     //     StartCoroutine(MovePlane());
    //     // }
    //     UpdatePlaneState();
    // }
    // void Update()
    // {
    //     if (currentState == Emotion.Normal)
    //     {
    //         return;
    //     }
    //     else if (currentState == Emotion.happy && isMoving)
    //     {
    //         return;
    //     }
    //     else if (currentState == Emotion.sad && isFalling)
    //     {
    //         FallPlatform();
    //         return;
    //     }
    //     else if (currentState == Emotion.anger)
    //     {
    //     }
    // }
    // private void UpdatePlaneState()
    // {
    //     switch (currentState)
    //     {
    //         case Emotion.Normal:
    //             HandleNormalState();
    //             break;
    //         case Emotion.happy:
    //             HandlehappyState();
    //             break;
    //         case Emotion.sad:
    //             HandlesadState();
    //             break;
    //         case Emotion.anger:
    //             HandleangerState();
    //             break;
    //     }
    // }
    // private void HandleNormalState()
    // {
    // }

    // private void HandlehappyState()
    // {
    // }

    // private void HandlesadState()
    // {
    // }
    // private void HandleangerState()
    // {
    //     //生成刺预制体
    // }
    // public void SetPlaneState(Emotion newState)
    // {
    //     if (currentState == newState) return;
    //     currentState = newState;
    //     UpdatePlaneState();
    // }
    // private IEnumerator MovePlane()
    // {
    //     while (true)
    //     {
    //         transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], moveSpeed * Time.deltaTime);
    //         if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
    //         {
    //             currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    //         }
    //         yield return null;
    //     }
    // }
    // public void ResetPos()
    // {
    //     transform.position = originalPosition;
    //     currentWaypointIndex = 0;
    //     isFalling = false;
    //     rb.velocity = Vector2.zero;
    // }
    // private void FallPlatform()
    // {
    //     rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
    // }
    // private void StopFalling()
    // {
    //     isFalling = false;
    //     rb.velocity = Vector2.zero;
    //     transform.position = originalPosition;
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         foreach (ContactPoint2D contact in collision.contacts)
    //         {
    //             Vector3 normal = contact.normal;
    //             if (normal.y < -topThreshold)
    //             {
    //                 StepOnPlatform?.Invoke();

    //                 // For both Normal and Lift states, parent the player to the platform
    //                 if (currentState == PlaneState.Normal || currentState == PlaneState.happy)
    //                 {
    //                     collision.transform.SetParent(transform);
    //                 }

    //                 if (currentState == PlaneState.sad)
    //                 {
    //                     isFalling = true;
    //                     Invoke("StopFalling", delayBeforeFall);
    //                 }
    //                 else if (currentState == PlaneState.anger)
    //                 {
    //                     return;
    //                 }
    //             }
    //         }
    //     }
    // }
    
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         LeavePlatform?.Invoke();
            
    //         // For both Normal and Lift states, unparent the player when they leave
    //         if (currentState == PlaneState.Normal || currentState == PlaneState.happy)
    //         {
    //             collision.transform.SetParent(null);
    //         }
    //     }
    // }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [Header("移动相关")]
    public float moveMaxSpeed;//最大移动速度
    [Range(0f, 20f)]
    public float moveAcceleration;//移动加速度
    [Range(0f, 20f)]
    public float moveDecceleration;//移动减速度
    [Range(0, 1f)]
    public float airAccel;//在空中时加速度

    [Header("跳跃相关")]
    public float jumpForce;
    public float coyoteTime;//土狼时间
    [Header("攀爬相关")]
    public float climbSpeed = 0.5f;
    private bool canClimb;
    [Header("地面检测箱参数")]
    public Vector2 groundBoxSize;
    public Vector2 groundBoxOffset;

    [Header("状态")]
    public CameraManager cameraManager;

    private Vector2 moveInput;
    private Rigidbody2D rb2D;
    private float gravityScale;

    private float coyoteTimer;
    public bool canMove;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gravityScale = rb2D.gravityScale;
        canMove = true;
    }

    private void Update()
    {
        if (!cameraManager.isGlobalView && canMove)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Run();


            if (CheckGround())
            {

            }
            else
            {
                coyoteTimer -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CheckGround() || coyoteTimer > 0)
                {
                    Jump();
                    coyoteTimer = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Climb();
            }
        }

    }


    #region 移动
    private void Run()
    {
        float targetSpeed = moveInput.x * moveMaxSpeed;
        float acceleration;
        if (CheckGround())
        {
            if (Mathf.Abs(moveInput.x) > 0.01f)
            {
                acceleration = moveAcceleration;
            }
            else
            {
                acceleration = moveDecceleration;
            }
        }
        else
        {
            if (Mathf.Abs(moveInput.x) > 0.01f)
            {
                acceleration = moveAcceleration * airAccel;
            }
            else
            {
                acceleration = moveDecceleration * airAccel;
            }
        }
        float speedDif = targetSpeed - rb2D.velocity.x;
        rb2D.velocity += new Vector2(speedDif * acceleration * Time.fixedDeltaTime, 0);
    }

    #endregion
    #region 跳跃
    public void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        rb2D.velocity += Vector2.up * jumpForce;
    }

    #endregion
    #region 攀爬
    public void Climb()
    {
        if (canClimb)
        {
            rb2D.gravityScale = 0;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(Vector2.up * climbSpeed, ForceMode2D.Force);
        }
        
        
    }
    #endregion
    #region 地面检测
    public bool CheckGround()
    {
        return Physics2D.OverlapBox((Vector2)transform.position + groundBoxOffset, groundBoxSize, 0, LayerMask.GetMask("Ground"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((Vector2)transform.position + groundBoxOffset, groundBoxSize);
        Gizmos.color = Color.red;
    }
    #endregion

}
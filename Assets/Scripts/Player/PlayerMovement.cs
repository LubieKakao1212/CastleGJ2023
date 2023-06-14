using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsGrounded => groundCount > 0;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float airAcceleration;
    [SerializeField]
    private float topSpeed;

    [SerializeField]
    private float movementDeadzone;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private CoherenceMonoBridge sync;

    private int groundCount;

    private void FixedUpdate()
    {
        if (!enabled || !sync.isConnected)
        {
            return;
        }
        var input = InputManager.HorizontalInput;
        if (Mathf.Abs(input) < movementDeadzone)
        {
            return;
        }
        var targetVelocity = input * topSpeed;
        

        // 2, 10
        // -8
        //-2, -10
        // 8
        var speedDelta = (targetVelocity - rigid.velocity.x);
        var s = Mathf.Sign(speedDelta);
        //Prevents deceleration when both directions are the same and |target| velocity is less than |currentVelocity 
        if(s != Mathf.Sign(targetVelocity)) {
            return;
        }
        speedDelta = s * Mathf.Min(Mathf.Abs(speedDelta / Time.fixedDeltaTime), IsGrounded ? acceleration : airAcceleration);

        rigid.velocity += speedDelta * Time.fixedDeltaTime * Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        groundCount++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        groundCount--;
    }
}

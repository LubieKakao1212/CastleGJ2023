using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsGrounded => groundCount > 0;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float topSpeed;

    [SerializeField]
    private float movementDeadzone;

    [SerializeField]
    private Rigidbody2D rigid;

    private int groundCount;

    private void FixedUpdate()
    {
        var input = InputManager.HorizontalInput;
        if (Mathf.Abs(input) < movementDeadzone)
        {
            return;
        }
        var targetVelocity = input * topSpeed;

        var speedDelta = (targetVelocity - rigid.velocity.x);
        speedDelta = Mathf.Sign(speedDelta) * Mathf.Min(Mathf.Abs(speedDelta / Time.fixedDeltaTime), acceleration);

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

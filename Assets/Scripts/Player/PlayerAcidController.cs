using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerAcidController : MonoBehaviour
{
    [SerializeField]
    private float damagePeriod;

    [SerializeField]
    private PlayerHP hp;

    [SerializeField]
    private PlayerMovement movement;

    private int acidCount;

    private AutoTimeMachine damageMachine;

    private void Start()
    {
        damageMachine = new AutoTimeMachine(() => hp.DealDamage(1), damagePeriod);
    }

    public void FixedUpdate()
    {
        if (acidCount > 0 && movement.IsGrounded)
        {
            damageMachine.Forward(Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeCount(collision, 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeCount(collision, -1);
    }

    private void ChangeCount(Collider2D collider, int amount)
    {
        if (collider.CompareTag("Acid"))
        {
            acidCount += amount;
        }
    }
}

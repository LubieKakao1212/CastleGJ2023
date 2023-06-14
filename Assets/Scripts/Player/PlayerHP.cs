using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerHP : MonoBehaviour
{
    public event Action HpChanged;

    public float Ratio => hp / (float)maxHP;

    [SerializeField]
    private int hp;

    [SerializeField]
    private float regenCooldown;

    [SerializeField]
    private int regenAmount;

    private AutoTimeMachine machine;

    private int maxHP;

    private void Start()
    {
        this.maxHP = hp;
        machine = new AutoTimeMachine(() =>
        {
            hp += regenAmount;
            HpChanged?.Invoke();
        }, regenCooldown);
    }

    private void FixedUpdate()
    {
        machine.Forward(Time.fixedDeltaTime);
    }
    
    public void DealDamage(int damage)
    {
        hp -= damage;

        HpChanged?.Invoke();

        //resetTimer
        machine.Delay(regenCooldown);

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player dies");

        Destroy(this.gameObject);
    }
}

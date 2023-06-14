using Coherence.Toolkit;
using System;
using UnityEngine;
using Utils;

public class PlayerHP : MonoBehaviour
{
    [Sync]
    public int SyncHP
    {
        get => hp;
        set
        {
            hp = value;
            HpChanged?.Invoke();
        }
    }

    [Sync]
    public int SyncMaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }

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

            hp = Mathf.Min(hp, maxHP);

            HpChanged?.Invoke();
        }, regenCooldown);
    }

    private void FixedUpdate()
    {
        if(enabled)
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

        Destroy(gameObject);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private PlayerHP hp;

    [SerializeField]
    private Transform bar;

    void Start()
    {
        var s = bar.localScale.x;

        hp.HpChanged += () => bar.localScale = new Vector3(s * Mathf.Max(hp.Ratio, 0), bar.localScale.y, bar.localScale.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    // Update is called once per frame
    void Update()
    {
        var dir = InputManager.InputDirection(transform.position);
        Debug.DrawRay(transform.position, dir);
        gun.up = -dir;
    }
}

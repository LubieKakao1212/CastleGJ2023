using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Wall
{
    void Hit(RaycastHit2D hit, ShootingController shooter);
}

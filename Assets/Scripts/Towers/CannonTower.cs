using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    public float lineDelay;
    public Transform barrel;

    public override void Aim(Transform target)
    {
        barrel.LookAt(target);
    }

    public override void Fire(Transform target)
    {
        
    }


}

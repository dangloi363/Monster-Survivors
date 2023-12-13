using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    
    protected override void Start()
    {
        base.Start();
    }

    
    protected override void Attack()
    {
        base.Attack();
        GameObject spawKnife = Instantiate(prefab);
        spawKnife.transform.position = transform.position; // gan vi tri cung voi vat the co cha la player
        spawKnife.GetComponent<KnifeBehavior>().DirectionChecker(pm.lastMovedVector);
    }
}

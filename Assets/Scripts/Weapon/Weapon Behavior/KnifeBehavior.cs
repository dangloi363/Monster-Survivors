using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ProjectileWeaponBehaviour
{
    KnifeController kc;
    protected virtual void Start()
    {
        base.Start();
        kc = FindObjectOfType<KnifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime; //chuyen dong cua dao
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColletor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //check if other game ojbect has Icollecttble interface
        if(col.gameObject.TryGetComponent(out Icollectible collectible))
        {
            collectible.Collect();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColletor : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerColletor;
    public float pullSpeed;


    void Start()
    {
        player = FindObjectOfType<PlayerStats>();    
        playerColletor = GetComponent<CircleCollider2D>();  
    }

    void Update()
    {
        playerColletor.radius = player.CurrentMagnet;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //check if other game ojbect has Icollecttble interface
        if(col.gameObject.TryGetComponent(out Icollectible collectible))
        {
            //pulling animation
            //get the rb2d component on the item
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            //Vector2 point form the item to the player
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            //apply force to the item in the forceDirection with pullSpeed
            rb.AddForce(forceDirection * pullSpeed);

            collectible.Collect();
        }
    }
}

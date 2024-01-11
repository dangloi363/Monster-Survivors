using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats enemy;
    Transform player;
    SpriteRenderer sr;
   
    void Start()
    {
        enemy = GetComponent<EnemyStats>(); 
        player = FindObjectOfType<PlayerMovement>().transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, enemy.currentMoveSpeed*Time.deltaTime);
        
            
            SpriteDirectionChecker();
        
        
    }
    void SpriteDirectionChecker()
    {
        if (enemy.transform.position.x > player.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}



    

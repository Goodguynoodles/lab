using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed = 5.0f;
    
    public bool enemyActive;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce( lookDirection * speed);

        if (transform.position.y < 20)
        {
            Destroy(gameObject);
        }
        
       
    }


}

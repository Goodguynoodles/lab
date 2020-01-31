using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public float speed = 5.0f;
    public bool onground = true;
    public float jumpforce;
    public ParticleSystem explosionParticle;
    public ParticleSystem explosionParticle2;
    public int pointValue;
    private GameManager gamemanager;
    private gamesound _gamesound;



    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Main Camera");
        gamemanager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardsInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardsInput);
        playerRB.AddForce(focalPoint.transform.right * speed * sideInput);
        
        if (Input.GetKeyDown(KeyCode.Space) && onground)
        {
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            onground = false;
            _gamesound.jump.Play();
        }
        if (transform.position.y < 20)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            gamemanager.gameover();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onground = true;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle2, transform.position, explosionParticle.transform.rotation);
            gamemanager.gameover();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            onground = true;
            gamemanager.finish();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            gamemanager.Updatescore(pointValue);
            
        }
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            onground = true;
            gamemanager.Updatescore(pointValue);
        }
       
    }

   
}

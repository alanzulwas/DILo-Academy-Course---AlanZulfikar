using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D rigidBody2D;
    private Vector2 trajectoryOrigin;

    public float xInitialForce;
    public float yInitialForce;
    
    private float speed = 10.0f; 

    void ResetBall(){
        transform.position = Vector2.zero; //ketengah
        rigidBody2D.velocity = Vector2.zero; //berhenti
    }

    void PushBall(){
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce); //random arah Y
        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f){
            rigidBody2D.velocity = new Vector2(-xInitialForce , yInitialForce );
        }
        else
        {
            rigidBody2D.velocity = new Vector2(-xInitialForce , yInitialForce );
        }
        rigidBody2D.velocity = rigidBody2D.velocity.normalized * speed;        
    }


    void RestartGame(){
        ResetBall();

        Invoke("PushBall",2);
    }

    void Start(){
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    private void OnCollisionExit2D(Collision2D other) {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get{ return trajectoryOrigin; }
    }
}

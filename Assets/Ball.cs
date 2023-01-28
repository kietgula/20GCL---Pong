using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{   
    public AudioPlayer audioPong;
    public float speed;
    Rigidbody2D rb;

    public UnityEvent onHitLeftGoal;
    public UnityEvent onHitRightGoal; 

    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //* this key value make desision to go left or right
        int key = Random.Range(0,2);

        if ( key == 0) //go right
        {
            float dirX = Random.Range(1.5f, 2f);
            float dirY = Random.Range(-1f, 1f);
            Vector2 beginVelocity = new Vector2(dirX,dirY);
            
            beginVelocity.Normalize();
            rb.velocity = beginVelocity*speed;
        }
        else if (key != 0) //go left
        {
            float dirX = Random.Range(-2f, -1.5f);
            float dirY = Random.Range(-1f, 1f);
            Vector2 beginVelocity = new Vector2(dirX,dirY);
            beginVelocity.Normalize();
            rb.velocity = beginVelocity*speed;

        }


    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + Time.deltaTime*0.1f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audioPong.playPong();

        if (collision.gameObject.name=="left goal")
        {
            onHitLeftGoal.Invoke();
        }
        else if (collision.gameObject.name=="right goal")
        {
            onHitRightGoal.Invoke();
        }
        else if (collision.gameObject.name=="left paddle")
        {
            //* this posOffset use for calculate how the ball should bounce out base on touched posision
            float posOffset = transform.position.y - collision.transform.position.y;

            rb.velocity = rb.velocity + new Vector2(1,0)*rb.velocity.magnitude*2 + new Vector2(0, posOffset)*5;

        }
        else if (collision.gameObject.name=="right paddle")
        {
            //* this posOffset use for calculate how the ball should bounce out base on touched posision
            float posOffset = transform.position.y - collision.transform.position.y;

            rb.velocity = rb.velocity + new Vector2(-1,0)*rb.velocity.magnitude*2 + new Vector2(0, posOffset)*5;
        }
        else if (collision.gameObject.name == "left goal")
        {

        }

        else if (collision.gameObject.name == "right goal")
        {

        }
        else if (collision.gameObject.name =="right")
        {
            rb.velocity = rb.velocity + new Vector2(-1,0)*rb.velocity.magnitude*2;
        }
        else if (collision.gameObject.name =="left")
        {
            rb.velocity = rb.velocity + new Vector2(1,0)*rb.velocity.magnitude*2;
        }
        else if (collision.gameObject.name =="top")
        {
            rb.velocity = rb.velocity + new Vector2(0,-1)*rb.velocity.magnitude*2;
        }
        else if (collision.gameObject.name =="bottom")
        {
            rb.velocity = rb.velocity + new Vector2(0,1)*rb.velocity.magnitude*2;
        }

        Vector2 tempVector = rb.velocity;
        tempVector.Normalize();
        rb.velocity=tempVector*speed;

    }


    
}

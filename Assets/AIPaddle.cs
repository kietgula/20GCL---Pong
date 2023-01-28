using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public GameObject ball;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y > transform.position.y)
            transform.Translate(0,speed*Time.deltaTime,0);
        else if (ball.transform.position.y < transform.position.y)
            transform.Translate(0,-speed*Time.deltaTime,0);
    }
}

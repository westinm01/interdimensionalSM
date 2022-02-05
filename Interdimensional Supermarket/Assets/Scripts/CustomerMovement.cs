using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{   
    public float moveFrequency; // How often the enemy moves
    // public float walkSpeed;     // How fast the enemy moves
    private Rigidbody2D rb;
    private float moveTimer;
    public virtual void move(){
        gameObject.transform.position += new Vector3(1,0);
    }

    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveTimer = 0;
    }

    void Update()
    {
        if (moveTimer > moveFrequency){
            move();
            moveTimer = 0;
        }
        else{
            moveTimer += Time.deltaTime;
        }
    }
}

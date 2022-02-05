using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{   
    public float moveSpeed;
    private float moveTimer;
    public virtual void move(){

    }

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer > moveSpeed){
            moveTimer = 0;
        }
    }
}

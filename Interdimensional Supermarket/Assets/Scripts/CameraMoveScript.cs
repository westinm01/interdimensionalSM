using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float minY;
    public float maxY;
    private Rigidbody2D rb;
    public void MoveCameraDown(){
        rb.velocity = new Vector2(0, -moveSpeed);
    }

    public void MoveCameraUp(){
        rb.velocity = new Vector2(0, moveSpeed);
    }

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (rb.velocity.y < 0){
            if (gameObject.transform.position.y <= minY){   // Freeze camera after reaching point
                rb.velocity = Vector2.zero;
            }
        }
        else if (rb.velocity.y > 0){
            if (gameObject.transform.position.y >= maxY){
                rb.velocity = Vector2.zero;
            }
        }
    }
}

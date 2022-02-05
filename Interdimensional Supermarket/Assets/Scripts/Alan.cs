using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alan : MonoBehaviour
{
    private Transform t;
    public bool isUp;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        t=gameObject.transform;
        anim=gameObject.GetComponent<Animator>();
        
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "Coin") {
            Destroy(target.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("up") && t.position.y<0){
            t.position+= new Vector3(0,1);
            isUp=true;
        }
        else if(Input.GetKeyDown("down")&& t.position.y>-1*StaticBoard.numRows+1){
            t.position+= new Vector3(0,-1);
            isUp=false;
        }
        else if(Input.GetKeyDown("right") && t.position.x<StaticBoard.numCols-1){
            t.position+= new Vector3(1,0);
        }
        else if(Input.GetKeyDown("left")&&t.position.x>0){
            t.position+= new Vector3(-1,0);
        }
        anim.SetBool("isUp",isUp);
    }
}

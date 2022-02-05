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

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("up")){
            t.position+= new Vector3(0,1);
            isUp=true;
        }
        else if(Input.GetKeyDown("down")){
            t.position+= new Vector3(0,-1);
            isUp=false;
        }
        else if(Input.GetKeyDown("right")){
            t.position+= new Vector3(1,0);
        }
        else if(Input.GetKeyDown("left")){
            t.position+= new Vector3(-1,0);
        }
        anim.SetBool("isUp",isUp);
    }
}

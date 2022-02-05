using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redmap;
    public GameObject bluemap;
    public GameObject yellowmap;
    //public GameObject cam;
    public Camera c;
    private int state;
    private float timer;
    void Start()
    {
        bluemap=gameObject.transform.GetChild(0).gameObject;
        redmap=gameObject.transform.GetChild(1).gameObject;
        yellowmap=gameObject.transform.GetChild(2).gameObject;
        /*GameObject[] objects = GameObject.FindGameObjectsWithTag("Main Camera");
        if(objects.length()>0){
            cam=objects[0];
            c=GetComponent<Camera>();
        }*/
        //c=GetComponent<Camera>();
        redmap.SetActive(false);
        yellowmap.SetActive(false);
        state=0;
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer==1000){
            timer=0;
            state=(state+1)%3;
            switch(state){
                case 0:
                    bluemap.SetActive(true);
                    redmap.SetActive(false);
                    yellowmap.SetActive(false);
                    //175,178,255,255
                    c.backgroundColor=new Vector4(175/255f,178/255f,1f,1f);
                    
                break;
                case 1:
                    bluemap.SetActive(false);
                    redmap.SetActive(true);
                    yellowmap.SetActive(false);
                    //255,160,129,255
                    c.backgroundColor=new Vector4(1f,160/255f,129/255f,1f);
                break;
                case 2:
                    bluemap.SetActive(false);
                    redmap.SetActive(false);
                    yellowmap.SetActive(true);
                    //238,255,170,255
                    c.backgroundColor=new Vector4(238/255f,1f,170/255f,1f);
                break;
            }
        }
    }
}

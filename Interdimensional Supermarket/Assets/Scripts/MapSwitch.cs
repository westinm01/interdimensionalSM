using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redmap;
    public GameObject bluemap;
    public GameObject yellowmap;
    private int state;
    private float timer;
    void Start()
    {
        bluemap=gameObject.transform.GetChild(0).gameObject;
        redmap=gameObject.transform.GetChild(1).gameObject;
        yellowmap=gameObject.transform.GetChild(2).gameObject;
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
                break;
                case 1:
                    bluemap.SetActive(false);
                    redmap.SetActive(true);
                    yellowmap.SetActive(false);
                break;
                case 2:
                    bluemap.SetActive(false);
                    redmap.SetActive(false);
                    yellowmap.SetActive(true);
                break;
            }
        }
    }
}

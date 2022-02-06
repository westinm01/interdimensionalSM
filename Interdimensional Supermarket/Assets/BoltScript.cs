using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : Powerup
{
    private AudioSource audio;

    void Awake() {
        audio = GameObject.FindGameObjectWithTag("BoltSound").GetComponent<AudioSource>();
    }

    public override void Use(){
        GameObject[] g = GameObject.FindGameObjectsWithTag("Customer");
        foreach(GameObject e in g) {
            e.transform.position = new Vector2(0, 0);
        }
        audio.Play();
        Destroy(this.gameObject);
      

    }
}

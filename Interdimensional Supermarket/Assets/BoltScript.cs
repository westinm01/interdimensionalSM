using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : Powerup
{
    public override void Use(){
        GameObject[] g = GameObject.FindGameObjectsWithTag("Customer");
        foreach(GameObject e in g) {
            e.transform.position = new Vector2(0, 0);
        }
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouponScript : Powerup
{
    public int uses;
    public override void Use(){
        GameObject alan = GameObject.FindGameObjectWithTag("Player");
        GameObject coin = GameObject.FindGameObjectWithTag("Coin");
        alan.transform.position = coin.transform.position;
        uses--;
        if (uses == 0){
            Destroy(this.gameObject);
        }
    }
}

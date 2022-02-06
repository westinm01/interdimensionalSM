using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public virtual void Use(){
        Destroy(this.gameObject);
    }
}

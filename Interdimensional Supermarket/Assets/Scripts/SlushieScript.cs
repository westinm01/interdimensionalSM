using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlushieScript : Powerup
{
    public EnemySpawner spawner;
    public override void Use(){
        spawner.FreezeEnemies();
        Destroy(this.gameObject);
    }
    
    void Update(){
        spawner = GameObject.FindGameObjectWithTag("EnemyChecker").GetComponent<EnemySpawner>();
    }
}

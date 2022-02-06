using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlushieScript : Powerup
{
    public EnemySpawner spawner;
    private AudioSource audio;

    void Awake() {
        audio = GameObject.FindGameObjectWithTag("slushSound").GetComponent<AudioSource>();
    }

    public override void Use(){
        spawner.FreezeEnemies();
        audio.Play();
        Destroy(this.gameObject);
    }
    
    void Update(){
        spawner = GameObject.FindGameObjectWithTag("EnemyChecker").GetComponent<EnemySpawner>();
    }
}

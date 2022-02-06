using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "Player") {
            GameObject.FindWithTag("Player");
            Alan.activeBolt = true;
            Debug.Log("BOLT ACTIVE");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

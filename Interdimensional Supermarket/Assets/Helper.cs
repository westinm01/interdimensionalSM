using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i")) {
            Instantiate(prefab, new Vector3(Random.Range(0, 10), 0, 0), Quaternion.identity);
        }
    }
}

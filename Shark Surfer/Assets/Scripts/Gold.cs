using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gold : MonoBehaviour
{

    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Shark")){
            Destroy(gameObject);
        }
    }
}

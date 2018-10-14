using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNextLvl : LevelController {
    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="Player")
        {
            other.GetComponent<PlayerController>().EndGame(true);
        }
    }
}

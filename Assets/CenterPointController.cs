using Assets.Scripts.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPointController : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.targetedEnemy.ToString())
        {
            other.GetComponent<EnemyController>().Target = null;
        }
    }
}

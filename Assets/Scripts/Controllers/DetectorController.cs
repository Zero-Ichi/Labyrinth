using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DetectorController : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private EnemyController parentEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            parentEnemy.Target = target.transform;
        }
    }

}

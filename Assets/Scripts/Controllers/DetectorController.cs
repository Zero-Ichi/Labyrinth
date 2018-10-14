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
        //Si le gameObject(other.gameObject) qui est rentré dans
        //collider est la target
        if (other.gameObject == target)
        {
            //Alors on revoit l'ennemi vers la target
            parentEnemy.Target = target.transform;
        }
    }

}

using Assets.Scripts.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TargetController : MonoBehaviour
{

    [SerializeField]
    private Transform NextTarget;

    //[SerializeField]
    //private EnemyController enemy;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.targetedEnemy.ToString())
        {
            other.GetComponent<EnemyController>().Target = NextTarget;
        }
    }
}

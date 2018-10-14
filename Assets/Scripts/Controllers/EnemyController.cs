using Assets.Scripts.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class EnemyController : ControllerBase
{
    //La target est modifier dans le script "TargetController"
    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    [SerializeField]
    private Transform target;

    private PlayerController player;
    private bool isEndGame = false;

    private void FixedUpdate()
    {
        if (!isEndGame)
        {
            if (target != null)
            {
                //Permet le déplacement entre "this.transform.position" (la position actuelle) et "target.position" (la position d'arrivé)
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, this.walkSpeed * Time.fixedDeltaTime);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si l'ennemi rentre en contact avec un gameobject qui a le tag player
        if (collision.collider.tag == Tags.Player.ToString())
        {
            //On récupere le player controller
            player = collision.collider.GetComponent<PlayerController>();
            //On met fin au jeu
            player.EndGame(false);
            isEndGame = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

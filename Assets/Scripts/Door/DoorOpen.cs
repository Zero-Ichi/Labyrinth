using Assets.Scripts.Config;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private Animator DoorAnimator;
    [SerializeField]
    private GameObject ExitPoint;
    [SerializeField]
    List<string> keyTagForOpen = new List<string>();

    private AudioController audioController;
    private bool isOpen;


    private void Awake()
    {
        audioController = this.GetComponent<AudioController>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Si le tag de l'objet est "Player"
        if (other.tag == Tags.Player.ToString())
        {
            if (!isOpen)
            {
                //Si il y a des clés a récuperer
                if (keyTagForOpen.Count > 1)
                {
                    //Récupere le script du player
                    PlayerController player = other.GetComponent<PlayerController>();
                    bool open = false;
                    //Cherche dans la liste 
                    foreach (string item in keyTagForOpen)
                    {
                        if (!string.IsNullOrEmpty(player.KeysTag.FirstOrDefault(x => x == item)))
                        {
                            open = true;
                        }
                        else
                        {
                            open = false;
                        }
                    }
                    if (open)
                    {
                        this.OpenTheDoor();
                    }
                    else
                    {
                        audioController.PlaySound("AccessDenied");
                    }
                }
                else
                {
                    this.OpenTheDoor();

                }
            }
        }
    }
    /// <summary>
    /// Ouvre la porte
    /// </summary>
    private void OpenTheDoor()
    {
        DoorAnimator.enabled = true;
        ExitPoint.SetActive(true);
        audioController.PlaySound("OpeningDoor");
        isOpen = true;
    }
}

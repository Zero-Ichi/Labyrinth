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
    List<GameObject> keysForOpen;


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
                if (keysForOpen.Count > 1)
                {
                    int count = 0;
                    //Cherche dans la liste
                    foreach (GameObject item in keysForOpen)
                    {
                        if (item == null)
                        {
                            count++;
                        }
                    }
                    if (keysForOpen.Count == count)
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

using Assets.Scripts.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : ControllerBase
{
    [SerializeField]
    private float mouseSensitivity = 100.0f;
    [SerializeField]
    private float clampAngle = 80.0f;
    [SerializeField]
    private GameObject EndGameUi;
    [SerializeField]
    private GameObject PauseMenu;

    public bool endGame { get; private set; }

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    public List<GameObject> Keys { get; set; }


    // Awake est appelé quand l'instance de script est chargée
    private void Awake()
    {
        endGame = false;
        Keys = new List<GameObject>();
        Cursor.visible = false;
        Time.timeScale = 1;
    }


    // Use this for initialization
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    private void Update()
    {
    }
    //Update is called once every 0.02 secondes
    void FixedUpdate()
    {


        if (!endGame)
        {
            #region move your body
            if (Input.GetKey(KeyCode.LeftShift))
                curentSpeed = runSpeed;
            else
                curentSpeed = walkSpeed;

            transform.Translate(Vector3.forward * curentSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
            transform.Translate(Vector3.right * curentSpeed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
            #endregion move your body

            #region Move your head
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.fixedDeltaTime;
            rotX += mouseY * mouseSensitivity * Time.fixedDeltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
            #endregion Move your head
        }

        //Si on appuie sur échappe on met en pause ou on coupe la pause
        //BUG : Une fois en pause le TimeScale étant à 0 l'appui suréchappe pour quitter le menu n'est pas détecté.
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else
            {
                StopPause();
            }
        }

        //this.MoveInput();
    }
    /// <summary>
    /// End pause
    /// </summary>
    public void StopPause()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    /// <summary>
    /// End game
    /// </summary>
    /// <param name="isVictory"></param>
    public void EndGame(bool isVictory)
    {
        endGame = true;
        Cursor.visible = true;

        EndGameUi.SetActive(true);
        TimerController timer = EndGameUi.GetComponentInParent<TimerController>();
        string txt;
        //Créer le message de fin
        if (isVictory)
        {
            txt = "you win in " + timer.GetFormatedTime();
        }
        else
        {
            txt = "you lose in " + timer.GetFormatedTime();
        }
        EndGameUi.transform.Find("TxtEndMessage").GetComponent<Text>().text = txt;


        //Enregistre dans le PlayerPrefs des valeurs : le temps pour le niveau actuel
        PlayerPrefs.SetString(PlayerPrefsKeys.timeLvl.ToString() + SceneManager.GetActiveScene().buildIndex.ToString(), timer.GetFormatedTime());

        //Enregistre dans le PlayerPrefs le niveau auquel il faut reprendre dans le "continue" du main menu
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Vérifie qu'il n'y est pas d'out of range
        if (sceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.continueLvl.ToString(), sceneIndex);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.continueLvl.ToString(), sceneIndex + 1);

        }


    }


    #region BOUHH DU CACA !!
    /// <summary>
    /// DU CACA, utiliser les Axes (Edit=> Project settings => input)
    /// </summary>
    protected void MoveInput()
    {
        //Forward
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log(Mouvement);
            this.Mouvement = Vector3.forward * walkSpeed;

        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            this.Mouvement = Vector3.right * walkSpeed;

        }

        //Back
        if (Input.GetKey(KeyCode.S))
        {
            this.Mouvement = Vector3.back * walkSpeed;

        }
        //left
        if (Input.GetKey(KeyCode.Q))
        {
            this.Mouvement = Vector3.left * walkSpeed;

        }
        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            this.Mouvement = Vector3.up * jumpSpeed;

        }
        //Assignation du vecteur de déplacement
        //"* Time.FixedDeltaTime" permet d'uniformiser la vitesse de 
        // déplacement en fonction des machines 
        //Si on etait dans la méthode "update" se serai : "Time.deltaTime"
        transform.Translate(this.Mouvement * Time.fixedDeltaTime);
        //remise a zero du vecteur de déplacement
        this.Mouvement = Vector3.zero;
    }
    protected Vector3 Mouvement = Vector3.zero;
    #endregion BOUHH DU CACA !!
}

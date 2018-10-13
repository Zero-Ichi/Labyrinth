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
        #region move your body
        if (Input.GetKey(KeyCode.LeftShift))
            curentSpeed = runSpeed;
        else
            curentSpeed = walkSpeed;

        if (!endGame)
        {

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

        }
        #endregion Move your head
        //this.MoveInput();
    }

    public void EndGame(bool isVictory)
    {
        endGame = true;
        Cursor.visible = true;

        EndGameUi.SetActive(true);
        TimerController timer = EndGameUi.GetComponentInParent<TimerController>();
        string txt;
        if (isVictory)
        {
            txt = "you win in " + timer.GetFormatedTime();
        }
        else
        {
            txt = "you lose in " + timer.GetFormatedTime();
        }
        PlayerPrefs.SetString(PlayerPrefsKeys.timeLvl.ToString() + SceneManager.GetActiveScene().buildIndex.ToString(), timer.GetFormatedTime());
        PlayerPrefs.SetInt(PlayerPrefsKeys.continueLvl.ToString(), SceneManager.GetActiveScene().buildIndex + 1);
        EndGameUi.transform.Find("TxtEndMessage").GetComponent<Text>().text = txt;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    [SerializeField]
    protected float walkSpeed = 1f;

    [SerializeField]
    protected float runSpeed = 1.5f;

    [SerializeField]
    protected float jumpSpeed = 1f;

    protected float curentSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

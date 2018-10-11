using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    Text txtTimer;

    private PlayerController player;

    private bool GameOver { get; set; }
    private int minutes = 0;
    private int passedTime = 0;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Use this for initialization
    void Start()
    {
        
        txtTimer.text = BuildTimerText();
        StartCoroutine(IncrementTime());
    }

    private IEnumerator IncrementTime()
    {
        if (!player.endGame)
        {
            yield return new WaitForSeconds(1f);
            txtTimer.text = BuildTimerText();
            passedTime++;
            StartCoroutine(IncrementTime());
        }

    }

    private string BuildTimerText()
    {
        if (passedTime >= 60)
        {
            minutes++;
            passedTime = 0;
        }
        return GetFormatedTime();
    }
    /// <summary>
    /// Return formated time (MM:SS)
    /// </summary>
    /// <returns></returns>
    public string GetFormatedTime()
    {
        return (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + ":" + (passedTime < 10 ? "0" + passedTime.ToString() : passedTime.ToString());
    }
}

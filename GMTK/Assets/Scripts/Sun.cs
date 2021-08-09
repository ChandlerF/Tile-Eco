using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sun : MonoBehaviour
{
    public float TurnBasedTimerMin;
    public float TurnBasedTimerMax;

    public float TimerMin;
    public float TimerMax;

    public float Timer;
    public float CurrentTimer;

    private float Percent;

    public Color StartColor;
    public Color EndColor;

    public bool TurnBased = true;

    //private Toggle TurnBaseToggle;

    void Start()
    {
        Timer = Mathf.RoundToInt(Random.Range(TimerMin, TimerMax));
        CurrentTimer = Timer;
/*
        TurnBaseToggle = GameObject.FindGameObjectWithTag("TurnBaseToggle").GetComponentInChildren<Toggle>();
        if (TurnBased) 
        { 
            TurnBaseToggle.isOn = true;
        }
        else
        {
            TurnBaseToggle.isOn = false;
        }*/
    }


    void Update()
    {
        Percent = CurrentTimer / Timer;

        //Debug.Log("Current Timer:" + CurrentTimer + " Devided by:" + Timer + " Equals:" + Percent);
        if (!TurnBased)
        {
            if (CurrentTimer > 0)
            {
                transform.GetComponent<SpriteRenderer>().color = Color.Lerp(StartColor, EndColor, 1 - Percent);
                CurrentTimer -= Time.deltaTime;
            }
        }

        transform.GetComponent<SpriteRenderer>().color = Color.Lerp(StartColor, EndColor, 1 - Percent);

        if(transform.GetComponent<SpriteRenderer>().color == EndColor)
        {
            DestroySun();
        }        
    }


    public void DestroySun()       //Sound FX, animation, etc.
    {
        GetComponent<Animator>().Play("Death");
    }

    public void MakeTurnBased()
    {
        if (!TurnBased)
        {
            TimerMin = TurnBasedTimerMin;   //6
            TimerMax = TurnBasedTimerMax;   //9
            CurrentTimer = ((TurnBasedTimerMax - TurnBasedTimerMin) / 2) + TurnBasedTimerMin;   //8
            Timer = ((TurnBasedTimerMax - TurnBasedTimerMin) / 2) + TurnBasedTimerMin;  //8


            GameObject[] Suns = GameObject.FindGameObjectsWithTag("Soundtrack");

            for (int x = -1; x < Suns.Length; x++)
            {
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased = true;
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().CurrentTimer = 8;
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().Timer = 8;
            }

            TurnBased = true;
        }
        else
        {
            TimerMin = 30;
            TimerMax = 50;
            CurrentTimer = 40;
            Timer = 40;


            GameObject[] Suns = GameObject.FindGameObjectsWithTag("Soundtrack");

            for (int x = -1; x < Suns.Length; x++)
            {
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased = false;
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().CurrentTimer = 40;
                GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().Timer = 40;
            }


            TurnBased = false;
        }
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float TimerMin;
    public float TimerMax;

    private float Timer;
    private float CurrentTimer;

    private float Percent;

    public Color StartColor;
    public Color EndColor;

    void Start()
    {
        Timer = Random.Range(TimerMin, TimerMax);
        CurrentTimer = Timer;
    }


    void Update()
    {
        Percent = CurrentTimer / Timer;


        if(CurrentTimer > 0)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.Lerp(StartColor, EndColor, 1 - Percent);
            CurrentTimer -= Time.deltaTime;
        }
        else
        {
            DestroySun();
        }
    }


    private void DestroySun()       //Sound FX, animation, etc.
    {
        Destroy(gameObject);
    }
}
*/
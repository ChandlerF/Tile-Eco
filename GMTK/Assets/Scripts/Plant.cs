using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool NextToWater = false;
    public int Points = 1;
    private Score ScoreScript;
    private bool AddedPoints = false;
    public Animator Anim;
    public GameObject PlusOne;

    [SerializeField]
    GameObject Icon;

    [SerializeField]
    Sprite Tree;

    [SerializeField]
    Color NewTileColor;

    void Start()
    {
        ScoreScript = GameObject.FindGameObjectWithTag("Menu").GetComponent<Score>();
        ScoreScript.CurrentScore += Points;
        Anim = transform.GetComponent<Animator>();
        Instantiate(PlusOne, transform.position, PlusOne.transform.rotation);
    }


    void Update()
    {
        if(NextToWater && !AddedPoints)
        {
            IsNextToWater();
        }
    }


    private void IsNextToWater()
    {
        //Change Score
        ScoreScript.CurrentScore += Points;

        //Start Animation
        Anim.SetBool("HasWater", true);

        //Plus Points Pop Up
        Instantiate(PlusOne, transform.position, PlusOne.transform.rotation);

        //Change Sprite to Tree
        Icon.GetComponent<SpriteRenderer>().sprite = Tree;

        //Change Tile's Color
        GetComponent<SpriteRenderer>().color = NewTileColor;

        //Set bool, so only runs once
        AddedPoints = true;
    }
}

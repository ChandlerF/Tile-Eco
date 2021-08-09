using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCheck : MonoBehaviour
{
    bool HasSpawnedTile = false;

    void Start()
    {
        Destroy(transform.gameObject, 0.3f);
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Sun") && !HasSpawnedTile && col.GetComponent<Sun>().CurrentTimer > 1)
        {
            //NextToWater = true;
            //Debug.LogError("I'm Next To Water");
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SettingTiles>().SpawnTile();
            HasSpawnedTile = true;
        }
    }
}



/*
 Click then move mouse fast away, spawns tile outside of suns range
 - Maybe moving it into FixedUpdate() or multiplying by Time.deltaTime -
 
 
 When placing many tiles fast, they can sometimes spawn 2 in the same area breaking the grid
 - Short term fix would be having any tiles that touch each other directly delete themselves -
 
 
 
 
 
 */
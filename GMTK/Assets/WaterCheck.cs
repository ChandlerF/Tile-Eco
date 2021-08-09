using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheck : MonoBehaviour
{
    
    bool HasSpawnedTile = false;

    void Start()
    {
        Destroy(transform.gameObject, 0.3f);
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        //Debug.LogError(col);
        if (!col.CompareTag("Sun"))     //Doesn't Properly Work?? so instead the player can place the water tile but it'll be burned up
        {
            if (col.CompareTag("Water") && !HasSpawnedTile)
            {
                GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SettingTiles>().SpawnTile();
                HasSpawnedTile = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCheck : MonoBehaviour
{
    bool HasSpawnedTile = false;

    void Start()
    {
        Destroy(transform.gameObject, 0.3f);
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Sun") && !HasSpawnedTile)
        {
            //NextToWater = true;
            //Debug.LogError("I'm Next To Water");
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<SettingTiles>().SpawnTile();
            HasSpawnedTile = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMountainsSpawn : MonoBehaviour
{
    private SpawnSourceBlocks SpawnTilesScript;
    private GameObject Mountain;
    private Grid Grid;
    void Start()
    {
        SpawnTilesScript = GameObject.FindGameObjectWithTag("Menu").GetComponent<SpawnSourceBlocks>();

        Mountain = SpawnTilesScript.Mountain;
        Grid = SpawnTilesScript.Grid;

        SpawnMountains();
    }

    private void SpawnMountains()
    {
        int Random1 = Random.Range(0, transform.childCount);
        int Random2;

        if (Random1 == 0)
        {
            Random2 = transform.childCount -1;
        }
        else
        {
            Random2 = Random1 - 1;
        }

        Vector3 Position1 = transform.GetChild(Random1).position;
        Vector3 Position2 = transform.GetChild(Random2).position;

        Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(Position1)), Mountain.transform.rotation);
        Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(Position2)), Mountain.transform.rotation);

        Destroy(gameObject);
    }
}

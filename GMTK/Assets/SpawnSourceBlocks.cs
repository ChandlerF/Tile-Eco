using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSourceBlocks : MonoBehaviour
{
    [SerializeField] GameObject SunSource;
    private Vector3 SunSpawn;

    [SerializeField] GameObject WaterSource;
    private Vector3 WaterSpawn;

    [SerializeField] float MinX;
    [SerializeField] float MaxX;

    [SerializeField] float MinY;
    [SerializeField] float MaxY;

    [SerializeField] Grid Grid;

    void Start()
    {
        GetSpawnLocation();
    }

    private void GetSpawnLocation()
    {
        SunSpawn = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        WaterSpawn = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));

        if (Mathf.Abs(SunSpawn.x - WaterSpawn.x) > 1.3 && Mathf.Abs(SunSpawn.y - WaterSpawn.y) > 1.3)       //distance between spawns is greater than 1.3
        {
            Instantiate(SunSource, Grid.GetCellCenterWorld(Grid.WorldToCell(SunSpawn)), SunSource.transform.rotation);

            Instantiate(WaterSource, Grid.GetCellCenterWorld(Grid.WorldToCell(WaterSpawn)), WaterSource.transform.rotation);
        }
        else 
        {
            GetSpawnLocation();
        }
    }
}

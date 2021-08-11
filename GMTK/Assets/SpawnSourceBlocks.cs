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

    public Grid Grid;

    public GameObject Mountain;
    private Vector3 MountainSpawn;

    [SerializeField] GameObject MountainSpawner;

    void Start()
    {
        GetSpawnLocation();
    }

    private void GetSpawnLocation()
    {
        SunSpawn = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        WaterSpawn = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));

        if (Mathf.Abs(SunSpawn.x - WaterSpawn.x) > 4 && Mathf.Abs(SunSpawn.y - WaterSpawn.y) > 2)       //distance between spawns is greater than 1.3
        {
            Instantiate(SunSource, Grid.GetCellCenterWorld(Grid.WorldToCell(SunSpawn)), SunSource.transform.rotation);

            Instantiate(WaterSource, Grid.GetCellCenterWorld(Grid.WorldToCell(WaterSpawn)), WaterSource.transform.rotation);




            //Mountain Spawn

            //Keep it as an obsticle that spawns in the middle until there's functionality for the mountain
            MountainSpawn = new Vector2((SunSpawn.x + WaterSpawn.x) / 2, (SunSpawn.y + WaterSpawn.y) / 2);

            Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(MountainSpawn)), Mountain.transform.rotation);
            Instantiate(MountainSpawner, Grid.GetCellCenterWorld(Grid.WorldToCell(MountainSpawn)), Mountain.transform.rotation);
        }


        else 
        {
            GetSpawnLocation();     //Inefficient, should place 1 spawn then base the other off that -------------------------------------------------
        }
    }
}
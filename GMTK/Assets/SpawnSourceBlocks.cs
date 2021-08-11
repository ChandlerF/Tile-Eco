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

    [SerializeField] GameObject Mountain;
    private Vector3 MountainSpawn;

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






            int FirstRandomNumber = Random.Range(-1, 1);
            int SecondRandomNumber = Random.Range(-1, 1);

            Vector2 SecondMountainCoordinates;
            Vector2 ThirdMountainCoordinates;

            if (FirstRandomNumber == 0 && SecondRandomNumber == 0)
            {
                SecondMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x, (int)Grid.WorldToCell(MountainSpawn).y + 1);

                ThirdMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x - 1, (int)Grid.WorldToCell(MountainSpawn).y);
                Debug.Log("If statement called");
            }
            else
            {

                SecondMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber, (int)Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber);                //MountainSpawn.x + FirstRandomNumber, MountainSpawn.y + SecondRandomNumber);


                ThirdMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x - FirstRandomNumber, (int)Grid.WorldToCell(MountainSpawn).y - SecondRandomNumber);

            }

            Debug.Log("---------");


            Debug.Log("FirstRandomNumber :" + FirstRandomNumber);
            Debug.Log("SecondRandomNumber :" + SecondRandomNumber);


            Debug.Log("Mountain 1 :" + Grid.WorldToCell(MountainSpawn));
            Debug.Log("Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates));
            Debug.Log("Mountain 3 :" + Grid.WorldToCell(ThirdMountainCoordinates));


            Debug.Log("FirstRandomNumber + Mountain 1 :" + Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber + " = " + (Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber));
            Debug.Log("SecondRandomNumber + Mountain 1 :" + Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber + " = " + (Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber));

            Debug.Log("FirstRandomNumber + Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates).x + FirstRandomNumber);
            Debug.Log("SecondRandomNumber + Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates).y + SecondRandomNumber);


            Debug.Log("---------");



            Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(SecondMountainCoordinates)), Mountain.transform.rotation);

            Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(ThirdMountainCoordinates)), Mountain.transform.rotation);

            /*Debug.Log(FirstRandomNumber);
            Debug.Log(SecondRandomNumber);*/
        }


        else 
        {
            GetSpawnLocation();     //Inefficient, should place 1 spawn then base the other off that -------------------------------------------------
        }
    }
}




/*
  
            int FirstRandomNumber = Random.Range(-1, 1);
            int SecondRandomNumber = Random.Range(-1, 1);

            Vector2 SecondMountainCoordinates;
            Vector2 ThirdMountainCoordinates;

            if (FirstRandomNumber == 0 && SecondRandomNumber == 0)
            {
                SecondMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x, (int)Grid.WorldToCell(MountainSpawn).y + 1);

                ThirdMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x - 1, (int)Grid.WorldToCell(MountainSpawn).y);
                Debug.Log("If statement called");
            }
            else
            {

                SecondMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber, (int)Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber);                //MountainSpawn.x + FirstRandomNumber, MountainSpawn.y + SecondRandomNumber);


                ThirdMountainCoordinates = new Vector2((int)Grid.WorldToCell(MountainSpawn).x - FirstRandomNumber, (int)Grid.WorldToCell(MountainSpawn).y - SecondRandomNumber);

            }

            Debug.Log("---------");


            Debug.Log("FirstRandomNumber :" + FirstRandomNumber);
            Debug.Log("SecondRandomNumber :" + SecondRandomNumber);


            Debug.Log("Mountain 1 :" + Grid.WorldToCell(MountainSpawn));
            Debug.Log("Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates));
            Debug.Log("Mountain 3 :" + Grid.WorldToCell(ThirdMountainCoordinates));


            Debug.Log("FirstRandomNumber + Mountain 1 :" + Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber + " = " + (Grid.WorldToCell(MountainSpawn).x + FirstRandomNumber));
            Debug.Log("SecondRandomNumber + Mountain 1 :" + Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber + " = " + (Grid.WorldToCell(MountainSpawn).y + SecondRandomNumber));

            Debug.Log("FirstRandomNumber + Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates).x + FirstRandomNumber);
            Debug.Log("SecondRandomNumber + Mountain 2 :" + Grid.WorldToCell(SecondMountainCoordinates).y + SecondRandomNumber);


            Debug.Log("---------");



            Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(SecondMountainCoordinates)), Mountain.transform.rotation);

            Instantiate(Mountain, Grid.GetCellCenterWorld(Grid.WorldToCell(ThirdMountainCoordinates)), Mountain.transform.rotation);

            /*Debug.Log(FirstRandomNumber);
            Debug.Log(SecondRandomNumber);*/

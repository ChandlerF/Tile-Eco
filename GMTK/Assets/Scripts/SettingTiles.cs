using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SettingTiles : MonoBehaviour
{
    public Grid Grid;

    public GameObject SelectedTile;

    public GameObject WaterTile;
    public GameObject SunTile;
    public GameObject PlantTile;

    public GameObject PlantCheckTile;
    public GameObject WaterCheckTile;
    public GameObject SunCheckTile;

    public GameObject HoveringOverObject;

    private CurrentTile CurrentTileScript;

    public bool InDeveloperMode = false;

    public Image SelectedTileImage;


    private void Start()        
    {
        CurrentTileScript = transform.GetComponent<CurrentTile>();
        SunTile.GetComponent<Sun>().TurnBased = true;
        SunTile.GetComponent<Sun>().TimerMin = SunTile.GetComponent<Sun>().TurnBasedTimerMin;
        SunTile.GetComponent<Sun>().TimerMax = SunTile.GetComponent<Sun>().TurnBasedTimerMax;

        GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased = true;

        GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TimerMin 
        = GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBasedTimerMin;

        GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TimerMax 
        = GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBasedTimerMax;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            if (!InDeveloperMode)
            {
                CurrentTileScript.enabled = false;
                InDeveloperMode = true;
            } 
            else if (InDeveloperMode)
            {
                CurrentTileScript.enabled = true;
                InDeveloperMode = false;
            }
        }

        if (InDeveloperMode)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SelectedTile = PlantTile;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SelectedTile = WaterTile;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SelectedTile = SunTile;
            }
        }
                                

        //Spawn Tiles

        if (Input.GetMouseButtonDown(0) && SelectedTile != null && Time.deltaTime != 0)        //Left click
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = Grid.WorldToCell(mouseWorldPos);


            RaycastHit2D hit = Physics2D.Raycast(Grid.GetCellCenterWorld(coordinate), Vector2.zero);

            if (hit.collider != null)
            {
                HoveringOverObject = hit.collider.gameObject;
            }
            else
            {
                HoveringOverObject = null;
            }

            if(SelectedTile == WaterTile)
            {
                Instantiate(WaterCheckTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);
            }
            else if(SelectedTile == SunTile)
            {
                Instantiate(SunCheckTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);
            }
            else
            {
                Instantiate(PlantCheckTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);
            }
        }


        //Delete Tiles

        if (Input.GetMouseButtonDown(1) && InDeveloperMode)        //Right click
        {

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = Grid.WorldToCell(mouseWorldPos);


            RaycastHit2D hit = Physics2D.Raycast(Grid.GetCellCenterWorld(coordinate), Vector2.zero);

            if (hit.collider != null)
            {
                HoveringOverObject = hit.collider.gameObject;
            }
            else
            {
                HoveringOverObject = null;
            }


            if (HoveringOverObject != null && HoveringOverObject.CompareTag("Sun"))
            {
                HoveringOverObject.GetComponent<Sun>().DestroySun();
            }
            
            else if(HoveringOverObject != null)
            {
                Destroy(HoveringOverObject);
            }
        }
    }




    public void SpawnTile()
    {

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = Grid.WorldToCell(mouseWorldPos);


        //Replacing a tile
        if (HoveringOverObject != null && !HoveringOverObject.CompareTag("Mountain"))
        {


            //If you have Not sun tile and replace a tile that's not the same as itself
            //Putting Water or grass on an existing tile
            if (SelectedTile != SunTile && !SelectedTile.CompareTag(HoveringOverObject.tag))
            {

                //Point Pop Up and changes Score
                if (HoveringOverObject.CompareTag("Plant"))
                {
                    HoveringOverObject.GetComponent<AnimDestroyGameObject>().PlantsDeath();
                }

                //Place Grass if sun has at least some life
                if (SelectedTile == PlantTile && HoveringOverObject.CompareTag("Sun"))
                {
                    if (HoveringOverObject.GetComponent<Sun>().CurrentTimer > 1)
                    {
                        //Destroy tile, place new one
                        Destroy(HoveringOverObject);
                        Instantiate(SelectedTile, Grid.GetCellCenterWorld(Grid.WorldToCell(HoveringOverObject.transform.position)), SelectedTile.transform.rotation);

                    }
                }
                else
                {

                    //Destroy tile, place new one
                    Destroy(HoveringOverObject);
                    Instantiate(SelectedTile, Grid.GetCellCenterWorld(Grid.WorldToCell(HoveringOverObject.transform.position)), SelectedTile.transform.rotation);

                }



                //Change a Sun's timer (new round)
                if (!InDeveloperMode)
                {

                    if (GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased)
                    {
                        GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().CurrentTimer -= 1;
                    }

                    SelectedTileImage.enabled = false;
                    SelectedTile = null;
                }

                //Timer to place / recieve New Tile
                CurrentTileScript.CurrentTimer = CurrentTileScript.Timer;
            }








            //If replacing a tile with a sun
            else if (SelectedTile == SunTile)
            {

                //Resetting Sun Tiles Timer; instead of replacing it (to not delete grass tiles when placed)
                if (HoveringOverObject.CompareTag("Sun") && HoveringOverObject.GetComponent<Sun>().CurrentTimer != HoveringOverObject.GetComponent<Sun>().TimerMax)
                {
                    HoveringOverObject.GetComponent<Sun>().CurrentTimer = HoveringOverObject.GetComponent<Sun>().TimerMax;
                }

                //Destroy tile, place new one
                else
                {
                    //Point Pop Up and changes Score
                    if (HoveringOverObject.CompareTag("Plant"))
                    {
                        HoveringOverObject.GetComponent<AnimDestroyGameObject>().PlantsDeath();
                    }

                    Destroy(HoveringOverObject);
                    Instantiate(SelectedTile, Grid.GetCellCenterWorld(Grid.WorldToCell(HoveringOverObject.transform.position)), SelectedTile.transform.rotation);
                }


                //Change a Sun's timer (new round)
                if (!InDeveloperMode)
                {

                    if (GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased)
                    {
                        GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().CurrentTimer -= 1;
                    }

                    SelectedTileImage.enabled = false;
                    SelectedTile = null;
                }

                //Timer to place / recieve New Tile
                CurrentTileScript.CurrentTimer = CurrentTileScript.Timer;
            }
        }







        //If placing a tile on an empty spot
        else if (HoveringOverObject == null)
        {
            Instantiate(SelectedTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);


            //Change a Sun's timer (new round)
            if (!InDeveloperMode)
            {

                if (GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().TurnBased)
                {
                    GameObject.FindGameObjectWithTag("Sun").GetComponent<Sun>().CurrentTimer -= 1;
                }

                SelectedTileImage.enabled = false;
                SelectedTile = null;
            }

            //Timer to place / recieve New Tile
            CurrentTileScript.CurrentTimer = CurrentTileScript.Timer;
        }
    }


    //StartCoroutine(CheckColliders(0.5f));
    /*
        IEnumerator CheckColliders(float x)
        {
            WaterTile.GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForSeconds(x);
            WaterTile.GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("Rawr");
        }*/
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SettingTiles : MonoBehaviour
{
    public Tilemap TileMap;

    private Tile SelectedTile;

    public Tile Water;
    public Tile Sun;
    public Tile Plant;

    public GameObject TestObject;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = TileMap.WorldToCell(mouseWorldPos);
            //Debug.Log(coordinate);
            TileMap.SetTile(coordinate, SelectedTile);
            Instantiate(TestObject, TileMap.layoutGrid.GetCellCenterWorld(coordinate), TestObject.transform.rotation);
        }
    }
}*/



/*          if (HoveringOverObject != null && !SelectedTile.CompareTag(HoveringOverObject.tag))
            {
                if(SelectedTile == WaterTile)
                {
                    if (SelectedTile == WaterTile)
                    {
                        Instantiate(WaterCheckTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);
                        /*if (CurrentWaterCheck.GetComponent<WaterCheck>().NextToWater)
                        {
                        
                            Destroy(HoveringOverObject);
                            SpawnTile();
                            Debug.Log("Spawned Next To Water");
                        }
                    }
                    //else
                    //{

                    Destroy(HoveringOverObject);
SpawnTile();
Debug.Log("Not A Water Tile");
                    //}
                }
            }
else if(HoveringOverObject == null)
            {
                if (SelectedTile == WaterTile)
                {
                    Instantiate(WaterCheckTile, Grid.GetCellCenterWorld(coordinate), SelectedTile.transform.rotation);
                    /*if (CurrentWaterCheck.GetComponent<WaterCheck>().NextToWater)
                    {
                        SpawnTile();
                        Debug.Log("Spawned Next To Water");
                    }
                }
                //else
                //{
                    SpawnTile();
Debug.Log("Not A Water Tile");
//}*/
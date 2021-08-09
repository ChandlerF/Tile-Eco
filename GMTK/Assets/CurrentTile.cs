using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTile : MonoBehaviour
{
    private SettingTiles SettingTilesScript;
    private int TileNumber;

    public float Timer;
    public float CurrentTimer;

    public bool CanPickNewTile = true;



    public Sprite PlantIcon;
    public Color PlantColor;

    public Sprite WaterIcon;
    public Color WaterColor;

    public Sprite SunIcon;
    public Color SunColor;

    public Image SelectedTileImage;

    void Start()
    {
        SettingTilesScript = transform.GetComponent<SettingTiles>();
        CurrentTimer = Timer;
    }

    void Update()
    {
        if (!SettingTilesScript.InDeveloperMode)
        {
            if (CurrentTimer > 0)
            {
                CurrentTimer -= Time.deltaTime;
                CanPickNewTile = true;
            }
            else if (CanPickNewTile)
            {
                NewSelectedTile();
                CanPickNewTile = false;
            }
        }


        /*if(SettingTilesScript.SelectedTile = null)
        {
            SelectedTileImage.color = new Color(SelectedTileImage.color.r, SelectedTileImage.color.g, SelectedTileImage.color.b, 0);
        }
        else
        {
            SelectedTileImage.color = new Color(SelectedTileImage.color.r, SelectedTileImage.color.g, SelectedTileImage.color.b, 255);
        }*/
    }

    private void NewSelectedTile()
    {
        SelectedTileImage.enabled = true;

        TileNumber = Random.Range(0, 5);
        if(TileNumber == 0 || TileNumber == 1)
        {
            SettingTilesScript.SelectedTile = SettingTilesScript.PlantTile;

            SelectedTileImage.sprite = PlantIcon;
            SelectedTileImage.color = PlantColor;
        } 
        else if (TileNumber == 2 || TileNumber == 3)
        {
            SettingTilesScript.SelectedTile = SettingTilesScript.WaterTile;

            SelectedTileImage.sprite = WaterIcon;
            SelectedTileImage.color = WaterColor;
        }
        else if (TileNumber == 4)
        {
            SettingTilesScript.SelectedTile = SettingTilesScript.SunTile;

            SelectedTileImage.sprite = SunIcon;
            SelectedTileImage.color = SunColor;
        }
    }
}

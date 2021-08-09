using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimDestroyGameObject : MonoBehaviour
{
    public void DestroyGameObject()
    {
        if (gameObject.CompareTag("Plant"))
        {
            PlantsDeath();
        }


        Destroy(gameObject);
    }






    public void PlantsDeath()
    {
        //Reference PointPopUp
        GameObject PointPopUp = GetComponent<Plant>().PlusOne;

        //Spawn It
        GameObject SpawnedPointPopUp = Instantiate(PointPopUp, transform.position, PointPopUp.transform.rotation);

        //Change Text and Color
        SpawnedPointPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-1";
        SpawnedPointPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.red;

        //Change Score
        GameObject.FindGameObjectWithTag("Menu").GetComponent<Score>().CurrentScore -= 1;
    }
}

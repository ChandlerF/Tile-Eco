using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Plant"))
        {
            //col.transform.GetComponent<SpriteRenderer>().color = Color.red;
            col.transform.GetComponent<Plant>().NextToWater = true;
        }
    }
}

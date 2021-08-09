using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextToSun : MonoBehaviour
{
    private bool CloseToSun = false;

    public List<GameObject> Suns = new List<GameObject>();

    [SerializeField] GameObject PointPopUp;



    void Update()
    {
        
        if (CloseToSun && Suns.Count == 0)      
        {
            transform.parent.GetComponent<Animator>().Play("Death");

            /*
            GameObject SpawnedPointPopUp = Instantiate(PointPopUp, transform.position, PointPopUp.transform.rotation);
            SpawnedPointPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-1";
            SpawnedPointPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.red;
            GameObject.FindGameObjectWithTag("Menu").GetComponent<Score>().CurrentScore -= 1;
            Destroy(transform.parent.gameObject);
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Sun") && !Suns.Contains(col.gameObject))
        {
            Suns.Add(col.gameObject);
            CloseToSun = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Sun"))
        {
            Suns.Remove(col.gameObject);
        }

    }
}




/*
 * 
        for (var i = Suns.Count - 1; i > -1; i--)
        {
            if (Suns[i] == null)
                Suns.RemoveAt(i);
        }
*/
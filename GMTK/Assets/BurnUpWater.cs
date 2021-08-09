using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnUpWater : MonoBehaviour
{
    public AudioSource Audio;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Water"))
        {
            Audio.Play();
            Destroy(col.gameObject);
        }
    }
}

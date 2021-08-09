using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int CurrentScore;
    public TMPro.TextMeshProUGUI TextUGUI;


    void Update()
    {
        TextUGUI.text = CurrentScore.ToString();
    }
}

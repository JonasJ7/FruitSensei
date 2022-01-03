using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject scoretext;
    public static float score = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
       // score += ;
        scoretext.GetComponent<Text>().text = score.ToString("F0");
    }
}

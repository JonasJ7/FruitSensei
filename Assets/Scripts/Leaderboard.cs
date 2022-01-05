using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Leaderboard : MonoBehaviour
{



    [SerializeField] GameObject prefab;
    public GameObject contentHolder, leaderboardHolder, submissionHolder;

    public List<GameObject> list = new List<GameObject>();

    public TMP_InputField name1, name2;

    //To Store Data In
    private int score;
    private string player1, player2;

    public void OnAddClick() {

        player1 = name1.text;
        player2 = name2.text;

        score = Random.Range(0, 5101);

        GameObject temp = Instantiate(prefab, contentHolder.transform);
        list.Add(temp);
        temp.GetComponent<ContentScript>()?.Setup(player1, player2, score);
        submissionHolder.SetActive(false);
        leaderboardHolder.SetActive(true);


        SaveContainer newContainer = new SaveContainer {
        position = 1,
        score = score,
        player1 = player1,
        player2 = player2,

        };

        string file = JsonUtility.ToJson(newContainer);
        SavingSystem.Save(file);
    }


}

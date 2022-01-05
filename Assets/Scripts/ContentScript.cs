using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContentScript : MonoBehaviour {

    public TextMeshProUGUI player1, player2;
    public TextMeshProUGUI score;




    public void Setup(string _player1, string _player2, int _score) {
        player1.text = _player1;
        player2.text = _player2;
        score.text = _score.ToString();
    }

}

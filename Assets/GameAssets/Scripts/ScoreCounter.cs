using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public GameObject bird;

    private Text cmpText;

	// Use this for initialization
	void Start () {
        cmpText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int score = bird.GetComponent<Bird>().score;

        cmpText.text = "Score: " + score.ToString();
	}
}

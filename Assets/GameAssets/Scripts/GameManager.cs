using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject bird;
    public GameObject pipeGenerator;

    void Awake() {
        pipeGenerator.SetActive(false);
        bird.GetComponent<Rigidbody>().isKinematic = true;
    }
	
	void Update () {
		/*if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        pipeGenerator.SetActive(true);
        bird.GetComponent<Rigidbody>().isKinematic = false;
    }
}

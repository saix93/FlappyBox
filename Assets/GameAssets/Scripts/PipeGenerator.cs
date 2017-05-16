using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {
    // Variables configurables desde editor
    public GameObject pipePrefab;
    public float distanceFromBird = 8;
    public float timeBetweenPipes = 1.5f;
    public float yDistance = 1;

    public GameObject bird;
    
	void Start () {
        // Se crea una invocación repetible de la función que genera tuberías
        InvokeRepeating("CreateNewPipe", 0, timeBetweenPipes);
    }

    /// <summary>
    /// Genera las tuberías
    /// </summary>
    private void CreateNewPipe()
    {
        // Si el pájaro no está vivo, deja de generar tuberías y termina la ejecución del invoke
        if (!bird.GetComponent<Bird>().isAlive)
        {
            CancelInvoke();
            // CancelInvoke("CreateNewPipe");
            return;
        }

        GameObject newPipe = Instantiate(pipePrefab);

        Vector3 birdPosition = bird.transform.position;
        Vector3 pipeGeneratorPosition = this.transform.position;

        float randomYDistance = Random.Range(-yDistance, yDistance);

        Vector3 pipePosition = new Vector3(
                birdPosition.x + distanceFromBird,
                pipeGeneratorPosition.y + randomYDistance,
                pipeGeneratorPosition.z
            );

        newPipe.transform.position = pipePosition;
    }
}

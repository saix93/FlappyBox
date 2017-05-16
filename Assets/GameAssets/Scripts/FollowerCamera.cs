using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour {
    public GameObject targetComponent;
    public float distanceFromTarget = 0;
	
    /// <summary>
    /// Hace que la cámara siga al jugador
    /// </summary>
	void Update () {
        Vector3 targetPosition = targetComponent.transform.position;
        Vector3 cameraPosition = this.transform.position;

        cameraPosition.x = targetPosition.x + distanceFromTarget;

        transform.position = cameraPosition;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {
    // Variables configurables
    // Fuerza de salto
    public float jumpForce = 300;
    // Velocidad de movimiento
    public float forwardSpeed = 1;
    // Limite del mapa por abajo
    public float deadYPositionLimit = -6;

    // Puntuacion
    public int score = 0;

    // Almacena si el objeto está vivo o muerto
    public bool isAlive = true;

    // Variables para los sonidos
    public AudioSource jumpAudio;
    public AudioSource scoreAudio;
    public AudioSource hitAudio;
    public AudioSource dieAudio;

    // Delay en el sonido de muerte
    public float dieAudioDelay = 1;

    // Referencia al Rigidbody del objeto
    private Rigidbody cmpRigidbody;


	void Start () {
        // Se guarda en la variable una referencia al componente Rigidbody
        cmpRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        // Se comprueba si el objeto ha bajado más de -6 en el eje Y
        if (transform.position.y < deadYPositionLimit)
        {
            // En este caso, se reinicia la escena
            // Se recupera el nombre de la escena
            string sceneName = SceneManager.GetActiveScene().name;
            // Se carga la misma escena en la que estamos
            SceneManager.LoadScene(sceneName);
        }

        // Si el objeto está vivo
        if (isAlive)
        {
            // Se modifica la velocidad de movimiento del objeto en el eje X
            Vector3 velocity = cmpRigidbody.velocity;
            velocity.x = forwardSpeed;
            cmpRigidbody.velocity = velocity;

            // Se captura la tecla espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Se modifica la velocidad del objeto para poner la velocidad del eje Y a 0
                ResetYAxisVelocity();

                // Se añade una fuerza hacia arriba multiplicada por la fuerza de salto
                cmpRigidbody.AddForce(Vector3.up * jumpForce);

                jumpAudio.Play();
            }
        }
	}

    /// <summary>
    /// Cuando el objeto colisiona con otro objeto
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        // El objeto ha muerto
        isAlive = false;
        // Se desactivan las colisiones
        GetComponent<BoxCollider>().enabled = false;

        // Se modifica la velocidad del objeto para poner la velocidad del eje Y a 0
        ResetYAxisVelocity();

        // Se añade una fuerza que mueve el objeto hacia arriba y atrás
        cmpRigidbody.AddForce(Vector3.up * jumpForce / 2 + Vector3.left * jumpForce / 2);

        // Se reproduce el sonido de golpe
        hitAudio.Play();

        // Se reproduce el sonido de muerte con delay de X segundos
        dieAudio.PlayDelayed(dieAudioDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se incrementa la puntuación y se reproduce el sonido de muerte
        score++;
        scoreAudio.Play();
    }

    /// <summary>
    /// Modifica la velocidad del objeto en el eje Y a 0
    /// </summary>
    private void ResetYAxisVelocity()
    {
        Vector3 velocity = cmpRigidbody.velocity;
        velocity.y = 0;
        cmpRigidbody.velocity = velocity;
    }
}

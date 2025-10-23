using UnityEngine;

//have coin rotate for the feels

public class CoinJuice : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Rotate 50 degrees per second around the Y-axis
    public float floatStrength = 0.5f; // How high the object floats
    public float floatSpeed = 1f;    // How fast the object floats
    public float speed;
    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update()
    {

        transform.Rotate(rotationSpeed * Time.deltaTime);


        //bobble effect?
        float newY = startPosition.y + (Mathf.Sin(Time.time * floatSpeed) * floatStrength);

        // Update the object's position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

    }
    
    // Collect coin
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

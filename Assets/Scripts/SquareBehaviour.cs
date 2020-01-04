using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // si le 
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name + " collision");
    }
    private void OnDestroy()
    {

    }
}

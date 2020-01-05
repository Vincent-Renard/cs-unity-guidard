using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;
    private GameObject treeTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        PickTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (treeTarget != null && gameObject.transform.position.y > treeTarget.transform.position.y) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, treeTarget.transform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("tree")) {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    void PickTree()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");
        if (trees.Length > 0) {
            treeTarget = trees[Random.Range(0, trees.Length)];
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {

    }
}

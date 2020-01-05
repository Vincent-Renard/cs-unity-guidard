using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    public Vector3 initialPosition;
    public GameObject circlePrefab;

    private Vector3 screenPoint;
    private Vector3 offset;

    // true when the rock is still attached to elastics
    private bool attached;
    private LineRenderer elastic;
    private SpringJoint2D springJoint1;
    private SpringJoint2D springJoint2;
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        elastic = GetComponent<LineRenderer>();
        SpringJoint2D[] springJoints = GetComponents<SpringJoint2D>();
        springJoint1 = springJoints[0];
        springJoint2 = springJoints[1];
        objectRenderer = GetComponent<Renderer>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached) {
            DrawElastic();
        }
        else {
            if (!objectRenderer.isVisible) {
                Instantiate(circlePrefab, initialPosition, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void Spawn()
    {
        springJoint1.enabled = true;
        springJoint2.enabled = true;
        DrawElastic();
        elastic.enabled = true;
        attached = true;
    }

    void DrawElastic()
    {
        elastic.SetPositions(new Vector3[] {
            springJoint1.connectedBody.position,
            gameObject.transform.position,
            springJoint2.connectedBody.position
        });
    }

    void OnMouseDown() {
        if (attached) {
		    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
	}

	void OnMouseDrag() {
        if (attached) {
		    Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		    Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		    transform.position = cursorPosition;
        }
	}

    void OnMouseUp() {
        springJoint1.enabled = false;
        springJoint2.enabled = false;
        elastic.enabled = false;
        attached = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!attached && collider.tag.Equals("enemy")) {
            Destroy(collider.gameObject);
        }
    }
}

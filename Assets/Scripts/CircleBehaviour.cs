using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    private Vector3 initialPosition;

    private Vector3 screenPoint;
    private Vector3 offset;

    // true when the rock is still attached to elastics
    private bool attached;
    private Rigidbody2D elastic1;
    private Rigidbody2D elastic2;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached) {
            // Draws first elastic
            elastic1.GetComponent<LineRenderer>().SetPositions(new Vector3[] {
                elastic1.position,
                gameObject.transform.position
            });
            // Draws second elastic
            elastic2.GetComponent<LineRenderer>().SetPositions(new Vector3[]{
                elastic2.position,
                gameObject.transform.position
            });
        }
    }

    void Spawn()
    {
        SpringJoint2D[] springJoints = GetComponents<SpringJoint2D>();

        foreach (SpringJoint2D component in springJoints) {
            component.enabled = true;
        }

        elastic1 = springJoints[0].connectedBody;
        elastic2 = springJoints[1].connectedBody;

        elastic1.GetComponent<LineRenderer>().enabled = true;
        elastic2.GetComponent<LineRenderer>().enabled = true;

        attached = true;

        gameObject.transform.position = initialPosition;
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
        foreach (SpringJoint2D component in GetComponents<SpringJoint2D>()) {
            component.enabled = false;
        }

        elastic1.GetComponent<LineRenderer>().enabled = false;
        elastic2.GetComponent<LineRenderer>().enabled = false;

        attached = false;
    }

    void OnBecameInvisible() {
        if (!attached) {
            Spawn();
        }
    }
}

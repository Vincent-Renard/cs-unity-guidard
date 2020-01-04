using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    // true when the rock is still attached to elastics
    private bool attached;

    // Start is called before the first frame update
    void Start()
    {
        attached = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (attached) {
            SpringJoint2D[] springJoints = GetComponents<SpringJoint2D>();
            Rigidbody2D connected1 = springJoints[0].connectedBody;
            Rigidbody2D connected2 = springJoints[1].connectedBody;

            // Draws first elastic
            connected1.GetComponent<LineRenderer>().SetPositions(new Vector3[] {
                connected1.position,
                gameObject.transform.position
            });
            // Draws second elastic
            connected2.GetComponent<LineRenderer>().SetPositions(new Vector3[]{
                connected2.position,
                gameObject.transform.position
            });
        }
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
        attached = false;
        foreach (SpringJoint2D component in GetComponents<SpringJoint2D>()) {
            Destroy(component);
        }
    }
}

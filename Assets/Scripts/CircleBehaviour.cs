using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

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
            var connected1 = GetComponents<SpringJoint2D>()[0].connectedBody;
            var connected2 = GetComponents<SpringJoint2D>()[1].connectedBody;
            connected1.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(connected1.position.x, connected1.position.y, 0), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0)});
            connected2.GetComponent<LineRenderer>().SetPositions(new Vector3[]{new Vector3(connected2.position.x, connected2.position.y, 0), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0)});
        }
    }

    void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

    void OnMouseUp() {
        attached = false;
        foreach (SpringJoint2D component in GetComponents<SpringJoint2D>()) {
            Destroy(component);
        }
    }
}

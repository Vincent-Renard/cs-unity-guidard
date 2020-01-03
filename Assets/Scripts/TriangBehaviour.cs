using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangBehaviour : MonoBehaviour
{
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

           pos = GetComponent<Transform>().position;
       }
     
    // Update is called once per frame
    void Update()
    {

           }
    private void OnTriggerEnter2D(Collider2D collider)
    {
           Vector3 [ ]oldLocationsOfSpawn ;
        Vector3[] newLocationsOfSpawn=new Vector3 [6];
        // oldLocationsOfSpawn = #####
        int i = 0;
        foreach(Vector3 v in oldLocationsOfSpawn)
        {
            if(pos.x == v.x)
            {
                newLocationsOfSpawn[i] = Vector3.zero;
                    }
            else
            {
                newLocationsOfSpawn[i] = v;
                    }
            i++;
          }
            SpawnSquare ss = new SpawnSquare();
        //ss.run(?)
        
    }


}

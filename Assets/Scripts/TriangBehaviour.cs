using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangBehaviour : MonoBehaviour
{
    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "tree";
        posX = GetComponent<Transform>().position.x;
       }

    // Update is called once per frame
    void Update()
    {

           }
    private void OnTriggerEnter2D(Collider2D collider)
    {



        if (collider.name.Equals("circle"))
        {

        }
        else
        {
            Debug.Log(posX+" is dead");
        }


        /*
         float [ ]oldLocationsOfSpawn ;
        float[] newLocationsOfSpawn=new float[6];
         oldLocationsOfSpawn = #####
         int i = 0;
        foreach(float p in oldLocationsOfSpawn)
        {
            if(posX == p)
            {
                newLocationsOfSpawn[i] = 0.0f;
                    }
            else
            {
                newLocationsOfSpawn[i] = p;
                    }
            i++;
          }
            SpawnSquare ss = new SpawnSquare();
        //ss.run(?)
        */
    }


}

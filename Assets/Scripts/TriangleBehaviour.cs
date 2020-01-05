using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriangleBehaviour : MonoBehaviour
{
    private static int nbTrees=6;
    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "tree";
        posX = GetComponent<Transform>().position.x;}

    // Update is called once per frame
    void Update()
    {

    }
   
    void OnDestroy()
    {
        nbTrees --;
        if (nbTrees == 0) {
            SceneManager.LoadScene("EndScene");
        }
    }
}

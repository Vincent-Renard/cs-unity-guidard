﻿using UnityEngine;

public class SpawnSquare : MonoBehaviour
{
    public GameObject squarePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(squarePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

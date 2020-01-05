using UnityEngine;

using System.Collections.Generic;

public class SpawnSquare : MonoBehaviour
{
    public GameObject squarePrefab;
    private Vector3 InitialPos;
    public int NTicks;
    public float SpawnLocation0;
    public float SpawnLocation1;
    public float SpawnLocation2;
    public float SpawnLocation3;
    public float SpawnLocation4;
    public float SpawnLocation5;
    private float[] locations;
    private List<int> activeSpawners;

    // Start is called before the first frame update
    void Start()
    {
        InitialPos.y = GetComponent<Transform>().position.y;
        InitialPos.z = GetComponent<Transform>().position.z;
        activeSpawners = new List<int>();
        Resync();
    }

    public void Resync()
    {
        activeSpawners.Clear();
        locations = new float[] { SpawnLocation0, SpawnLocation1, SpawnLocation2, SpawnLocation3, SpawnLocation4, SpawnLocation5 };
        int i = 0;
        foreach (float l in locations) {
            if (!Equals(l, 0.0f)) {
                activeSpawners.Add(i);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var size = activeSpawners.Count;
       int i =  Random.Range(0, size*NTicks);
        if (i < size)
        {
            Spawn(activeSpawners[i]);
        }
       
    }
   

    private void Spawn(int iSpawner) {
        
        GameObject square = Instantiate(squarePrefab, new Vector3(locations[iSpawner], InitialPos.y, InitialPos.z), Quaternion.identity);
        square.tag = "enemy";
    }
}

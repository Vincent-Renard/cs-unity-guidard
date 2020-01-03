using UnityEngine;

public class SpawnSquare : MonoBehaviour
{
    public GameObject squarePrefab;
    public float Nsec;
    public Vector3 SpawnLocation0;
    public Vector3 SpawnLocation1;
    public Vector3 SpawnLocation3;
    public Vector3 SpawnLocation4;
    private Vector3[] locations;
    // Start is called before the first frame update
    void Start()
    {
        locations = new Vector3[] { SpawnLocation0, SpawnLocation1, SpawnLocation3, SpawnLocation4 };
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (Vector3 l in locations)
        {

            if (l != Vector3.zero)
            {
                spawn(i);
            }
            i++;
        }
       
    }

    private void spawn(int i)
    {
        switch (i)
        {
            case 0:
                spw0();
                break;
            case 1:
                spw1();
                break;
            case 2:
                spw2();
                break;
            case 3:
                spw3();
                break;
        }
    }
    private void spw0()
    {
        Instantiate(squarePrefab, locations[0], Quaternion.identity);
    }
    private void spw1()
    {
        Instantiate(squarePrefab, locations[1], Quaternion.identity);
    }
    private void spw2()
    {
        Instantiate(squarePrefab, locations[2], Quaternion.identity);
    }
    private void spw3()
    {
        Instantiate(squarePrefab, locations[3], Quaternion.identity);
    }
}

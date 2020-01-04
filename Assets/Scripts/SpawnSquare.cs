using UnityEngine;

public class SpawnSquare : MonoBehaviour
{
    public GameObject squarePrefab;
    private Vector3 InitialPos;
    public float Nsec;
    public float SpawnLocation0;
    public float SpawnLocation1;
    public float SpawnLocation2;
    public float SpawnLocation3;
    public float SpawnLocation4;
    public float SpawnLocation5;
    private float[] locations;
    // Start is called before the first frame update
    void Start(){
        InitialPos.y = GetComponent<Transform>().position.y;
        InitialPos.z = GetComponent<Transform>().position.z;
        this.Resync();
            }

    public void Resync()
    {
        locations = new float[] { SpawnLocation0, SpawnLocation1, SpawnLocation2, SpawnLocation3, SpawnLocation4, SpawnLocation5 };
        int i = 0;
        foreach (float l in locations)
        {

            if (!Equals(l, 0.0f))
            {
                spawn(i);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void spawn(int i)   {
        switch (i)
        {
            case 0:
                InvokeRepeating("spw0",i,Nsec);
                break;
            case 1:
                InvokeRepeating("spw1", i, Nsec);
                break;
            case 2:
                InvokeRepeating("spw2", i, Nsec);
                break;
            case 3:
                InvokeRepeating("spw3", i, Nsec);
                break;
            case 4:
                InvokeRepeating("spw4", i, Nsec);
                break;
            case 5:
                InvokeRepeating("spw5", i, Nsec);
                break;
        }  }
    private void spw0()


                    {
        Instantiate(squarePrefab, new Vector3(locations[0],InitialPos.y, InitialPos.z), Quaternion.identity);}
    private void spw1()


{
        Instantiate(squarePrefab, new Vector3(locations[1], InitialPos.y, InitialPos.z), Quaternion.identity);
             }
     private void spw2()
    {
        Instantiate(squarePrefab, new Vector3(locations[2], InitialPos.y, InitialPos.z), Quaternion.identity);
      }
            private void spw3(){
        Instantiate(squarePrefab, new Vector3(locations[3], InitialPos.y, InitialPos.z), Quaternion.identity);
        }
                private void spw4()
            {
        Instantiate(squarePrefab, new Vector3(locations[4], InitialPos.y, InitialPos.z), Quaternion.identity);
                                    }


    private void spw5(){Instantiate(squarePrefab, new Vector3(locations[5], InitialPos.y, InitialPos.z), Quaternion.identity);
    }

   
}

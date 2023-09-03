using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSpawner : MonoBehaviour
{
    public GameObject floor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createFloor()
    {
        Instantiate(floor, new Vector3(transform.position.x, 0), transform.rotation);
        transform.position = new Vector3(transform.position.x + 18, transform.position.y);
    }
}

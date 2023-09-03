using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FloorLogic : MonoBehaviour
{
    private int deadZone = 30;
    public GameObject man;
    void Start()
    {
        man = GameObject.FindGameObjectWithTag("Man");
    }

    // Update is called once per frame
    void Update()
    {
        if(calculateDist() >= deadZone)
        {
            Destroy(gameObject);
        }
    }

    float calculateDist()
    {
        return math.abs(man.transform.position.x - transform.position.x) + math.abs(man.transform.position.y - transform.position.y);
    }
}

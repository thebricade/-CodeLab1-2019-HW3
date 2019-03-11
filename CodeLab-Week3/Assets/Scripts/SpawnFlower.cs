using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    public int limitSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        limitSpawn = 0;
        InvokeRepeating("Spawn",1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (limitSpawn <= 10)
        {
            GameObject newFlower = Instantiate(Resources.Load<GameObject>("Prefabs/Flower"));
            newFlower.transform.position = new Vector3(Random.Range(-5,5), Random.Range(-3,5), -1);
            limitSpawn++;
        }
    }
}

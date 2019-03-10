using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //roomba should  move forward 2 meters per second
        transform.Translate(2f*-Time.deltaTime,0f,0f);
        
        
        
        //make a ray shooting out of the front of the roomba
        Ray myRay = new Ray(transform.position, transform.forward);
        
        //2 mdefine the max raycast distance
        float maxRayDist = 2f;
        
        //3 debug
        Debug.DrawRay(myRay.origin,myRay.direction *maxRayDist, Color.cyan);

        if (Physics.Raycast(myRay, maxRayDist))
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber >= 50)
            {
                transform.Rotate(0f,-90f,0f);
            }
            else
            {
                transform.Rotate(0f,90f,0f);
            }
        }
        
    }
}

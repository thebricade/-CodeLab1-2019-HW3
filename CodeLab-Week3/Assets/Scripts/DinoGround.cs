using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoGround : MonoBehaviour
{
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //step 1 for raycasting make/declare a ray object
        Ray ray = new Ray(transform.position, Vector3.down);
        
        //step 2 speccify maxium raycast distance 
        float raycastDist = 0.6f;
        
        //set 3 debug draw the raycast
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        
        //set 4 
        if (Physics.Raycast(ray, raycastDist))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        //sphere cast is more commonly used and boxcast 
    }
 }


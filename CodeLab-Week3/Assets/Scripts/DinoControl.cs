using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class DinoControl : MonoBehaviour
{
    public Transform eyeLine;
    private SpriteRenderer spr; 
    [SerializeField] private LayerMask visibleObjects;

    private float ySpeed;
    private float xSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        xSpeed = -1f;
        ySpeed = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        //dino should  move forward 2 meters per second
        transform.Translate(xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,0f);
        
        
        //make a ray shooting out of the front of the roomba
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.2f, visibleObjects);
       // Ray myRay = new Ray(transform.position, transform.forward);
        
        //2 mdefine the max raycast distance
        float maxRayDist = 2f;
        
        //3 debug
        Debug.DrawRay(eyeLine.position, Vector2.left, Color.magenta, 0.1f);
       // Debug.DrawRay(hit.origin,hit.direction *maxRayDist, Color.cyan);

        if (hit.collider != null)
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber <= 25)
            {
                ySpeed = ySpeed*1;
            }else if (randomNumber >= 26 && randomNumber <= 50)
            {
                ySpeed = ySpeed * -1;
            }else if (randomNumber >= 51 && randomNumber <= 75)
            {
                xSpeed = xSpeed * 1;
            }
            else if (randomNumber >= 76 && randomNumber <= 100)
            {
                xSpeed = xSpeed *-1;
            }
            
            Debug.Log(hit.collider.name);
            spr.color = Color.red;
        }
        else
        {
            spr.color = Color.white;
        }
        
            /*
        if (Physics2D.Raycast(hit, maxRayDist))
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
        } */
        
    }
    
    /*
    void LookForFood()
    {
        var hit = Physics2D.Raycast(eyeLine.position, Vector2.right, 5f, visibleObjects);
        Debug.DrawRay(eyeLine.position, Vector2.right, Color.magenta, 0.1f);
        if (hit && hit.transform.name == "Carrot")
        {
            spr.color = Color.green;
        }
        else
        {
            spr.color = Color.white;
        }
    }
    */
}

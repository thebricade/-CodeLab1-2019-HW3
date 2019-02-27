using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;

    public int Score
    {
        get
        {
            //print("Someone got the score");
            return score;
        }
        set
        {
            score = value;
            if (score > 10)
            {
                //Throw a party
            }
            //print("score was set to: " +score);
        }
    }

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //Singleton (there can only be one) 
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score += 7;
        
    }
}

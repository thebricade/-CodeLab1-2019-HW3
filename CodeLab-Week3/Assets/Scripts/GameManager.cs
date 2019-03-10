using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    title,
    pause,
    playing
}

public class GameManager : MonoBehaviour
{
    int score = 0;

    private GameState currentState;
    private GameObject pauseMenu;
    private GameObject[] titleScreenObjects;
    
    //Title Screen
    public Button playButton;

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
        //setting Game Menu objects
        currentState = GameState.title;
        //setupButton
        GameObject titleMenu = Instantiate((Resources.Load<GameObject>("Prefabs/TitleMenu")));
        playButton = GameObject.Find("Play").GetComponent<Button>();
        playButton.onClick.AddListener(TaskOnClick);
        
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
        checkGameState();

    }

    void checkGameState()
    {
        switch (currentState)
        {
            case GameState.pause:
                //When the Gamestate is PAUSED set the timeScale to 0  to stop everything from spawning and moving
                if (Time.timeScale > 0f)
                {
                    GameObject pauseMenu = Instantiate(Resources.Load<GameObject>("Prefabs/PauseMenu"));
                    Time.timeScale = 0f;
                }
                
                //wWhen you press SPACE in a PAUSE state you should go back to PLAYING
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(GameObject.FindWithTag("Pause"));
                    currentState = GameState.playing;
                }
                break;
            case GameState.playing:
                Time.timeScale = 1.0f;
                
                //While in PLAYING state if the SPACE is pressed
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = GameState.pause;
                }
                break;
            case GameState.title:
                Time.timeScale = 0f;
                break;
        }
    }

    void TaskOnClick()
    {
        
        //Get all objects in Title State and put them in an array to destroy
        titleScreenObjects = GameObject.FindGameObjectsWithTag("TitleScreen");

        for (var i = 0; i < titleScreenObjects.Length; i++)
        {
            Destroy(titleScreenObjects[i]);
        }
        
        currentState = GameState.playing;
    }
}

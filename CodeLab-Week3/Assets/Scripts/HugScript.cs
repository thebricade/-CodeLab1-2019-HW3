using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HugScript : MonoBehaviour
{

    public Button NextGarden;
    // Start is called before the first frame update
    void Start()
    {
        NextGarden = GameObject.Find("NextGarden").GetComponent<Button>();
        NextGarden.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void TaskOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        GameManager.instance.Score++;
    }
}

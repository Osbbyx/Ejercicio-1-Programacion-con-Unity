using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public float levelTimer = 10f;
    public int levelScore;

    private string levelName = "SciFi_Industrial";

    void Start()
    {
        Instance = this;
        levelScore = 0;
        Debug.Log("Destruye 4 Barriles antes de que se agote el tiempo!");
    }


    void Update()
    {
        if(levelScore < 5)
        {
            if (levelTimer > 0f)
            {
                levelTimer -= Time.deltaTime;
                Debug.Log((int)levelTimer);
            }
            else
            {
                Debug.Log("********GAME OVER*********");
                SceneManager.LoadScene(levelName);
            }
            
        }
        else
        {
            Debug.Log("******YOU WIN******");
        }

    }
}

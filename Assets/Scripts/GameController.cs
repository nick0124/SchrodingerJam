using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyes = new List<GameObject>();
    [SerializeField] private int _failureSceneNumber;
    [SerializeField] private int _winSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCounter = 0;
        foreach (var enemy in _enemyes){
            if(enemy != null){
                enemyCounter++;
            }
        }

        if(enemyCounter <= 0){
            LoadWin();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadFalure(){
        SceneManager.LoadScene(_failureSceneNumber);
    }

    public void LoadWin(){
        SceneManager.LoadScene(_winSceneNumber);
    }
}

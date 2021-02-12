using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{
    private void Awake(){
        DontDestroyOnLoad(GameObject.Find("Music Player"));
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("levelOne", 2f);
    }

    void levelOne(){
        SceneManager.LoadScene(1);
    }
}

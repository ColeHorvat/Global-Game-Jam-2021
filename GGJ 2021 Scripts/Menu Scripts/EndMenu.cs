using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Thank-You-Scene") && Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}

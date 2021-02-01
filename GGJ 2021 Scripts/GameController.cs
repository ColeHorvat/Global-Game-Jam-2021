using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject nextLevelPoint;

    private void Start()
    {
        nextLevelPoint = GameObject.Find("NextLevelPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, nextLevelPoint.transform.position) < 3) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

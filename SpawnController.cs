using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private float spawnerAmount;
    private float randomChance = 100f;
    private bool isMonsterSpawned;
    private float randomNum;
    public GameObject animStartPos;
    private float monsterAmount;
    public GameObject monster;
    private float spawnTimer = 0;
    private float spawnTimerTime = 2;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnerAmount = GameObject.FindGameObjectsWithTag("Spawner").Length;
        player = GameObject.Find("Player");

        //Divide random chance by the amount of spawners in the room
        randomChance /= spawnerAmount;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectsWithTag("Monster").Length == 0) {
            randomNum = Random.Range(0, 100);

           // Debug.Log(randomNum + " " + randomChance);

            if(spawnTimer <= 0 && Vector3.Distance(gameObject.transform.position, player.transform.position) < 5) {
                if(randomNum < randomChance) {
                    spawnMonster();
                } else {
                    spawnTimer = spawnTimerTime;
                }
            }

        }

        spawnTimer -= Time.deltaTime;
    }

    void spawnMonster() {
        

        //Play animation at startpos

        //Instantiate Monster object after animation
        Instantiate(monster);
    }
}

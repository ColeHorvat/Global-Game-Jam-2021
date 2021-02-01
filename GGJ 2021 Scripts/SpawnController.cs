using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private float spawnerAmount;
    private bool isMonsterSpawned;
    public GameObject animStartPos;
    private float monsterAmount;
    public GameObject monster;
    private float spawnTimer = 0;
    private float spawnTimerTime = 2;
    private GameObject player;
    public GameObject spawnTrigger;
    public GameObject spawnPoint;
    public Animator spawnANim;

    bool spawnMonster = false;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnerAmount = GameObject.FindGameObjectsWithTag("Spawner").Length;
        player = GameObject.Find("Player");
        spawnANim.gameObject.SetActive(false);
        //Divide random chance by the amount of spawners in the room

    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectsWithTag("Monster").Length == 0) {

           // Debug.Log(randomNum + " " + randomChance);

            if(Vector3.Distance(spawnTrigger.transform.position, player.transform.position) < 3) {
                spawnMonster = true;
                spawned = false;
            }

        }

        if(spawnMonster)
            StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster() {

        spawnANim.gameObject.SetActive(true);

        while (spawnANim.GetFloat("dudu") < 1) {
            //Play animation at startpos
            spawnANim.SetTrigger("Spawn");

            yield return null;
        }
        if (!spawned)
        {//Instantiate Monster object after animation
            Instantiate(monster, spawnPoint.transform.position, transform.rotation);
            spawned = true;
        }

        spawnMonster = false;
        spawnANim.gameObject.SetActive(false);
    }
}

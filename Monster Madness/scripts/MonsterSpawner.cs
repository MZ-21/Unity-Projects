using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterRef;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(SpawnedMonsters());
        
    }

    IEnumerator SpawnedMonsters() {

    while(true){
        yield return new WaitForSeconds(Random.Range(1, 10));//between 1 to 5 seconds spawn new monster
        randomIndex = Random.Range(0, monsterRef.Length);
        randomSide = Random.Range(0, 2);

        spawnedMonster = Instantiate(monsterRef[randomIndex]); //instantiate will createa a copy of a game object we pass as a ref

        if(randomSide == 0){//left side
            spawnedMonster.transform.position = leftPos.position; //setting spawnded monsted to the leftPositions's position
            spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4, 10);
            spawnedMonster.transform.localScale = new Vector3(1.8f,1.8f,1f);
        }
        else {
            //right side
            spawnedMonster.transform.position = rightPos.position; //setting spawnded monster to the rightPositions's position
            spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10);//negative bc in axis moving to the left is negative
            spawnedMonster.transform.localScale = new Vector3(-1.8f,1.8f,1f);
        }
     }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}//class

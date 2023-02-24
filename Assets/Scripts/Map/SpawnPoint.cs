using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Scripts")]
    public GameObject basicEnemy;
    public GameObject tankEnemy;
    public GameObject bossEnemy;
    public float SpawnInterval = 0.2f;
    private float spawnRadius = 40f;
    private Vector2 newPosition;
    
    
    public int ActiveOfBasicEnemies = 0;
    public int ActiveOfTankEnemies = 0;
    public int ActiveOfBossEnemies = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyBasic(SpawnInterval, basicEnemy));
        StartCoroutine(spawnEnemyTank(SpawnInterval, tankEnemy));
        StartCoroutine(spawnEnemyBoss(SpawnInterval, bossEnemy));



    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private IEnumerator spawnEnemyBasic(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject basic = ObjectPoolEnemies.instance.GetPooledObjectBasic();
        
        
        if(basic != null)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            basic.transform.position = new Vector3(newPosition.x, newPosition.y, -1);
            
            basic.SetActive(true);
            ActiveOfBasicEnemies += 1;
            
            
        }
        if (ActiveOfBasicEnemies == 40)
        {
            interval = 100f;
        }
        


        StartCoroutine(spawnEnemyBasic(interval, enemy));
    }

    private IEnumerator spawnEnemyTank(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

       
        GameObject tank = ObjectPoolEnemies.instance.GetPooledObjectTank();

        if (tank != null)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            tank.transform.position = new Vector3(newPosition.x, newPosition.y, -1);

            tank.SetActive(true);
            ActiveOfTankEnemies += 1;
        }
        if (ActiveOfTankEnemies == 20)
        {
            interval = 100f;
        }



        StartCoroutine(spawnEnemyTank(interval, enemy));
    }

    private IEnumerator spawnEnemyBoss(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);


        GameObject boss = ObjectPoolEnemies.instance.GetPooledObjectBoss();

        if (boss != null)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            boss.transform.position = new Vector3(newPosition.x, newPosition.y, -1);

            boss.SetActive(true);
            ActiveOfBossEnemies += 1;
        }
        if (ActiveOfBossEnemies == 10)
        {
            interval = 100f;
        }



        StartCoroutine(spawnEnemyBoss(interval, enemy));
    }

}

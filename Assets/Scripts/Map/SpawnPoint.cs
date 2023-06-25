using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //Variables for scripts.
    [Header("Scripts")]
    public GameObject basicEnemy;
    public GameObject tankEnemy;
    public GameObject bossEnemy;

    //Variables for enemies spawn.
    [Header("Variables")]
    public float SpawnInterval = 0.2f;
    private float spawnRadius = 40f;
    private Vector2 newPosition;
    public int ActiveOfBasicEnemies = 0;
    public int ActiveOfTankEnemies = 0;
    public int ActiveOfBossEnemies = 0;
    public Timer TimeScript;
   

    //Function: Start is called before the first frame update
    void Start()
    {
        TimeScript = GameObject.FindObjectOfType<Timer>();
        
        //Start a coroutine that spawns enemy based on the spawn interval.
        StartCoroutine(spawnEnemyBasic(SpawnInterval, basicEnemy));
        StartCoroutine(spawnEnemyTank(SpawnInterval, tankEnemy));
        StartCoroutine(spawnEnemyBoss(SpawnInterval, bossEnemy));
    }
    
    //Function: This is a Ienumrator function that spawns an enemy based on the time interval using yield return.
    private IEnumerator spawnEnemyBasic(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        //Assign basic enemy gameobject, to an instance of the "ObjectPoolEnemies" script.
        GameObject basic = ObjectPoolEnemies.instance.GetPooledObjectBasic();
        //If there are enemies set in the hirearachy, set them to true around the player in a radius. 
        if(basic != null)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            basic.transform.position = new Vector3(newPosition.x, newPosition.y, -1);
            
            basic.SetActive(true);
            ActiveOfBasicEnemies += 1;
            
            
        }
       
        //If the active enemies is equal to 40 set the interval to 100 seconds to slower down the spawn rate of enemies.
        if (int.Parse(TimeScript.minute) <= 1)
        {
            if (ActiveOfBasicEnemies > 20)
            {
                
                interval = 3f;
            }
            else
            {
                interval = 0.2f;
            }
        }

        if (int.Parse(TimeScript.minute) >= 1 && int.Parse(TimeScript.minute) <= 5)
        {
            
            if (ActiveOfBasicEnemies > 30)
            {
                
                interval = 6f;
            }
            else
            {
                interval = 0.2f;
            }
        }
        if (int.Parse(TimeScript.minute) >= 5 && int.Parse(TimeScript.minute) <= 15)
        {
            if (ActiveOfBasicEnemies > 40)
            {
                interval = 6f;
            }
            else
            {
                interval = 0.2f;
            }
        }





        StartCoroutine(spawnEnemyBasic(interval, enemy));
    }

    //Function: This is a Ienumrator function that spawns an enemy based on the time interval using yield return.
    private IEnumerator spawnEnemyTank(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        //Assign tank enemy gameobject, to an instance of the "ObjectPoolEnemies" script.
        GameObject tank = ObjectPoolEnemies.instance.GetPooledObjectTank();
        //If there are enemies set in the hirearachy, set them to true around the player in a radius. 
        if (tank != null && float.Parse(TimeScript.second) >= 30)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            tank.transform.position = new Vector3(newPosition.x, newPosition.y, -1);

            tank.SetActive(true);
            ActiveOfTankEnemies += 1;
        }
        //If the active enemies is equal to 40 set the interval to 100 seconds to slower down the spawn rate of enemies.
        
        if (int.Parse(TimeScript.minute) <= 2)
        {
            if (ActiveOfTankEnemies > 5)
            {

                interval = 20f;
            }
            else
            {
                interval = 0.2f;
            }
        }

        if (int.Parse(TimeScript.minute) >= 2 && int.Parse(TimeScript.minute) <= 6)
        {

            if (ActiveOfTankEnemies > 10)
            {

                interval = 20f;
            }
            else
            {
                interval = 0.2f;
            }
        }
        if (int.Parse(TimeScript.minute) >= 6 && int.Parse(TimeScript.minute) <= 12)
        {
            if (ActiveOfTankEnemies > 20)
            {
                interval = 20f;
            }
            else
            {
                interval = 0.2f;
            }
        }

        StartCoroutine(spawnEnemyTank(interval, enemy));
    }
    
    //Function: This is a Ienumrator function that spawns an enemy based on the time interval using yield return.
    private IEnumerator spawnEnemyBoss(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        //Assign boss enemy gameobject, to an instance of the "ObjectPoolEnemies" script.
        GameObject boss = ObjectPoolEnemies.instance.GetPooledObjectBoss();
        //If there are enemies set in the hirearachy, set them to true around the player in a radius. 
        if (boss != null && int.Parse(TimeScript.minute) >= 1)
        {
            newPosition = Random.insideUnitCircle.normalized * spawnRadius;
            boss.transform.position = new Vector3(newPosition.x, newPosition.y, -1);

            boss.SetActive(true);
            ActiveOfBossEnemies += 1;
        }
        //If the active enemies is equal to 40 set the interval to 100 seconds to slower down the spawn rate of enemies.

        
        if (int.Parse(TimeScript.minute) <= 2)
        {
            if (ActiveOfBossEnemies > 10)
            {

                interval = 13f;
            }
            else
            {
                interval = 0.2f;
            }
        }

        if (int.Parse(TimeScript.minute) >= 2 && int.Parse(TimeScript.minute) <= 6)
        {

            if (ActiveOfBossEnemies > 20)
            {

                interval = 13f;
            }
            else
            {
                interval = 0.2f;
            }
        }
        if (int.Parse(TimeScript.minute) >= 6 && int.Parse(TimeScript.minute) <= 12)
        {
            if (ActiveOfBossEnemies > 30)
            {

                interval = 13f;
            }
            else
            {
                interval = 0.2f;
            }
        }



        StartCoroutine(spawnEnemyBoss(interval, enemy));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemies : MonoBehaviour
{

    //Variables for object pooling enemies.
    [Header("Variables")]
    public static ObjectPoolEnemies instance;

    public List<GameObject> basicEnemies = new List<GameObject>();
    public List<GameObject> bossEnemies = new List<GameObject>();
    public List<GameObject> tankEnemies = new List<GameObject>();

    private int amountOfBasic = 300;
    private int amountOfBoss = 60;
    private int amountOfTank = 200;

    [SerializeField] private GameObject basicEnemyPrefab;
    [SerializeField] private GameObject bossEnemyPrefab;
    [SerializeField] private GameObject TankEnemyPrefab;

    //Function: Upon starting the game, check if there is an instance of this script.
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    //Function: Start is called before the first frame update
    void Start()
    {
        //Loops to instantiate the enemy prefabs and setting them to inactivate in the hierrachy.  
        for(int i = 0; i < amountOfBasic; i++)
        {
            GameObject obj = Instantiate(basicEnemyPrefab);
            obj.SetActive(false);
            basicEnemies.Add(obj);        
        }

        for (int i = 0; i < amountOfBoss; i++)
        {
            GameObject obj = Instantiate(bossEnemyPrefab);
            obj.SetActive(false);
            bossEnemies.Add(obj);
        }

        for (int i = 0; i < amountOfTank; i++)
        {
            GameObject obj = Instantiate(TankEnemyPrefab);
            obj.SetActive(false);
            tankEnemies.Add(obj);
        }
    }

    //Function: of type gameObject returns the basic enemy from the hierrachy if is not active.
    public GameObject GetPooledObjectBasic()
    {
        for(int i = 0; i< basicEnemies.Count; i++)
        {
            if (!basicEnemies[i].activeInHierarchy)
            {
                return basicEnemies[i];

            }
        }
        return null;

    }
    //Function: of type gameObject returns the tank enemy from the hierrachy if is not active.
    public GameObject GetPooledObjectTank()
    {
        for (int i = 0; i < tankEnemies.Count; i++)
        {
            if (!tankEnemies[i].activeInHierarchy)
            {
                return tankEnemies[i];

            }
        }
        return null;

    }
    //Function: of type gameObject returns the boss enemy from the hierrachy if is not active.
    public GameObject GetPooledObjectBoss()
    {
        for (int i = 0; i < bossEnemies.Count; i++)
        {
            if (!bossEnemies[i].activeInHierarchy)
            {
                return bossEnemies[i];

            }
        }
        return null;

    }


}

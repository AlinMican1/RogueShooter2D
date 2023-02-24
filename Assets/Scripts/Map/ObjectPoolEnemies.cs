using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemies : MonoBehaviour
{
    public static ObjectPoolEnemies instance;

    private List<GameObject> basicEnemies = new List<GameObject>();
    private List<GameObject> bossEnemies = new List<GameObject>();
    private List<GameObject> tankEnemies = new List<GameObject>();

    private int amountOfBasic = 300;
    private int amountOfBoss = 60;
    private int amountOfTank = 200;

    [SerializeField] private GameObject basicEnemyPrefab;
    [SerializeField] private GameObject bossEnemyPrefab;
    [SerializeField] private GameObject TankEnemyPrefab;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Time span in which will the enemies spawn
    public float waitTime = 2;
    //in case of fast spawning save break
    public bool saveCheck = true;
    public int poolSize = 5;

    public GameObject enemyPrefab;

    GameObject[] pool;
    
    void Awake() {

        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab,this.transform.position,Quaternion.identity, this.transform);
            pool[i].SetActive(false);
        }   

    }

    void Start()
    {
        StartCoroutine(SpawnEnemyOnTime(waitTime)); 
    }

    void EnableObjectInPool()
    {
        foreach (GameObject item in pool)
        {
            if (item.activeInHierarchy == false)
            {
                item.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemyOnTime(float waitForTime)
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(waitForTime);
        }   
    }
}

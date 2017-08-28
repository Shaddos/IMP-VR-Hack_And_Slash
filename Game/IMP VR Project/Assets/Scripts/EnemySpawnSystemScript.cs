using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystemScript : MonoBehaviour {
    public GameObject rangeEnemy;
    public GameObject middleRangeEnemy;
    public GameObject frontEnemy;

    public int numberOfDiffEnemies = 3;
    public int numberOfEnemy = 10;
    public int timerCounter = 0;

    private List<string> enemyNames = new List<string>();

    public GameObject spawnPositions;

    private List<GameObject> rangeEnemies = new List<GameObject>();
    private List<GameObject> middleRangeEnemies = new List<GameObject>();
    private List<GameObject> frontEnemies = new List<GameObject>();

    public List<GameObject> spawnPositionList = new List<GameObject>();

    private List<GameObject> spawnLoc_R_E = new List<GameObject>();
    private List<GameObject> spawnLoc_MR_E = new List<GameObject>();
    private List<GameObject> spawnLoc_F_E = new List<GameObject>();

    

    // Use this for initialization
    void Start() {
        fillEnemyNames();
        saveSpawnPositions();
        splittSpawnLocation();
        fillEnemyLists();
    }

    // Update is called once per frame
    void Update() {
        
        if(timerCounter!= 60)
        {
            timerCounter++;
        }
        else
        {
            Debug.Log("Should Work");
            spawnRndEnemy();
            timerCounter = 0;
        }

    }

    private void saveSpawnPositions(){
        int numberOfSpawnPositions = spawnPositions.transform.childCount;
        
        for(int i = 0; i < numberOfSpawnPositions; i++)
        {
            spawnPositionList.Add(spawnPositions.transform.GetChild(i).gameObject);
            
        }
    }
    private void spawnRndEnemy()
    {
        int typeOfEnemy = Random.Range(0, numberOfDiffEnemies);
        
        switch (typeOfEnemy)
        {
            case 0:
                spawnEnemy(rangeEnemies, GetSpawnLocation(spawnLoc_R_E));
                break;
               
            case 1:
                spawnEnemy(middleRangeEnemies, GetSpawnLocation(spawnLoc_MR_E));
                break;
                
            case 2:
                spawnEnemy(frontEnemies, GetSpawnLocation(spawnLoc_F_E));
            break;
        }

    }
    private void fillEnemyLists()
    {
        GameObject placeHolderEnemy;

        for(int i = 0; i < numberOfEnemy; i++)
        {
            placeHolderEnemy = Instantiate (rangeEnemy);
            placeHolderEnemy.transform.name = rangeEnemy.transform.name;
            placeHolderEnemy.SetActive(false);
            rangeEnemies.Add(placeHolderEnemy);
        }
        for (int i = 0; i < numberOfEnemy; i++)
        {
            placeHolderEnemy = Instantiate(middleRangeEnemy);
            placeHolderEnemy.transform.name = middleRangeEnemy.transform.name;
            placeHolderEnemy.SetActive(false);
            middleRangeEnemies.Add(placeHolderEnemy);
        }
        for (int i = 0; i < numberOfEnemy; i++)
        {
            placeHolderEnemy = Instantiate(frontEnemy);
            placeHolderEnemy.transform.name = frontEnemy.transform.name;
            placeHolderEnemy.SetActive(false);
            frontEnemies.Add(placeHolderEnemy);
        }
    }
    private void fillEnemyNames()
    {
        enemyNames.Add("R_E");
        enemyNames.Add("MR_E");
        enemyNames.Add("F_E");
    }

    private void spawnEnemy(List<GameObject> toSpawnEnemyList, Transform spawnLocation)
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            if (!toSpawnEnemyList[i].activeInHierarchy)
            {
                toSpawnEnemyList[i].transform.position = spawnLocation.position ;
                toSpawnEnemyList[i].transform.rotation = transform.rotation;
                toSpawnEnemyList[i].SetActive(true);
                break;
            }
        }
    }
    private void splittSpawnLocation()
    {
        for(int i = 0; i < spawnPositionList.Count; i++)
        {
            if(i < spawnPositionList.Count / 3)
            {
                spawnLoc_R_E.Add(spawnPositionList[i]);
            }
            else if(i < (spawnPositionList.Count / 3) * 2)
            {
                spawnLoc_MR_E.Add(spawnPositionList[i]);
            }
            else if(i < spawnPositionList.Count)
            {
                spawnLoc_F_E.Add(spawnPositionList[i]);
            }
        }
    }

    private Transform GetSpawnLocation(List<GameObject> spawnLoc_)
    {   

        for (int i = 0; i < spawnLoc_.Count; i++)
        {
            if (!spawnLoc_[i].activeInHierarchy)
            {
               return spawnLoc_[i].transform;
      
            }
            else
            {
               return spawnLoc_[i].transform;
            }
        }
        return null;
    }
}

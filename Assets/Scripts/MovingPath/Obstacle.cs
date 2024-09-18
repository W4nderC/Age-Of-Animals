using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject normalEnemySO;
    [SerializeField] private EnemyScriptableObject advanceEnemySO;
    [SerializeField] private EnemyScriptableObject hardEnemySO;
    [SerializeField] private EnemyScriptableObject subEnemySO;
    [SerializeField] private EnemyScriptableObject bossEnemySO;

    private GameObject[] normalEnemyArray = new GameObject[10];
    private GameObject[] advanceEnemyArray = new GameObject[5];
    private GameObject[] hardEnemyArray = new GameObject[2];
    private GameObject[] subEnemyArray = new GameObject[5];
    private GameObject[] bossEnemyArray = new GameObject[2];
    
    [SerializeField] private int maxNumberOfNormalEnemy;
    [SerializeField] private int maxNumberOfAdvanceEnemy;
    [SerializeField] private int maxNumberOfHardEnemy;
    [SerializeField] private int maxNumberOfSubEnemy;
    [SerializeField] private int maxNumberOfBossEnemy;
    [SerializeField] private TextMeshPro currentNumberOfEnemyTxt;

    private int currentNumberOfClone;

    private int currentNumberOfNormalEnemy;
    private int currentNumberOfAdvanceEnemy;
    private int currentNumberOfHardEnemy;
    private int currentNumberOfSubEnemy;
    private int currentNumberOfBossEnemy;
    private int currentNumberOfEnemy;

    private BoxCollider boxCollider;

    private void Awake() {
        
    }

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnEnable() 
    {
        SpawnEnemyHandler();
    }

    public void SpawnEnemyHandler()
    {
        currentNumberOfClone = DataManager.Instance.currentNumberOfClone;
        int numberNormalEnemySpawn = 0;
        int numberAdvanceEnemySpawn = 0;
        int numberHardEnemySpawn = 0;
        int numberSubEnemySpawn = 0;

        int spawnNumber = currentNumberOfClone - UnityEngine.Random.Range(0, 5);
        currentNumberOfEnemyTxt.text = spawnNumber.ToString();

        for (int i = 0; i < spawnNumber; i++)
        {
            SpawnNormalEnemy();
            numberNormalEnemySpawn++;
            if (numberNormalEnemySpawn == maxNumberOfNormalEnemy)
            {
                SpawnAdvanceEnemy();
                numberAdvanceEnemySpawn++;
                numberNormalEnemySpawn = 0;
            }
            if(numberAdvanceEnemySpawn == maxNumberOfAdvanceEnemy) 
            {
                SpawnHardEnemy();
                numberHardEnemySpawn++;
                numberAdvanceEnemySpawn = 0;
            }
            if(numberHardEnemySpawn == maxNumberOfHardEnemy) 
            {
                SpawnSubEnemy();
                numberSubEnemySpawn++;
                numberHardEnemySpawn = 0;
            }
            if(numberSubEnemySpawn == maxNumberOfSubEnemy) 
            {
                SpawnBossEnemy();
                numberSubEnemySpawn = 0;
            }
        }
    }

    private void SpawnNormalEnemy()
    {   
        SpawnEnemy(normalEnemySO.enemyPrefab);
    }

    private void SpawnAdvanceEnemy()
    {        
        DestroyEnemy(normalEnemyArray, StringList.NORMAL_ENEMY);
        SpawnEnemy(advanceEnemySO.enemyPrefab);    
    }

    public void SpawnHardEnemy()
    {        
        DestroyEnemy(advanceEnemyArray, StringList.ADVANCE_ENEMY);
        SpawnEnemy(hardEnemySO.enemyPrefab);    
        
    }

    public void SpawnSubEnemy()
    {        
        DestroyEnemy(hardEnemyArray, StringList.HARD_ENEMY);
        SpawnEnemy(subEnemySO.enemyPrefab);    
        
    }

    public void SpawnBossEnemy()
    {        
        DestroyEnemy(subEnemyArray, StringList.SUB_ENEMY);
        SpawnEnemy(bossEnemySO.enemyPrefab);    
        
    }

    private void DestroyEnemy(GameObject[] enemyArray, string enemyName)
    {
        enemyArray = GameObject.FindGameObjectsWithTag(enemyName);
        for (int i = 0; i < enemyArray.Length; i++)
        {
            Destroy(enemyArray[i]);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {                
        Vector3 position = new Vector3
        (
            gameObject.transform.position.x + UnityEngine.Random.Range(-4, 4), 
            3f, 
            gameObject.transform.position.z + UnityEngine.Random.Range(-3, 3)
        );

        Instantiate(enemyPrefab, position, Quaternion.Euler( 0, 180, 0));

    }

    private void OnTriggerEnter(Collider other)
    {
        currentNumberOfNormalEnemy = FindObjectsOfType<NormalEnemy>().Length;
        currentNumberOfAdvanceEnemy = FindObjectsOfType<AdvanceEnemy>().Length;
        currentNumberOfHardEnemy = FindObjectsOfType<HardEnemy>().Length;
        currentNumberOfSubEnemy = FindObjectsOfType<SubEnemy>().Length;
        currentNumberOfBossEnemy = FindObjectsOfType<BossEnemy>().Length;

        currentNumberOfClone = DataManager.Instance.currentNumberOfClone;
        currentNumberOfEnemy =  currentNumberOfNormalEnemy 
                                + currentNumberOfAdvanceEnemy*10 
                                + currentNumberOfHardEnemy*50
                                + currentNumberOfSubEnemy*100
                                + currentNumberOfBossEnemy*500;

        // Game playing when: Current number of clone >= number of enemy
        if(other.gameObject.name == StringList.PLAYER 
        && currentNumberOfEnemy <= currentNumberOfClone) 
        {
            GameManager.Instance.InvokeOnObstaclesDestroy();
        } 
        // Game over when: Current number of clone < number of enemy
        else if (other.gameObject.name == StringList.PLAYER 
        && currentNumberOfEnemy > currentNumberOfClone)
        {   
            boxCollider.enabled = false;
            GameManager.Instance.InvokeOnSpawnGameOverEnemy();
            GameManager.Instance.GameStateChange(GameManager.GameState.GameOver);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

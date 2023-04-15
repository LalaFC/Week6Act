using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<SpawnSpots> SpawnSpots = new List<SpawnSpots>();
    public List<GameObject> EnemyTypes = new List<GameObject>();
    private GameObject Enemy;
    private SpawnSpots SpawnSpot;
    public float t=0;
    [SerializeField] public float[] spawnChance;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 5f);
        spawnChance = new float[EnemyTypes.Count];
    }
    void Update()
    {
        t = Time.time;
        for(int ArrayIndex = 0; ArrayIndex < spawnChance.Length; ArrayIndex++) 
        {
            if (ArrayIndex == 0)
                spawnChance[ArrayIndex] = 50;
            else
            {
                float LogChanceRate = Mathf.Pow(1.1f,t)/100;
                spawnChance[ArrayIndex] = Mathf.Lerp(10,25+(25/ArrayIndex), LogChanceRate);
            }
        }
    }
    private void Spawn()
    {
        SpawnSpot = SpawnSpots[Random.Range(0,SpawnSpots.Count)];
        Enemy = EnemyTypes[GetEnemyType()];
        Instantiate(Enemy, SpawnSpot.Spot, Quaternion.identity);
    }
    private int GetEnemyType()
    {
        float TotalChance = 0;
        for (int x = 0; x < spawnChance.Length; x++)
        {
            TotalChance += spawnChance[x];
        }
        float randomValue = Random.Range(0, TotalChance);
        float currentSpawnRate = 0;
        for (int x = 0; x < spawnChance.Length; x++)
        {
            currentSpawnRate += spawnChance[x];
            if (randomValue < currentSpawnRate)
            {
                return x;
            }
        }
        return 0;
    }

    //private IEnumerator 

}

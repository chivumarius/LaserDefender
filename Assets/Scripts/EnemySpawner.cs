using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ▼ "Reference" - "List of Wave Configs" Variable ▼
    [SerializeField] List<WaveConfigSO> waveConfigs;
    
    // ▼ "Reference" - "Time Between Waves" Variable ▼
    [SerializeField] float timeBetweenWaves = 0f;
    
    // ▼ "Reference" - "Is Looping" Variable ▼
    [SerializeField] bool isLooping;


    // ▼ "Reference" - "Current Wave" Variable ▼
    WaveConfigSO currentWave;





    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {        

        // ▼ "Starting" the "Coroutine" ▼
        StartCoroutine(SpawnEnemyWaves());
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Current Wave()" Method ▬▬▬▬▬▬▬▬▬▬
    public WaveConfigSO GetCurrentWave()
    {
        // ▼ "Returns" the "Current Wave" Variable ▼
        return currentWave;
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Spawn Enemy Waves()" Method using "Coroutine" ▬▬▬▬▬▬▬▬▬▬
    IEnumerator SpawnEnemyWaves()
    {
        // ▼ "Do-While" Loop ▼
        do
        {
            // ▼ "Looping" through the "List" of "Wave Configs" ▼
            foreach (WaveConfigSO wave in waveConfigs)
            {
                // ▼ "Setting" the "Current Wave" Variable
                currentWave = wave;
                
                // ▼ "Looping" through the "Count" of the "Enemy Prefabs" List ▼
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    // ▼ "Instantiating" the "Enemy Prefab"
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                //Quaternion.identity,      // ◄◄ Setting "No Rotation" for "Enemy Prefab" ◄◄
                                Quaternion.Euler(0,0,180),  // ◄◄ Setting "Rotation" on "Z" Axis for "Enemy Prefab" ◄◄
                                transform);
                    
                    // ▼ "Delaying" the "Spawn Time" of the "Enemy Prefab"
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                
                // ▼ "Delaying" the "Time Between Waves"
                yield return new WaitForSeconds(timeBetweenWaves);
            }           
        } 
        while(isLooping);    
    }
}

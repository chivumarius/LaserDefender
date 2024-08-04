using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ▼ "Creating" a "Wave Config" Menu & "New Wave Config" File Name ▼
[CreateAssetMenu(fileName = "New Wave Config", menuName = "Scriptable Objects/Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    // ▼ "Serialize Fields" for "Wave Config" Private Variables ▼
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    
    // ▼ "Serialize Fields" for "Enemy Instantiation" Private Variables ▼
    [SerializeField] List<GameObject> enemyPrefabs;


    // ▼ "Serialize Fields" for "Enemy Spawning" Private Variables ▼     
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;




    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Enemy Count()" Method ▬▬▬▬▬▬▬▬▬▬
    public int GetEnemyCount()
    {
        // ▼ "Returns" the "Count" of the "Enemy Prefabs" List ▼
        return enemyPrefabs.Count;
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Random Spawn Time()" Method ▬▬▬▬▬▬▬▬▬▬
    public float GetRandomSpawnTime()
    {
        // ▼ "Returns" a random "Spawn Time" 
        //     → between the "Minimum Spawn Time" 
        //     → and the "Maximum Spawn Time" ▼
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        
        
        // ▼ "Clamping" the "Spawn Time" to the "Minimum Spawn Time" and "Maximum Spawn Time"
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Enemy Prefab()" Method ▬▬▬▬▬▬▬▬▬▬
    public GameObject GetEnemyPrefab(int index)
    {
        // ▼ "Returns" the "Enemy Prefab" at the "Index" of the "Enemy Prefabs" List ▼
        return enemyPrefabs[index];
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Starting Waypoint()" Method ▬▬▬▬▬▬▬▬▬▬
    public Transform GetStartingWaypoint()
    {
        // ▼ "Returns" the "First Child" of the "Path Prefab" ▼  
        return pathPrefab.GetChild(0);
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Waypoints()" Method ▬▬▬▬▬▬▬▬▬▬
    public List<Transform> GetWaypoints()
    {
        // ▼ "Creates" a "List" of "Waypoints" ▼
        List<Transform> waypoints = new List<Transform>();
        
        // ▼ "Adds" the "Children" of the "Path Prefab" to the "List" of "Waypoints" ▼
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        
        // ▼ "Returns" the "List of Waypoints" ▼
        return waypoints;
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Move Speed()" Method ▬▬▬▬▬▬▬▬▬▬
    public float GetMoveSpeed()
    {
        // ▼ "Returns" the "Move Speed" ▼
        return moveSpeed;
    }
}

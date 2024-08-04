using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooter : MonoBehaviour
{
    // ▼ "Header" for the "Properties" in the "Inspector" ▼
    [Header("General")]

    // ▼ "Serialize Field" for "Holding" the "Prefab" for the "Projectile" ▼
    [SerializeField] GameObject projectilePrefab;
    
    // ▼ "Setting" a "Certain Amount" of "Speed" for the "Projectile" ▼
    [SerializeField] float projectileSpeed = 10f;
    
    // ▼ "Setting" a "Certain Amount" of "Lifetime" for the "Projectile" ▼
    [SerializeField] float projectileLifetime = 5f;
    
    
    // ▼ "Variable" for "Delaying" of the "Coroutines" ▼
    [SerializeField] float baseFiringRate = 0.2f;

    // ▼ "Header" for the "Properties" in the "Inspector" ▼
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;


    // ▼ "Setting" a "Boolean Flag" ▼
    [HideInInspector] public bool isFiring;



    // ▼ "Storing" the "Coroutine" for "Firing" the "Projectile" ▼
    Coroutine firingCoroutine;

    // ▼ "Referencing" the "Audio Player" Component ▼
    AudioPlayer audioPlayer;



    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Finding" the "Audio Player" Component ▼
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Checking" if "Use AI" is "Enabled" ▼
        if(useAI)
        {
            // ▼ "Setting" the "is Firing" to "True" ▼
            isFiring = true;
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Calling" the "Method" ▼
        Fire();
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Fire()" Method with "Accessing" of "Firing Coroutine" ▬▬▬▬▬▬▬▬▬▬
    void Fire()
    {
        // ▼ "Checking" if the "Shooter" is "Firing" & "Firing Coroutine" is "Null" ▼
        if (isFiring && firingCoroutine == null)
        {
            // ▼ "Starting" the "Coroutine" for "Firing" ▼
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        // ▼ "Checking" if the "Shooter" is "Not Firing" & "Firing Coroutine" is "Not Null" ▼
        else if(!isFiring && firingCoroutine != null)
        {
            // ▼ "Stopping" the "Coroutine" for "Firing" ▼
            StopCoroutine(firingCoroutine);
            
            // ▼ "Setting" the "Coroutine" for "Firing" to "Null" ▼
            firingCoroutine = null;
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Fire Continuously()" Coroutine Method with "Ienumerator" ▬▬▬▬▬▬▬▬▬▬▬
    IEnumerator FireContinuously()
    {
        // ▼ "Infinite Loop" for "Firing Continuously" ▼
        while(true)
        {
            // ▼ Creating & "New Projectile" by "Instantiating" the "Projectile" ▼ 
            GameObject instance = Instantiate(projectilePrefab, 
                                              transform.position, 
                                              Quaternion.identity
                                             );

            // ▼ "Getting" the "Rigidbody 2D" Component of the "Projectile" ▼
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            
            // ▼ "If" the "Rigidbody 2D" Component is "Not Null" ▼
            if(rb != null)
            {
                // ▼ "Setting" the "Direction" and "Speed" of the "Projectile" ▼    
                rb.velocity = transform.up * projectileSpeed;
            }

            // ▼ "Destroying" the "Projectile" after "Projectile Lifetime" Seconds ▼
            Destroy(instance, projectileLifetime);
            

            // ▼ "Setting" the "Time To Next Projectile" 
            //     → to a "Random Value" between the "Base Firing Rate" 
            //     → and "Firing Rate Variance" ▼
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                            baseFiringRate + firingRateVariance);
            
            // ▼ "Clamping" the "Time To Next Projectile" 
            //     → to the "Minimum Firing Rate" 
            //     → and "Maximum Firing Rate" ▼
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            // ▼ "Playing" the "Shooting Clip" with "Shooting Volume" ▼
            audioPlayer.PlayShootingClip();

            // ▼ "Waiting" for "Delaying" the "Firing Rate" Seconds ▼
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}

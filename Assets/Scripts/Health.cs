using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;

    [SerializeField] int health = 50;
    [SerializeField] int score = 50;

    [SerializeField] ParticleSystem hitEffect;

    // ▼ "Camera Shake" Properties ▼
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    // ▼ "Reference" to "Audio Player" ▼
    AudioPlayer audioPlayer;

    // ▼ "Reference" to "Score Keeper" Component ▼
    ScoreKeeper scoreKeeper;

    // ▼ "Reference" to "Level Manager" Component ▼
    LevelManager levelManager;





    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Gets" the "Camera Shake" Component ▼
        cameraShake = Camera.main.GetComponent<CameraShake>();

        // ▼ "Gets" the "Audio Player" Component ▼
        audioPlayer = FindFirstObjectByType<AudioPlayer>();

        // ▼ "Gets" the "Score Keeper" Component ▼
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();

        // ▼ "Finding" the "Level Manager" Object in the "Game" Scene ▼
        levelManager = FindFirstObjectByType<LevelManager>();
    }





    // ▬▬▬▬▬▬▬▬▬▬ "On Trigger Enter 2D()" Method ▬▬▬▬▬▬▬▬▬▬
    void OnTriggerEnter2D(Collider2D other)
    {
        // ▼ "Gets" the "DamageDealer" Game Object ▼
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();


        // ▼ "Checks" if "DamageDealer" Exists ▼
        if(damageDealer != null)
        {
            // ▼ "Calls" the "Methods" ▼
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            
            // ▼ "Accessing" the "PlayDamageClip()" Method of "Audio layer" ▼
            audioPlayer.PlayDamageClip();

            ShakeCamera();

            // ▼ "Accessing" the "Method" of "Damage Dealer" ▼
            damageDealer.Hit();
        }
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Health()" Method ▬▬▬▬▬▬▬▬▬▬
    public int GetHealth()
    {
        return health;
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Take Damage()" Method ▬▬▬▬▬▬▬▬▬▬
    void TakeDamage(int damage)
    {
        // ▼ "Subtracts" the "Damage" Variable's Value 
        //      → from the "Health" Variable's Value ▼
        health -= damage;
        
        // ▼ "Checks" if "Health" is "Less" than or "Equal" to "0" ▼
        if(health <= 0)
        {           
            // ▼ "Destroys" the "Game Object" ▼
            Die();
        }
    }



    
    // ▬▬▬▬▬▬▬▬▬▬ "Die()" Method ▬▬▬▬▬▬▬▬▬▬
    void Die()
    {
        // ▼ "Checks" if "is Not" the "Player" ▼
        if(!isPlayer)
        {
            // ▼ "Modifies" the "Score" Variable's Value ▼
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            // ▼ "Loading" the "Game Over" Scene ▼
            levelManager.LoadGameOver();
        }


        // ▼ "Destroys" the "Game Object" ▼
        Destroy(gameObject);
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Play it Effect()" Method ▬▬▬▬▬▬▬▬▬▬
    void PlayHitEffect()
    {
       
        if(hitEffect != null)
        {
            // ▼ "Instantiates" the "Particle System"
            //     → at the "Position" of the "GameObject" ▼
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            
            // ▼ "Destroys" the "Particle System" after "Duration" Seconds ▼
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Shake Camera()" Method ▬▬▬▬▬▬▬▬▬▬
    void ShakeCamera()
    {
        // ▼ "Checks" if "Camera Shake" is "Not Null" and "Enabled" ▼
        if(cameraShake != null && applyCameraShake)
        {
            // ▼ "Plays" the "Camera Shake" ▼
            cameraShake.Play();
        }
    }
}




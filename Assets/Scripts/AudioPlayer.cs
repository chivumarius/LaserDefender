using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioPlayer : MonoBehaviour
{
    // • "[Range()]" Attribute 
    //     → Used to "Create" a "Slider" 
    //     → to "Adjust" the "Volume" between "2 Values" 
    //     → in the "Inspector" Window •

    // ▼ "Shooting" Header for "Grouping Properties" ▼
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;    
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;


    // ▼ "Damage" Header for "Grouping Properties" ▼
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

   

    //===================================================================================== 
    //          "SINGLETON" DESIGN PATTERN  
    //   •► For "Playing Game Music Continuously" when Changing" between "Scenes" ◄•
    //===================================================================================== 
    // ▼ "Reference" to "Audio Player" Class 
    //     → using a Private "Static" Variable 
    //     → that "Persists" through "All Instances" of the "Class" ▼
    static AudioPlayer instance;



    
    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Calls" "Method" ▼
        ManageSingleton();
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Manage Singleton()" Method ▬▬▬▬▬▬▬▬▬▬
    void ManageSingleton()
    {
        // ▼ "Checks" if "Instance" already "Exists" ▼
        if(instance != null)
        {
            // ▼ "Set" the "Instance" to "False" ▼
            gameObject.SetActive(false);

            // ▼ "Destroy" the "Instance" because we "Don't Need" more then "One" ▼
            Destroy(gameObject);
        }
        else
        {
            // ▼ "Set" the "Instance" to "This Object" ▼
            instance = this;

            // ▼ "Dont Destroy" the "GameObject" and "Set" the "Audio Player Up"
            //      → so could "Transition" between "Scenes" 
            //      → and "Not Be Destroyed" when "New Scene" is "Loaded" ▼
            DontDestroyOnLoad(gameObject);
        }
    }
    //===================================================================================== 




    // ▬▬▬▬▬▬▬▬▬▬ "Play Shooting Clip()" Method ▬▬▬▬▬▬▬▬▬▬
    public void PlayShootingClip()
    {
        // ▼ "Plays" the "Shooting Clip" with "Shooting Volume" ▼
        PlayClip(shootingClip, shootingVolume);
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Play Damage Clip()" Method ▬▬▬▬▬▬▬▬▬▬
    public void PlayDamageClip()
    {
        // ▼ "Plays" the "Damage Clip" with "Damage Volume" ▼
        PlayClip(damageClip, damageVolume);
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Play Clip()" Method ▬▬▬▬▬▬▬▬▬▬
    void PlayClip(AudioClip clip, float volume)
    {
        // ▼ "Checks" if "Clip" is "Not Null" and "Enabled" ▼
        if(clip != null)
        {
            // ▼ "Setting" the "Initial Position" of the "Camera" ▼
            Vector3 cameraPos = Camera.main.transform.position;
            
            // ▼ "Plays" the "Clip" with "Volume" ▼
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}

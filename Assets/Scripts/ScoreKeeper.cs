using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreKeeper : MonoBehaviour
{
    int score;


    //===================================================================================== 
    //          "SINGLETON" DESIGN PATTERN  
    //   •► For "Keeping Continuously" when "Changing" between "Scenes" ◄•
    //===================================================================================== 
    // ▼ "Reference" to "Score Keeper" Class 
    //     → using a Private "Static" Variable 
    //     → that "Persists" through "All Instances" of the "Class" ▼
    static ScoreKeeper instance;



    
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





    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Score()" Method ▬▬▬▬▬▬▬▬▬▬
    public int GetScore()
    {
        return score;
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Modify Score()" Method ▬▬▬▬▬▬▬▬▬▬
    public void ModifyScore(int value)
    {
        // ▼ "Adding" the "Value" to the "Score" Variable ▼
        score += value;
        
        // ▼ "Clamping" the "Score" Value between "0" and int.MaxValue ▼
        Mathf.Clamp(score, 0, int.MaxValue);

        // ▼ "Prints" the "Score"in the "Console" become "UI" is "Not Created Yet" ▼
        Debug.Log(score);
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Reset Score()" Method ▬▬▬▬▬▬▬▬▬▬
    public void ResetScore()
    {
        // ▼ "Resetting" the "Score" ▼
        score = 0;
    }
}

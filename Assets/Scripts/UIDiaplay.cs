using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    // ▼ "Health" Header to "Group Properties" in "Inspector" ▼
    [Header("Health")]
    // ▼ "Refering" the "Objects ▼
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    
    
    // ▼ "Score" Header to "Group Properties" in "Inspector" ▼
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;




    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Gets" the "Score Keeper" Object ▼
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }






    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Sets" the "Max Value" of the "Health Slider" Object 
        //      → to "Get Health" of the "Player Health" Object
        healthSlider.maxValue = playerHealth.GetHealth();
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Sets" the "Value" of the "Health Slider" Object
        //      → to "Get Health" of the "Player Health" Object
        healthSlider.value = playerHealth.GetHealth();
        
        // ▼ "Sets" the "Text" of the "Score Text" Object
        //      → to "Get Score" of the "Score Keeper" Object
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}

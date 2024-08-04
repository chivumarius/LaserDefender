using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIGameOver : MonoBehaviour
{
    // ▼ "Grabbing" the "references" to the "UI elements" ▼
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;



    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Finding" the "Score Keeper" Object ▼
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Sets" the "Text" of the "Score Text" Object
        //      → to "Get Score" of the "Score Keeper" Object ▼
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
}

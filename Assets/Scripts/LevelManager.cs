using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    // ▼ "Set" the "Scene Load Delay" Variable ▼
    [SerializeField] float sceneLoadDelay = 2f;

    // ♥ "Reference" to the "Score Keeper" ScObjectript ▼
    ScoreKeeper scoreKeeper;




    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Finding" the "Score Keeper" Object ▼
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Load Game()" Method ▬▬▬▬▬▬▬▬▬▬
    public void LoadGame()
    {
        // ▼ "Resetting" the "Score" ▼
        scoreKeeper.ResetScore();

        // ▼ "Loading" the "Game" Scene ▼
        SceneManager.LoadScene("Game");
    }






    // ▬▬▬▬▬▬▬▬▬▬ "Load Main Menu()" Method ▬▬▬▬▬▬▬▬▬▬
    public void LoadMainMenu()
    {
        // ▼ "Loading" the "Main Menu" Scene ▼
        SceneManager.LoadScene("MainMenu");
    }






    // ▬▬▬▬▬▬▬▬▬▬ "Load Game Over()" Method ▬▬▬▬▬▬▬▬▬▬
    public void LoadGameOver()
    {
        // ▼ "Loading" the "Game Over" Scene ▼
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }






    // ▬▬▬▬▬▬▬▬▬▬ "Quit Game()" Method for the "Quit" Button ▬▬▬▬▬▬▬▬▬▬
    public void QuitGame()
    {
        // ▼ "Print" the "Message" ▼
        Debug.Log("Quitting Game...");
        
        // ▼ "Quitting" the "Application" ▼
        Application.Quit();
    }






    // ▬▬▬▬▬▬▬▬▬▬ "Wait And Load()" Method as "Coroutine" ▬▬▬▬▬▬▬▬▬▬
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        // ▼ "Wait" for "Delay" Seconds ▼ 
        yield return new WaitForSeconds(delay);
        
        // ▼ "Loading" the "Scene" ▼
        SceneManager.LoadScene(sceneName);
    }
}

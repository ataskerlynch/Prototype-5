using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    private float spawnRate =1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {       
    }

    public void StartGame(int difficulty)
    {
        // Activate Game
        isGameActive = true;
        // Set difficulty
        spawnRate /= difficulty;
        // Initialize score
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        // Switch off title screen
        titleScreen.gameObject.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn Targets at spawnRate Interval
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

        public void UpdateScore(int scoreToAdd)
    {
        // Update score
        score += scoreToAdd;
        // Display updated score
        scoreText.text = "Score: " + score;
    }

    // Game over routine
    public void GameOver()
    {
        // Display Game Over text
        gameOverText.gameObject.SetActive(true);
        // Disable game
        isGameActive = false;
        // Display restart button
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        // Get the Game Manager object so that buttons can interact with Game Manager
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        // Based on which difficulty button was pressed the game will be started with the associated difficulty value 
        gameManager.StartGame(difficulty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

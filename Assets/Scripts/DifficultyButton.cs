using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    Button button;
    int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        if(gameObject.name == "MediumButton")
            difficulty = 2;
        else if(gameObject.name == "HardButton")
            difficulty = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().StartGame(difficulty);
    }
}

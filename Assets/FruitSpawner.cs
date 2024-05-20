using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FruitSpawner : MonoBehaviour
{

    public GameObject[] fruitPrefabs; // Array to hold the fruit prefabs
    public float spawnInterval = 2.0f; // Time between each spawn
    public float launchForce = 10.0f; // Force applied to launch the fruit
    public int MinfruitsPerSpawn = 3; // Number of fruits to spawn each interval
    public int MaxfruitsPerSpawn = 6; // Number of fruits to spawn each interval
    public Text Score;

    public UnityEngine.UI.Button button;

    public int val= 0;

    public Text timerText; // Assign this in the inspector with your TimerText UI
    private float roundTime = 30f; // 30 seconds for each round
    private bool roundActive = true; // Tracks if the round is active

    private float restartTime = 10f;

    private bool ended= false;
    public Text restartText;


    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);

                // Start spawning fruits at regular intervals
        InvokeRepeating(nameof(SpawnFruit), 2.0f, spawnInterval);
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(ended == true){
            restartText.text = "restarting in ... "+restartTime.ToString();

        }
        Score.text = "Score: " + val;
        if(roundActive)
        {
            // Decrease roundTime by the time passed since the last frame
            roundTime -= Time.deltaTime;

            // Update the timerText UI element
            timerText.text = "Time: " + roundTime.ToString("F2"); // F2 formats to 2 decimal places

            // Check if the round is over
            if(roundTime <= 0)
            {
                EndRound();
            }
        }
    }

    void EndRound()
    {
        restartTime -= Time.deltaTime;
        roundActive = false;
        timerText.text = "Round Over!";

        button.gameObject.SetActive(false);
        CancelInvoke();

        
        if(restartTime == 0){
            //Start();
            SceneManager.LoadScene("Game");
            ended = true;  

        }
        // Here you can also trigger any other actions that should happen at the end of a round
    }

    void SpawnFruit()
    {
        int fruitsPerSpawn = Random.Range(MinfruitsPerSpawn,MaxfruitsPerSpawn);
        for(int i = 0; i < fruitsPerSpawn; i++)
        {
            // Randomly pick a fruit to spawn
            int fruitIndex = Random.Range(0, fruitPrefabs.Length);
            GameObject fruit = fruitPrefabs[fruitIndex];

            // Instantiate the fruit at the spawner's position
            GameObject spawnedFruit = Instantiate(fruit, transform.position, Quaternion.identity);

            // Apply a force to launch the fruit vertically
            Rigidbody rb = spawnedFruit.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        }
    }
}

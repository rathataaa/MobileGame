using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
   public GameObject enemyPrefab;

   public GameObject researchPrefab;

   public GameObject playButton;

   [SerializeField] float spawnRate;

   bool gameStarted = false;
   DogderAttributes playerAttributes;

   int score = 0;

   Vector2 screenPos;

   [SerializeField] TextMeshProUGUI scoreText;

   [SerializeField] TextMeshProUGUI ResearchText;

   int researchScore = 0;

   
void Start()
    {
       score = playerAttributes.GetScore();
    }

void SpawnEnemy()
    {
        float randomX = Random.Range(0f,1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);

        score++;

        UpdateText(score);
    }

    void SpawnResearch()
    {
        float randomX = Random.Range(0f,1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        Instantiate(researchPrefab, worldPos, Quaternion.identity);
    }
    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy",0.5f, spawnRate);
        InvokeRepeating("SpawnResearch", 1f, 3f); // Spawn Research hver 3. sekund
    }

    // Start game when Play button is pressed
    public void StartGame()
    {
        StartSpawning();
        if (playButton != null) playButton.SetActive(false);
        gameStarted = true;
    }

    private void Update()
    {
        // Start game via InputSystem click on Play button (only before game starts)
        if (!gameStarted && transform.GetComponent<InputSystem>().IsPressing(out screenPos))
        {
            StartGame();
        }

        Debug.Log("Current Score" + score);       
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void AddResearchScore()
    {
        researchScore++;
        if (ResearchText != null)
            ResearchText.text = researchScore.ToString();
    }

    public void JumpScare()
    {
        if(researchScore == 10)
        {
            Debug.Log("Jump Scare Triggered!");
            // Implement your jump scare logic here (e.g., play sound, show image, etc.)
        }
    

    }

}


  

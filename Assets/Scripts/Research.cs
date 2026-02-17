using UnityEngine;


public class Research : MonoBehaviour
{
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if(viewportPos.y <0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
                gameManager.AddResearchScore();
            Destroy(gameObject);
        }
    }
}

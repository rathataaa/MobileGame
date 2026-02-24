using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
public class Player : MonoBehaviour
{
    DogderAttributes playerAttributes = new DogderAttributes(100,100,0);
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] InputSystem InputSys;
    [SerializeField] TextMeshProUGUI healthText;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int moveDir = 0;

        Vector2 screenPos;

        if(InputSys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));

            if(touchPos.x < 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }
        }
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

            if((viewportPos.x<=0f && moveDir<0)|| (viewportPos.x>=1 && moveDir > 0))
            {
                moveDir = 0;
            }
        
            rb.linearVelocityX = moveDir * moveSpeed;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAttributes.SettingHealth(playerAttributes.GetHealth() - 20);
            if (healthText != null)
                healthText.text = playerAttributes.GetHealth().ToString();
            Destroy(collision.gameObject);
            if (playerAttributes.GetHealth() <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

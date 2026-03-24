using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class Gestures_Pinch : MonoBehaviour
{

    [SerializeField] GameObject playerSquare;
    [SerializeField] float pinchSpeed = 0.05f;
    Vector3 originalScale;
    float scaleMultiplier = 1f;
    float previousDistance;
   public bool isPinching;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Start()
    {
        originalScale = playerSquare.transform.localScale;
    }

    void Update()
    {
        if (touch.activeTouches.Count < 2)
        {
            isPinching = false;
            return;
        }

        touch touch1 = touch.activeTouches[0];
        touch touch2 = touch.activeTouches[1];

        float currentDistance =
            Vector2.Distance(touch1.screenPosition, touch2.screenPosition);
        
        if (!isPinching)
        {
            previousDistance = currentDistance;
            isPinching = true;
            return;
        }

        float delta = currentDistance - previousDistance;
Debug.Log("Distance: " + delta);
        ScaleObject(delta);

        previousDistance = currentDistance;
    }

    void ScaleObject(float delta)
    {
        scaleMultiplier += delta * 0.01f;
        

        scaleMultiplier = Mathf.Clamp(scaleMultiplier, 0.5f, 1f);

        playerSquare.transform.localScale = originalScale * scaleMultiplier;
        
    }
}

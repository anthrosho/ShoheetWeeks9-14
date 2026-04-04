using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerinputController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Daisy Daisy, Give Me Your Answer Doooo");
    }

public void ImHalfCrazy(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("I'm Half Crazy");
        }
    }
}
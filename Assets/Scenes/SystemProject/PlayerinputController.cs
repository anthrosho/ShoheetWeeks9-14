using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class PlayerinputController : MonoBehaviour
{
    public UnityEvent onSing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Welcome to Littly Timmy's The Robbot Show Singing!");
    }

public void ImHalfCrazy(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("Thank you for coming to my show! Now let's begin!");
            onSing.Invoke();
        }
    }
}
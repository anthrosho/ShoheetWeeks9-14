using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
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
        Debug.Log("Please rise for little Timmy The Robot Song!");
    }

public void ImHalfCrazy(InputAction.CallbackContext context)
    {

        if (context.performed) 
        {
            Debug.Log("Thank You! Please enjoy my song!");
            onSing.Invoke();
        }
    }
}
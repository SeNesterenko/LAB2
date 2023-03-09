using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _buttonClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _buttonClicked.Invoke(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _buttonClicked.Invoke(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _buttonClicked.Invoke(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _buttonClicked.Invoke(3);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _buttonClicked.Invoke(4);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _buttonClicked.Invoke(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _buttonClicked.Invoke(6);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _buttonClicked.Invoke(7);
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            _buttonClicked.Invoke(8);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            _buttonClicked.Invoke(9);
        }
    }
}
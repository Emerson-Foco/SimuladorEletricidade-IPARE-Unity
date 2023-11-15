using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{    
    private bool _mouseOn = false;

    public UnityEvent onClick;
    
    void Update()
    {
        if (_mouseOn && Input.GetKeyUp(KeyCode.Mouse0))
        {
           onClick?.Invoke();
        }
    }

    public void OnMouseEnter()
    {
        _mouseOn = true;
    }

    public void OnMouseExit()
    {
        _mouseOn = false;
    }
}

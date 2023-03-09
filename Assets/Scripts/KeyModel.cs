using JetBrains.Annotations;
using UnityEngine;

public class KeyModel : MonoBehaviour
{
    public bool IsKeyOff => _isKeyOff;

    [SerializeField] private KeyView _keyView;
    
    private bool _isKeyOff = true;
    
    // Call it when Key has clicked from InputController or Scheme
    [UsedImplicitly]
    public void ChangeState()
    {
        _isKeyOff = !_isKeyOff;

        _keyView.Image.color = _isKeyOff ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 255);
    }
}
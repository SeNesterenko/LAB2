using UnityEngine;
using UnityEngine.UI;

public class KeyView : MonoBehaviour
{
    public Image Image => _image;
    
    [SerializeField] private Image _image;
}
using UnityEngine;

public class Variant : MonoBehaviour
{
    public KeyModel[] Keys => _keys;
    public string Name => _name;
    public float[] Resistors => _resistors;
    public float[] LoadedResistors => _loadedResistors;
    public float PowerSource => _powerSource;
    
    [SerializeField] private string _name;
    [SerializeField] private float[] _resistors;
    [SerializeField] private float[] _loadedResistors;
    [SerializeField] private float _powerSource;
    [SerializeField] private KeyModel[] _keys;
}
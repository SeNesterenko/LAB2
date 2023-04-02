using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _variantChanged;
    
    [SerializeField] private Variant[] _variants;
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Scheme _scheme;
    [SerializeField] private CalculatorController _calculatorController;

    private float _randomValue;

    private void Start()
    {
        foreach (var variant in _variants)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData { text = variant.Name });
        }

        _dropdown.RefreshShownValue();
        _randomValue = Random.Range(0.98f, 1.02f);
        ChangeVariant(0);
        
        Debug.Log("GameManager " + _randomValue);
    }

    // Call it when Variant has changed from Unity editor
    [UsedImplicitly]
    public void ChangeVariant(int index)
    {
        _scheme.Initialize(_variants[index]);
        _calculatorController.Initialize(_variants[index], _randomValue);
        
        _variantChanged.Invoke();
    }
}
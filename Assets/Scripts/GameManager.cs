using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Variant[] _variants;
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Scheme _scheme;
    [SerializeField] private CalculatorController _calculatorController;

    private void Start()
    {
        foreach (var variant in _variants)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData { text = variant.Name });
        }

        _dropdown.RefreshShownValue();
        
        ChangeVariant(0);
    }

    // Call it when Variant has changed from Unity editor
    [UsedImplicitly]
    public void ChangeVariant(int index)
    {
        _scheme.Initialize(_variants[index]);
        _calculatorController.Initialize(_variants[index]);
    }
}
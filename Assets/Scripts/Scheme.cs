using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Scheme : MonoBehaviour
{
    [SerializeField] private KeyModel[] _buttons;
    [SerializeField] private TMP_Text[] _resistors;
    [SerializeField] private TMP_Text _powerSource;

    [SerializeField] private TMP_Text _amperes;
    [SerializeField] private TMP_Text _volts;
    
    private Variant _variant;

    public void Initialize(Variant variant)
    {
        _variant = variant;

        for (var i = 0; i < _resistors.Length; i++)
        {
            _resistors[i].text = _variant.Resistors[i] + " Ом";
        }

        _powerSource.text = _variant.PowerSource + " B";
    }
    
    // Call it when key has clicked from Unity Editor
    [UsedImplicitly]
    public void ChangeStateKey(int index)
    {
        _buttons[index].ChangeState();
    }

    public void ChangeStateElectricalMeasurementsOfCircuit(ElectricalMeasurementsOfCircuit electricalMeasurementsOfCircuit)
    {
        _amperes.text = electricalMeasurementsOfCircuit.CircuitAmperage.ToString();

        _volts.text = electricalMeasurementsOfCircuit.CircuitVoltage > 0 ? electricalMeasurementsOfCircuit.CircuitVoltage.ToString() : "0";
    }
}
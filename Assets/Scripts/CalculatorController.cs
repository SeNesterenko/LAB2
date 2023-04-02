using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    [SerializeField] private Scheme _scheme;
    
    private Variant _variant;
    private Calculator _calculator;
    private ElectricalMeasurementsOfCircuit _electricalMeasurementsOfCircuit;

    public void Initialize(Variant variant, float randomValue)
    {
        _calculator = new Calculator(variant, randomValue);
        _calculator.CalculateTotalResistance();
        _electricalMeasurementsOfCircuit = new ElectricalMeasurementsOfCircuit();
    }

    public void RecountTotalResistanceOfLoadedResistors()
    {
        _calculator.Calculate(_electricalMeasurementsOfCircuit);
        _scheme.ChangeStateElectricalMeasurementsOfCircuit(_electricalMeasurementsOfCircuit);
    }
}
using System;
using UnityEngine;

public class Calculator
{
    private const int ARRAY_ERROR = 1;
    
    private readonly Variant _variant;
    private readonly float[] _resistors;

    private float _totalResistanceOfLoadedResistors;
    private float _totalAmperage;
    private float _totalResistance;
    private readonly float _randomValue;

    public Calculator(Variant variant, float randomValue)
    {
        _variant = variant;
        _resistors = _variant.Resistors;
        _randomValue = randomValue;
    }

    public void Calculate(ElectricalMeasurementsOfCircuit electricalMeasurementsOfCircuit)
    {
        CalculateTotalResistanceOfLoadedResistors();
        electricalMeasurementsOfCircuit.CircuitAmperage = MathF.Round(_totalAmperage / (_totalResistance + _totalResistanceOfLoadedResistors) * 1000, 0);
        electricalMeasurementsOfCircuit.CircuitVoltage = MathF.Round(_totalResistanceOfLoadedResistors * electricalMeasurementsOfCircuit.CircuitAmperage / 1000, 3);
    }

    public void CalculateTotalResistance()
    {
        var resistors23 = CalculateResistanceOfResistor(2, 3, 2, 3, 4);
        var resistors34 = CalculateResistanceOfResistor(3, 4, 2, 3, 4);
        var resistors24 = CalculateResistanceOfResistor(2, 4, 2, 3, 4);
        var resistanceOfNodeC = CalculateTotalResistanceOfSequenceNodes(resistors24, _resistors[5 - ARRAY_ERROR]);
        var resistanceOfNodeD = CalculateTotalResistanceOfSequenceNodes(resistors34, _resistors[6 - ARRAY_ERROR]);
        var resistanceOfNodesCD = CalculateTotalResistanceOfParallelNodes(resistanceOfNodeC, resistanceOfNodeD);
        var resistanceOfNodesAB = CalculateTotalResistanceOfSequenceNodes(resistanceOfNodesCD, resistors23);
        _totalResistance = CalculateTotalResistanceOfParallelNodes(resistanceOfNodesAB, _resistors[1 - ARRAY_ERROR]);
        _totalAmperage = _variant.PowerSource * (1 - _resistors[1 - ARRAY_ERROR] / (_resistors[1 - ARRAY_ERROR] + resistanceOfNodesAB));
    }

    private static float CalculateTotalResistanceOfParallelNodes(float firstResistance, float secondResistance)
    {
        return firstResistance * secondResistance / (firstResistance + secondResistance);
    }
    
    private static float CalculateTotalResistanceOfSequenceNodes(float firstResistance, float secondResistance)
    {
        return firstResistance + secondResistance;
    }
    
    private float CalculateResistanceOfResistor(int firstIndex, int secondIndex, int thirdIndex, 
        int fourthIndex, int fifthIndex)
    {
        return _resistors[firstIndex - ARRAY_ERROR] * _resistors[secondIndex - ARRAY_ERROR] /
               (_resistors[thirdIndex - ARRAY_ERROR] + _resistors[fourthIndex - ARRAY_ERROR]
                                                     + _resistors[fifthIndex - ARRAY_ERROR]);
    }

    private void CalculateTotalResistanceOfLoadedResistors()
    {
        var conductivity = 0f;

        for (var i = 0; i < _variant.LoadedResistors.Length; i++)
        {
            var keyStatus = _variant.Keys[i].IsKeyOff ? 0 : 1;
            conductivity += 1 / (_variant.LoadedResistors[i] * _randomValue) * keyStatus;
        }

        var keyStatusOfKeyK = _variant.Keys[8].IsKeyOff ? 0 : 1;
        _totalResistanceOfLoadedResistors = 1 / (keyStatusOfKeyK * MathF.Pow(10, 10) + conductivity);
    }
}
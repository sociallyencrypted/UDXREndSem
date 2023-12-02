using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    private InputData _inputData;

    private float _rightZ = 0f;
    private float _meanRightZ = 0f;

    public TextMeshProUGUI _rightZText;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame

    public void CalibrateMeanZPosition()
    {
        _inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rightPosition);
        _meanRightZ = rightPosition.z;
    }
    void Update()
    {
        if (_meanRightZ == 0f)
        {
           _rightZText.text = "x";
        }
        else if (_inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rightPosition))
        {
            _rightZ = rightPosition.z;
            float difference = _rightZ - _meanRightZ;
            // measure breathing of a person using the controller
            // person has controller on their stomach
            // when they breathe in, the controller moves away from the body
            // when they breathe out, the controller moves towards the body
            // the difference between the mean and the current position is the breathing
            // display the difference up to the nearest 0.01 float
            _rightZText.text = difference.ToString("F2");
        }
    }
}

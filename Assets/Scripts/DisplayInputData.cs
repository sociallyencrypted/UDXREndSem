using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    public TextMeshProUGUI leftXText;
    public TextMeshProUGUI leftYText;
    public TextMeshProUGUI leftZText;
    public TextMeshProUGUI rightXText;
    public TextMeshProUGUI rightYText;
    public TextMeshProUGUI rightZText;
    
    private InputData _inputData;

    private float _leftX = 0f;
    private float _leftY = 0f;
    private float _leftZ = 0f;
    private float _rightX = 0f;
    private float _rightY = 0f;
    private float _rightZ = 0f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 leftPosition))
        {
            _leftX = leftPosition.x;
            _leftY = leftPosition.y;
            _leftZ = leftPosition.z;
            leftXText.text = _leftX.ToString("F2");
            leftYText.text = _leftY.ToString("F2");
            leftZText.text = _leftZ.ToString("F2");
        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rightPosition))
        {
            _rightX = rightPosition.x;
            _rightY = rightPosition.y;
            _rightZ = rightPosition.z;
            rightXText.text = _rightX.ToString("F2");
            rightYText.text = _rightY.ToString("F2");
            rightZText.text = _rightZ.ToString("F2");
        }
    }
}

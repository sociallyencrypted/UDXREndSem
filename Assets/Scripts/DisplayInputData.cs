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
    public GameObject _calibrationPanel;
    public GameObject _videoPlayer;
    public GameObject _text;
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
        // hide the panel and show the video player
        _calibrationPanel.SetActive(false);
        _videoPlayer.SetActive(true);
        _text.SetActive(true);
    }
    void Update()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rightPosition))
        {
            _rightZ = rightPosition.z;
            float difference = _rightZ - _meanRightZ;
            // measure breathing of a person using the controller
            // person has controller on their stomach
            // when they breathe in, the controller moves away from the body
            // when they breathe out, the controller moves towards the body
            // the difference between the mean and the current position is the breathing
            // display the difference up to the nearest 0.01 float
            if (difference > 0)
            {
                if (difference < 0.01f)
                {
                    _rightZText.text = "breathe in more";
                }
                else
                {
                    _rightZText.text = "you're doing good!";
                }
            }
            else
            {
                if (difference > -0.01f)
                {
                    _rightZText.text = "breathe out more";
                }
                else
                {
                    _rightZText.text = "you're doing good!";
                }
            }
        }
    }
}

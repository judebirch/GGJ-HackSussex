using System;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    public event Action<float> BelowLowThreshold;
    public event Action<float> AboveHighThreshold;

    [SerializeField] private int _sampleWindow = 64;
    [SerializeField] private float _lowThreshold;
    [SerializeField] private float _highThreshold;

    private AudioClip _microphoneClip;
    private string _microphoneName;
    private bool _listening;
    private float _currentLoudness;

    public float lowThreshold => _lowThreshold;
    public float highThreshold => _highThreshold;
    public bool isListening => _listening;
    public float currentLoudness => _currentLoudness;

    void Awake()
    {
        _microphoneName = Microphone.devices[0];
        _microphoneClip = Microphone.Start(_microphoneName, true, 20, AudioSettings.outputSampleRate);
        if (_microphoneClip != null)
            _listening = true;
        else
            this.enabled = false;

        AboveHighThreshold += (v) => Debug.Log("High volume!");

    }

    void Update()
    {
        _currentLoudness = GetLoudnessFromAudioClip(Microphone.GetPosition(_microphoneName), _microphoneClip, _sampleWindow);
        if (_currentLoudness < _lowThreshold)
            BelowLowThreshold?.Invoke(_currentLoudness);
        else if (_currentLoudness > _highThreshold)
            AboveHighThreshold?.Invoke(_currentLoudness);
    }

    public static float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip, int sampleWindow)
    {
        var startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) return 0;

        var waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute loudness
        var totalLoudness = 0f;

        for (var i = 0; i < sampleWindow; ++i)
            totalLoudness += Mathf.Abs(waveData[i]);

        return totalLoudness / sampleWindow;
    }
}
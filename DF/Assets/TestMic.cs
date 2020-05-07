using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMic : MonoBehaviour
{
    // Start is called before the first frame update
    public float Volume=-80;
    AudioSource audioSource;
    AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource)
        {
            if (Microphone.devices.Length > 0)
            {
                // Debug.Log(Microphone.devices[0].ToString());
                audioSource.clip = Microphone.Start(Microphone.devices[0].ToString(), true, 10, AudioSettings.outputSampleRate);
                audioClip = audioSource.clip;
            }
        }
    }
    int _sampleWindow = 128;

    float GetMicVolumeInDB()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1);
        if (micPosition < 0) return 0;
        audioClip.GetData(waveData, micPosition);
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return 20 * Mathf.Log10(Mathf.Abs(levelMax));
    }
    // Update is called once per frame
    void Update()
    {

        Volume = GetMicVolumeInDB();
        Debug.Log(Volume);
    }
}

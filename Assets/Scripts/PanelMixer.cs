using UnityEngine;
using UnityEngine.Audio;

public class PanelMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    float _minVolume = -80;
    float _currentMasterVolume = 0;

    public void ToggleMusic()
    {
        if (_mixer.GetFloat("MasterVolume", out float masterVolume) && masterVolume != _minVolume)
        {
            _currentMasterVolume = masterVolume;
            _mixer.SetFloat("MasterVolume", _minVolume);
        }
        else
        {
            _mixer.SetFloat("MasterVolume", _currentMasterVolume);
        }
    }

    public void ChangeMasterVolume(float masterVolume)
    {
        _mixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
    }
    
    public void ChangeEffectVolume(float effectVolume)
    {
        _mixer.SetFloat("EffectVolume", Mathf.Log10(effectVolume) * 20);
    }
    
    public void ChangeMusicVolume(float musicVolume)
    {
        _mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }
}

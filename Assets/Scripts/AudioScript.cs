using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;

    public void ChangeMusicMaster()
    {
        audioMixer.SetFloat("MasterVolume", masterSlider.value);
    }
   
}

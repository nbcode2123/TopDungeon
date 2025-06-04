using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceUI;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider UISlider;


    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }

    }

    private void OnDestroy()
    {


        ObserverManager.RemoveListener<string>("Audio", ActiveAudioClip);
    }

    public List<AudioClipComponent> DicAudioClip = new List<AudioClipComponent>();
    [Serializable]
    public class AudioClipComponent
    {
        public string TagAudio;
        public string TagAudioSource;
        public AudioClip AudioClip;

    }


    // Start is called before the first frame update
    void Start()
    {
        ActiveAudioClip("MusicLobby");
        ObserverManager.AddListener<string>("Audio", ActiveAudioClip);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        UISlider.onValueChanged.AddListener(SetUIVolume);
        // ObserverManager.AddListener("DungeonStart",)
        // ObserverManager.Notify("DungeonStart");






    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
    }
    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
    }
    public void SetUIVolume(float value)
    {
        audioMixer.SetFloat("UIVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);

    }

    private void OnDisable()
    {
        ObserverManager.RemoveListener<string>("Audio", ActiveAudioClip);
    }
    public void ActiveAudioClip(string tag)
    {
        AudioClipComponent audioClipComponent = DicAudioClip.Find(p => p.TagAudio == tag);

        if (audioClipComponent != null)
        {
            if (audioClipComponent.TagAudioSource == "Music")
            {
                audioSourceMusic.clip = audioClipComponent.AudioClip;
                audioSourceMusic.loop = true;
                audioSourceMusic.Play();
            }
            else if (audioClipComponent.TagAudioSource == "SFX")
            {
                audioSourceSFX.clip = audioClipComponent.AudioClip;
                audioSourceSFX.loop = false;
                audioSourceSFX.PlayOneShot(audioClipComponent.AudioClip);
            }
            else if (audioClipComponent.TagAudioSource == "UI")
            {
                audioSourceUI.clip = audioClipComponent.AudioClip;
                audioSourceUI.loop = false;
                audioSourceUI.PlayOneShot(audioClipComponent.AudioClip);
            }
            else return;
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

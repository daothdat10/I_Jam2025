using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundType
{
    button,
    collider,
    nam_tay,
    jump,
    game_over
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    public float musicVolume { get => musicSource.volume; }

    [SerializeField] private AudioSource sfxSource;
    public float sfxVolume { get => sfxSource.volume; }

    [SerializeField] private AudioClip[] backGroundMusic; // Danh sách nhạc nền cho các scene

    [SerializeField] private List<soundList> sfxClips;

    private Dictionary<SoundType, AudioClip> sfxClipDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Khởi tạo dictionary cho SFX
        sfxClipDictionary = new Dictionary<SoundType, AudioClip>();
    }

    private void Start()
    {
        InitializeSFXDictionary();
        PlayMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Thay đổi nhạc nền dựa trên scene index
        ChangeBackgroundMusic(scene.buildIndex);
    }

    private void InitializeSFXDictionary()
    {
        sfxClipDictionary = new Dictionary<SoundType, AudioClip>();
        foreach (var soundClip in sfxClips)
        {
            sfxClipDictionary.Add(soundClip.soundType, soundClip.sounds);
        }
    }

    public void PlayMusic()
    {
        if (backGroundMusic != null && backGroundMusic.Length > 0)
        {
            musicSource.clip = backGroundMusic[0]; // Mặc định phát nhạc nền đầu tiên
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void ChangeBackgroundMusic(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < backGroundMusic.Length)
        {
            musicSource.Stop(); // Dừng nhạc hiện tại
            musicSource.clip = backGroundMusic[sceneIndex]; // Đặt nhạc nền mới
            musicSource.loop = true; // Lặp lại nhạc nền
            musicSource.Play(); // Phát nhạc
        }
        else
        {
            Debug.LogWarning("SoundManager: Scene index out of range - " + sceneIndex);
        }
    }

    public void PlaySfx(SoundType soundEffect)
    {
        if (sfxClipDictionary.ContainsKey(soundEffect))
        {
            sfxSource.PlayOneShot(sfxClipDictionary[soundEffect]);
        }
        else
        {
            Debug.LogWarning("SoundManager: SFX not found in dictionary - " + soundEffect);
        }
    }

    public void StopSfx(SoundType soundEffect)
    {
        if (sfxClipDictionary.ContainsKey(soundEffect))
        {
            this.sfxSource.Stop();
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

[Serializable]
public struct soundList
{
    public SoundType soundType;
    public AudioClip sounds;
}
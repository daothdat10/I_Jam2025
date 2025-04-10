using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class Sound_Setting : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button saveButton;   // Nút "Lưu"
    public Button cancelButton; // Nút "Hủy"

    private float lastMusicVolume; // Lưu giá trị volume trước khi chỉnh
    private float lastSFXVolume;
    private GameData _data;
   
    private void Start()
    {
        // Load giá trị volume ban đầu
        _data = SystemSave.Load();
        musicSlider.value = _data.volumeMusic;
        sfxSlider.value = _data.volumesfx;

        // Lưu lại giá trị gốc
        _data.volumeMusic =lastMusicVolume;
        _data.volumesfx = lastSFXVolume ;

        // Thiết lập sự kiện cho nút
        saveButton.onClick.AddListener(SaveSettings);
        cancelButton.onClick.AddListener(CancelSettings);
    }

    // Gọi khi ấn "Lưu"
    private void SaveSettings()
    {
        // Cập nhật volume thực tế
        UpdateVolume();

        // Lưu vào file
        _data = new GameData
        {
            volumeMusic = musicSlider.value,
            volumesfx = sfxSlider.value
        };
        SystemSave.Save(_data);

        // Cập nhật giá trị gốc mới
        lastMusicVolume = musicSlider.value;
        lastSFXVolume = sfxSlider.value;
    }

    // Gọi khi ấn "Hủy"
    private void CancelSettings()
    {
        // Khôi phục giá trị trước đó
        musicSlider.value = lastMusicVolume;
        sfxSlider.value = lastSFXVolume;

        // Cập nhật lại volume (không lưu file)
        UpdateVolume();
    }

    // Áp dụng volume hiện tại (không lưu)

    
    public void UpdateVolume()
    {
        if (AudioManager.instance != null)
        {
            foreach (Sound s in AudioManager.instance.sounds)
            {
                s.source.volume = musicSlider.value;
            }
            foreach (SoundFX s in AudioManager.instance.soundFXs)
            {
                s.sourceFX.volume = sfxSlider.value;
            }
        }
    }
}
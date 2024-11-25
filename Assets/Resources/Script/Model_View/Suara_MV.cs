using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class Suara_MV : MonoBehaviour
{

    private Suara suara;
    public Suara_MV(Suara suara)
    {
        this.suara = suara;
    }

    public Suara_MV()
    {
    }
    private bool isRed = false; // Flag untuk mengecek apakah warna tombol sudah merah

    public void PlaySoundEffect(string index, AudioSource audio)
    {
        if (suara.clip == null || audio == null)
        {
            Debug.LogError("Audio clips or AudioSource is not properly assigned!");
            return;
        }

        // Assuming `suara.clip` is a List or Array of AudioClip
        var clip = suara.clip.FirstOrDefault(item => item.name == index);

        if (clip != null)
        {
            audio.clip = clip;
            audio.Play();

            GameObject button = GameObject.Find(index);
            if (button != null)
            {
                Button btn = button.GetComponent<Button>();
                if (btn != null)
                {
                    ColorBlock colors = btn.colors;

                    // Ubah semua warna
                    colors.normalColor = Color.white;  // Warna normal
                    colors.pressedColor = Color.red;  // Warna saat ditekan
                    colors.selectedColor = Color.green;  // Warna saat dipilih

                    btn.colors = colors;

                    // Menjalankan event onClick
                    btn.onClick.Invoke();

                    // Memastikan tombol dipilih
                    btn.Select();

                    colors.selectedColor = Color.white;  // Warna saat dipilih

                }
            }
        }
        else
        {
            Debug.LogWarning($"Audio clip with name '{index}' not found.");
        }
    }


    /// <summary>
    /// Mengambil Audio Clip Pada Folder Resources/Sound
    /// </summary>
    /// <returns></returns>
    public AudioClip[] GetSoundEffect() 

    {


        AudioClip[] data = Resources.LoadAll<AudioClip>("Sound");

        return data;
    } 


  
}

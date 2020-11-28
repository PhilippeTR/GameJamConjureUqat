using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bytes;

[System.Serializable]
[SerializeField]
public class AudioClipWithVolume
{
    public AudioClipWithVolume(string name, float vol = 1f) { Name = name; Volume = vol; }
    public string Name;
    public float Volume = 1f;
}

public class PlaySoundData : Bytes.Data
{
    static int NB_VARIATIONS = 1;
    static float VOLUME = -1f;
    static float PITCH_RANGE = 0f;

    public PlaySoundData(string name, float vol = -1f, int nbVariations = 1) { Name = name; Volume = vol; NbVariations = nbVariations; PitchRange = PITCH_RANGE; }
    public PlaySoundData(string name, float randomPitchRange) { Name = name; Volume = VOLUME; NbVariations = NB_VARIATIONS; PitchRange = randomPitchRange; }
    public string Name { get; private set; }
    public float Volume { get; private set; }
    public int NbVariations { get; private set; }
    public float PitchRange { get; private set; }
}

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioSource musicSource;
    public AudioSource ambient;

    public AudioClip musicSound;
    public AudioClip ambientSound;

    private void Start()
    {
        EventManager.AddEventListener("playSound", PlaySound);
        EventManager.AddEventListener("playPopSound", (data)=> {
            PlaySound(new PlaySoundData("pop", 1f));
        });

        MusicNormal();
    }

    private void MusicNormal()
    {
        musicSource.Stop();
        ambient.Stop();

        musicSource.clip = musicSound;
        ambient.clip = ambientSound;

        musicSource.Play();
        ambient.Play();
    }
    private void PlaySound(Bytes.Data data)
    {
        PlaySoundData soundData = (PlaySoundData)data;
        float vol = soundData.Volume * source.volume;
        if (soundData.Volume == -1) { vol = source.volume; }

        string variation = "";
        if (soundData.NbVariations > 1) { variation = "_" + Random.Range(1, soundData.NbVariations).ToString(); }
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + soundData.Name + variation);

        if (clip != null)
            source.PlayOneShot(clip, vol);
        //else
            //Debug.LogError("Sounds/" + soundData.Name + " doesnt exist!");
    }
}

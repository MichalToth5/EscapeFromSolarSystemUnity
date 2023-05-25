using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSystem : MonoBehaviour
{
    private int sfxChannels = 24;
    private GameObject sfxChannelsGroup;

    public List<SfxChannel> audioChannels = new List<SfxChannel>();



    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        // create group of objects
        sfxChannelsGroup = new GameObject("(SFX)");
        sfxChannelsGroup.transform.parent = this.transform;

        // create sfx channel
        for (int ch = 0; ch < sfxChannels; ch++)
        {
            GameObject sfxObject = new GameObject("Audio_Ch_" + ch);
            sfxObject.transform.parent = sfxChannelsGroup.transform;

            audioChannels.Add(new SfxChannel(sfxObject, sfxObject.AddComponent<AudioSource>(), false));

            sfxObject.GetComponent<AudioSource>().loop = false;

            //set 3D sound
            sfxObject.GetComponent<AudioSource>().spatialBlend = 1f;
            sfxObject.GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
            sfxObject.GetComponent<AudioSource>().maxDistance = 20f;
        }
    }

    public void PlaySound(Vector2 worldPos, AudioClip sound, float relativeSoundVolume, float pitch)
    {
        int freeChannel = -1;

        for (int ch = 0; ch < audioChannels.Count; ch++)
        {
            if (freeChannel == -1)
            {
                if (!audioChannels[ch].audioSource.isPlaying)
                {
                    freeChannel = ch;
                }
            }
        }
        if (freeChannel != -1)
        {
            audioChannels[freeChannel].audioObject.transform.position = worldPos;
            audioChannels[freeChannel].audioSource.volume = relativeSoundVolume;
            audioChannels[freeChannel].audioSource.clip = sound;
            audioChannels[freeChannel].audioSource.pitch = pitch;
            audioChannels[freeChannel].audioSource.Play();
        }
    }
}

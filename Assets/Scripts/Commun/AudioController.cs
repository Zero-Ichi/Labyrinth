using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour 
{

    [SerializeField]
    List<string> names = new List<string>();
    [SerializeField]
    List<AudioClip> sounds = new List<AudioClip>();

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        int index = names.FindIndex(x => x == soundName);
        if (index < sounds.Count && index >= 0)
        {
            audioSource.PlayOneShot(sounds[index]);
        }
    }
}

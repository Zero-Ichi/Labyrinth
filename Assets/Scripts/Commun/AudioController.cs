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
        //FindIndex(x => x == soundName) est du linq
        //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries
        int index = names.FindIndex(x => x == soundName);

        // Vérifie que l'index trouvé n'est pas supérieur au nombre d'élément dans laliste
        // et qu'il n'est pas négatif
        if (index < sounds.Count && index >= 0)
        {
            //Joue le son
            audioSource.PlayOneShot(sounds[index]);
        }
    }
}

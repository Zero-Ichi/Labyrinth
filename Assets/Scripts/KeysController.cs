using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject parent;
    private MeshRenderer meshRenderer;
    private Collider boxCollider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        parent = this.transform.parent.transform.gameObject;
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<Collider>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnCollisionEnter est appelé quand ce collider/rigidbody commence à toucher un autre rigidbody/collider
    //Ne pas utiliser si on n'a pas besoin d'infos (Point d'impact ...) sur la collision (la c'pour l'exemple)
    //Car plus gourment en ressources
    private void OnCollisionEnter(Collision collision)
    {
        //Si c'est le player qui rentre en contact avec le GameObject
        if (collision.collider.tag == "Player")
        {
            //Joue le son de l'audio source
            PlaySound();
            //Cache le composant
            Hide();
            //utilisation du parent pour récuperer le tag
            collision.collider.GetComponent<PlayerController>().KeysTag.Add(parent.tag);
            //destruction du parents et tous ses enfants avec un delay de deux secondes 
            //pour attendre la fin de toutes les autre interaction (Son, animation ...)
            Destroy(parent, 1f);
            //Plus aucune interaction possible sous le destroy 
            //vue que c'est détruit (Impossible de lance le son par exemple)


        }
    }
    /// <summary>
    /// Joue le son de l'audio source
    /// </summary>
    public void PlaySound()
    {
        audioSource.Play();
     
    }
    /// <summary>
    /// Hide gameobject
    /// </summary>
    private void Hide()
    {
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
    }
}

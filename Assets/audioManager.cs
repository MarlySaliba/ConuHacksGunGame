using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip background;


    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundEfect1 : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip Backround;
    public AudioClip Gunshots;



    private void Start()
    {
        musicSource.clip = Backround;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        Debug.Log("play!");
    }
}

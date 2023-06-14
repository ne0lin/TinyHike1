using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip backgroundmusic;
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = backgroundmusic;
        musicSource.Play();

        SFXSource.clip = background;
        SFXSource.Play();
        
    }

    //public void PlaySFX(AudioClip clip)
    //{
    //    SFXSource.PlayOneShot(clip);
    //}
}

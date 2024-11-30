using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    // Update is called once per frame
    
    [Header("------------- Audio Clip --------------")]
    public AudioClip background;
    public AudioClip death;

    private void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void Stop(){
        musicSource.clip = background;
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip){//manda o efeito sonoro para tocar 1 vez....
        SFXSource.PlayOneShot(clip);
    }
}

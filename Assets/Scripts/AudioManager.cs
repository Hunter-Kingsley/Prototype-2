using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    public AudioClip collect;
    public AudioClip dash;

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}

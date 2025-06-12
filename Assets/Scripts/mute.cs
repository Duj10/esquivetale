using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    public AudioSource audioSource;

    private static PersistentMusic instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Test : force la musique à jouer
        if (!audioSource.isPlaying)
            audioSource.Play();

        // Toujours restaurer l'état du mute ici
        if (PlayerPrefs.HasKey("Muted"))
        {
            audioSource.mute = PlayerPrefs.GetInt("Muted") == 1;
        }
    }

    public void ToggleMute()
    {
        // Inversez l'état de la sourdine
        audioSource.mute = !audioSource.mute;

        // Sauvegarder l'état de la sourdine
        PlayerPrefs.SetInt("Muted", audioSource.mute ? 1 : 0);
        PlayerPrefs.Save();
    }
}

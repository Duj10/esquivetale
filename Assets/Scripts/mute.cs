using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    public AudioSource audioSource;

    private static PersistentMusic instance = null;

    private void Awake()
    {
        // Vérifiez s'il y a déjà une instance de PersistentMusic
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Restaurer l'état de la sourdine
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

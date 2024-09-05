using UnityEngine;
using UnityEngine.UI;

public class GestionDesBoutons : MonoBehaviour
{
    [SerializeField] Button boutonOn;
    [SerializeField] Button boutonOff;
    [SerializeField] AudioSource music;

    private void Start()
    {
        boutonOn.gameObject.SetActive(false);
        boutonOn.onClick.AddListener(ActiverMusique);
        boutonOff.onClick.AddListener(DesactiverMusique);
    }

    private void ActiverMusique()
    {
        music.Play(); // Activez la musique
        boutonOn.gameObject.SetActive(false);
        boutonOff.gameObject.SetActive(true);
    }

    private void DesactiverMusique()
    {
        music.Stop();
        boutonOff.gameObject.SetActive(false);
        boutonOn.gameObject.SetActive(true); 
    }
}

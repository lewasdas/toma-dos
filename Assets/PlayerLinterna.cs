using UnityEngine;

public class LinternaController : MonoBehaviour
{
    public Light linterna;
    public AudioClip sonidoEncender;
    public AudioClip sonidoApagar;
    public AudioSource audioSource; // ← asignable desde el inspector

    private bool encendida = true;

    void Start()
    {
        // Ya no usamos GetComponent, lo asignás desde el Inspector
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK DETECTADO");

            encendida = !encendida;
            if (linterna != null)
                linterna.enabled = encendida;

            if (audioSource != null)
            {
                Debug.Log("AudioSource EXISTE");
                audioSource.clip = encendida ? sonidoEncender : sonidoApagar;

                if (audioSource.clip != null)
                    Debug.Log("Clip asignado: " + audioSource.clip.name);
                else
                    Debug.LogWarning("Clip NO asignado");

                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("No se encontró AudioSource");
            }
        }
    }
}


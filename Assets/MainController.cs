using UnityEngine;

public class EventoTiempo : MonoBehaviour
{
    public float tiempoParaEvento = 600f; // 10 minutos en segundos
    public AudioSource fuenteDeSonido;

    private float temporizador = 0f;
    private bool eventoActivado = false;

    void Update()
    {
        if (eventoActivado) return;

        temporizador += Time.deltaTime;

        if (temporizador >= tiempoParaEvento)
        {
            ActivarEvento();
        }
    }

    void ActivarEvento()
    {
        if (fuenteDeSonido != null)
        {
            fuenteDeSonido.Play();
            Debug.Log("🎧 Evento sonoro activado tras 10 minutos.");
        }
        eventoActivado = true;
    }
}

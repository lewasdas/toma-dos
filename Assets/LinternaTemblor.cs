using UnityEngine;

public class LinternaTemblor : MonoBehaviour
{
    public float intensidadRotacion = 0.5f; // Cuánto se mueve (grados)
    public float velocidad = 1.5f;          // Qué tan rápido vibra

    private Vector3 rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.localEulerAngles;
    }

    void Update()
    {
        float temblorX = Mathf.Sin(Time.time * velocidad) * intensidadRotacion;
        float temblorY = Mathf.Cos(Time.time * velocidad * 0.8f) * intensidadRotacion;

        Vector3 nuevaRotacion = rotacionInicial + new Vector3(temblorX, temblorY, 0);
        transform.localEulerAngles = nuevaRotacion;
    }
}

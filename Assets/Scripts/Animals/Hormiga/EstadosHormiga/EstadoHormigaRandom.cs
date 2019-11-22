using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaRandom : IEstadoHormiga {
    float time;
    bool isWaiting;

    public EstadoHormigaRandom() {
        time = 0f;
        isWaiting = false;
    }

    public IEstadoHormiga Update(Hormiga h) {

        if (isWaiting) {
            if (Time.time - time > 2) {
                isWaiting = false;
            }
        } else {
            h.nma.destination = h.transform.position + new Vector3((Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4);

            time = Time.time;
            isWaiting = true;
        }

        return h.eBuscar;
    }
}

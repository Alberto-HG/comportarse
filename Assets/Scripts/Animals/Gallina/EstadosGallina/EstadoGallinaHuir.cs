﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaHuir : IEstadoGallina {
    public Transform target;
    float time = 0f;
    public bool colision = false;

    public IEstadoGallina Update(Gallina g) {
        if (target == null) {
            return g.eBuscar;
        }

        float distance = Vector3.Distance(g.transform.position, target.position);

        if (distance > 10) {
            target = null;
            return g.eBuscar;
        }

        if (g.fuerza > 10 && Time.time - time > 1f) {
            g.fuerza -= 1;
        }

        if (g.velocidad > 1f && Time.time - time > 1f) {
            g.velocidad -= 0.5f;
            g.nma.speed = g.velocidad;
            time = Time.time;
        }

        if (!colision) {
            Vector3 dir = (g.transform.position - target.position).normalized;

            g.nma.destination = g.transform.position + (dir * 2);
            return g.eHuir;
        } else {
            colision = false;

            g.eAtacar.target = target;
            target = null;
            return g.eAtacar;
        }
    }
}

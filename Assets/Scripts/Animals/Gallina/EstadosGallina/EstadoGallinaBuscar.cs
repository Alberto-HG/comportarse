﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaBuscar : IEstadoGallina {
    public IEstadoGallina Update(Gallina g) {
        Collider closestEnemy = null;

        foreach (Collider col in g.visionList) {
            if (closestEnemy == null) {
                closestEnemy = col;
            } else {
                if (Vector3.Distance(col.transform.position, g.transform.position) < Vector3.Distance(closestEnemy.transform.position, g.transform.position)) {
                    closestEnemy = col;
                }
            }
        }

        if (closestEnemy != null) {
            g.ePerseguir.target = closestEnemy.transform;
            return g.ePerseguir;
        } else {
            return g.eRandom;
        }
    }
}
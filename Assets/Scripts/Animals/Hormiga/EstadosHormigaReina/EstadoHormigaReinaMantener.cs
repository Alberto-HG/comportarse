using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHormigaReinaMantener : IEstadoHormigaReina {
    public IEstadoHormigaReina Update(HormigaReina h) {
        Collider closestEnemy = null;

        //Recorre los objetivos en su vision y se queda con el mas cercano
        foreach (Collider col in h.sonarList) {
            if (col != null) {
                if (closestEnemy == null) {
                    closestEnemy = col;
                } else {
                    if (Vector3.Distance(col.transform.position, h.transform.position) < Vector3.Distance(closestEnemy.transform.position, h.transform.position)) {
                        closestEnemy = col;
                    }
                }
            }
        }

        //Si ha encontrado un enemigo huye
        if (closestEnemy != null) {
            h.eHuir.target = closestEnemy.transform;
            return h.eHuir;
        } else {
            return h.eMantener;
        }
    }
}

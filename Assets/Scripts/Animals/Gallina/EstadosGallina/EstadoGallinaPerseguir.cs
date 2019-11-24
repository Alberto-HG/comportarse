using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaPerseguir : IEstadoGallina {
    public Transform target;
    public bool colision = false;

    public IEstadoGallina Update(Gallina g) {
        //Si ha muerto el objetivo, volver a buscar
        if (target == null) {
            return g.eBuscar;
        }

        //Mientras no estamos cerca mantener el objetivo
        if (!colision) {
            g.nma.destination = target.position;
            return g.ePerseguir;
        } else {
            //Si se alcanza al objetivo se mira si se pueden agrupar 3 o mas gallinas. Si se puede se ataca, si no, se huye
            colision = false;

            int numGrupo = 0;
            int gLibres = 0;

            foreach (Gallina og in Settings.gallinas) {
                if (og.ePerseguir.target == target) {
                    numGrupo++;
                }

                if (og.ePerseguir.target == null) {
                    gLibres++;
                }
            }

            if (numGrupo + gLibres > 2) {
                foreach (Gallina og in Settings.gallinas) {
                    if (og.ePerseguir.target == null) {
                        og.ePerseguir.target = target;
                        og.estado = og.ePerseguir;
                    }
                }
                g.eAtacar.target = target;
                target = null;
                return g.eAtacar;
            } else {
                g.eHuir.target = target;
                target = null;
                return g.eHuir;
            }
        }
    }
}

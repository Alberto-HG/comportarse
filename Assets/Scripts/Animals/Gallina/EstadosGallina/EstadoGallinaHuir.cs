using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoGallinaHuir : IEstadoGallina {
    public IEstadoGallina Update(Gallina g) {
        return g.eBuscar;
    }
}

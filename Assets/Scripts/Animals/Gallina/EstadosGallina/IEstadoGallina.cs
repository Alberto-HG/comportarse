using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de los estados de la gallina
public interface IEstadoGallina {
    IEstadoGallina Update(Gallina g);
}

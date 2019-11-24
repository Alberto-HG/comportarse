using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de los estados de la hormiga reina
public interface IEstadoHormigaReina {
    IEstadoHormigaReina Update(HormigaReina h);
}

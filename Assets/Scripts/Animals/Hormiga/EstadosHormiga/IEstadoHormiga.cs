using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de los estados de la hormiga
public interface IEstadoHormiga {
    IEstadoHormiga Update(Hormiga h);
}

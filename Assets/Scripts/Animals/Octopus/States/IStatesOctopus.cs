using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz del pulpo.
public interface IStatesOctopus {
    IStatesOctopus Update(Octopus o);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de estados del TRex
public interface IStatesTRex
{
    IStatesTRex Update(TRex t);
}

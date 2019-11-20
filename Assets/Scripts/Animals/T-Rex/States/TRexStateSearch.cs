using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex
{

    public int speed = 5;

    void Update(TRex t)
    {
        return t.searchState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexStateSearch : IStatesTRex {
    public int speed = 5;

    public IStatesTRex Update(TRex t) {
        return t.searchState;
    }
}

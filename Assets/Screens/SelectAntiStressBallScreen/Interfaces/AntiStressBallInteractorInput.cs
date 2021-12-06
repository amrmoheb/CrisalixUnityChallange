using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface AntiStressBallInteractorInput 
{
    void Perform(BallSelectionEvents.Perform.GetColorsForType request);
    void Perform(BallSelectionEvents.Perform.GetSizesForTypeAndColor request);
    void Perform(BallSelectionEvents.Perform.GetMapedColorForKey request);
    void Perform(BallSelectionEvents.Perform.GetOverrideParamter request);
}

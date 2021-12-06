using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AntiStressBallInteractorOutput 
{
    void Present(BallSelectionEvents.Present.UpdateColorsMenu colors);
    void Present(BallSelectionEvents.Present.UpdateSizesMenu sizes);
    void Present(BallSelectionEvents.Present.UpdateStressBallColor settings);
    void Present(BallSelectionEvents.Present.SetColorOverrideSize color);

}

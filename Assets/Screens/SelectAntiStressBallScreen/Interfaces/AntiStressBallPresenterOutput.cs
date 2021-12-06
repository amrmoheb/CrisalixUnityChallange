using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AntiStressBallPresenterOutput 
{
    void Display(BallSelectionEvents.Display.UpdateTypeMenu elements);
    void Display(BallSelectionEvents.Display.UpdateColorMenu colors);
    void Display(BallSelectionEvents.Display.UpdateSizeMenu sizes);
    void Display(BallSelectionEvents.Display.RenderStressBallColor color);
    void Display(BallSelectionEvents.Display.RenderStressBallSize scale);
}

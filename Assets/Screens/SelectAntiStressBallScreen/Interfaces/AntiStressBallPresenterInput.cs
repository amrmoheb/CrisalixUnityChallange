using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AntiStressBallPresenterInput 
{
    void Handle(BallSelectionEvents.Handle.TypeSelected selectedType);
    void Handle(BallSelectionEvents.Handle.ColorSelected selectedColor);
    void Handle(BallSelectionEvents.Handle.SizeSelected selectedSize);
    void Handle(BallSelectionEvents.Handle.UpdateMenu menu);
    void Handle(BallSelectionEvents.Handle.GetOverrideParamter overrideType);

}

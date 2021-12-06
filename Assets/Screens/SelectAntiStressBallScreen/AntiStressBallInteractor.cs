using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AntiStressBallInteractor : MonoBehaviour, AntiStressBallInteractorInput
{
    public AntiStressBallInteractorOutput presenter;
    public AntiStressBallsScriptableObject AntiStreeBallsDataBase;

    #region perform presenter requests
    public void Perform(BallSelectionEvents.Perform.GetColorsForType request)
    {
        List<BallColor> colors = AntiStreeBallsDataBase.colorsOfBallTypes
            .Where(s => s.ballType == request.type)
            .FirstOrDefault().colors.ToList<BallColor>();
        var updateColorMenuRequest = new BallSelectionEvents.Present.UpdateColorsMenu();
        updateColorMenuRequest.colors = colors;
        presenter.Present(updateColorMenuRequest);
    }
    public void Perform(BallSelectionEvents.Perform.GetSizesForTypeAndColor request)
    {
        SizesOfBallType sizeObject = AntiStreeBallsDataBase.sizesOfBallTypes
               .Where(s => s.ballType == request.type)
               .FirstOrDefault();
        var updateSizesMenuRequest = new BallSelectionEvents.Present.UpdateSizesMenu();
            updateSizesMenuRequest.step = AntiStreeBallsDataBase.sizeStep;
            updateSizesMenuRequest.max = sizeObject.maxSize;
            updateSizesMenuRequest.min = sizeObject.minSize;
            presenter.Present(updateSizesMenuRequest);
    }
    public void Perform(BallSelectionEvents.Perform.GetMapedColorForKey request)
    {
        Color mappedColor = AntiStreeBallsDataBase.colorMap
               .Where(s => s.colorKey == request.key)
               .FirstOrDefault().colorValue;
        var updateStressBallRequest = new BallSelectionEvents.Present.UpdateStressBallColor();
        updateStressBallRequest.color = mappedColor;
        if (request.key == AntiStreeBallsDataBase.overrideSize.color)
        {
            var updateSizesMenuRequest = new BallSelectionEvents.Present.UpdateSizesMenu();
            updateSizesMenuRequest.max = AntiStreeBallsDataBase.overrideSize.size;
            updateSizesMenuRequest.min = AntiStreeBallsDataBase.overrideSize.size;
            updateSizesMenuRequest.step = AntiStreeBallsDataBase.sizeStep;
            presenter.Present(updateSizesMenuRequest);
        }
         presenter.Present(updateStressBallRequest);
    }
    public void Perform(BallSelectionEvents.Perform.GetOverrideParamter request)
    {
        var setColorOverrideSizeRequest = new BallSelectionEvents.Present.SetColorOverrideSize();
        setColorOverrideSizeRequest.overrideSizeColor = AntiStreeBallsDataBase.overrideSize.color;
        presenter.Present(setColorOverrideSizeRequest);
    }
    #endregion

}

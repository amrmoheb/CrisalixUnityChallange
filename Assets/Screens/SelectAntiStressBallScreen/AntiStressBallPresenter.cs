using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiStressBallPresenter : MonoBehaviour,AntiStressBallPresenterInput,AntiStressBallInteractorOutput
{
    // Start is called before the first frame update
    public AntiStressBallInteractorInput interactor;
    public AntiStressBallPresenterOutput viewOutput;
    BallType currentBallType;
    BallColor currentBallColor;
    float currentBallSize;
    List<BallColor> currentColorsList;
    List<string> currentSizesList;
    BallColor overrideSizeColor;

    #region Internal Logic
    public void UpdateTypeMenu() 
    {
        List<string> types = new List<string>( System.Enum.GetNames(typeof(BallType)));
        var updateTypeMenuEvent = new BallSelectionEvents.Display.UpdateTypeMenu();
        updateTypeMenuEvent.elements = types;
        viewOutput.Display(updateTypeMenuEvent);
    }
    public void UpdateColorMenu()
    {
        var getColorsRequest = new BallSelectionEvents.Perform.GetColorsForType();
        getColorsRequest.type = currentBallType;
        interactor.Perform(getColorsRequest);
    }
    public void UpdateSizeMenu() 
    {
        var getSizesRequest = new BallSelectionEvents.Perform.GetSizesForTypeAndColor();
        getSizesRequest.type = currentBallType;
        getSizesRequest.color = currentBallColor;
        interactor.Perform(getSizesRequest);
    }
    #endregion

    #region handle ui viewController events
    public void Handle(BallSelectionEvents.Handle.TypeSelected selectedType)
    {
        currentBallType = selectedType.type;
    }
    public void Handle(BallSelectionEvents.Handle.ColorSelected selectedColor)
    {
        if (currentBallColor == overrideSizeColor) {
            currentBallColor = currentColorsList[selectedColor.colorIndex];
            Handle(BallSelectionEvents.Handle.UpdateMenu.sizeMenu);
        }
        currentBallColor = currentColorsList[selectedColor.colorIndex];
        var mapedColorRequest = new BallSelectionEvents.Perform.GetMapedColorForKey();
        mapedColorRequest.key = currentBallColor;
        interactor.Perform(mapedColorRequest);
    }
    public void Handle(BallSelectionEvents.Handle.SizeSelected selectedSize)
    {
        currentBallSize = float.Parse(currentSizesList[selectedSize.sizeIndex]);
        var renderStressBallScaleRequest = new BallSelectionEvents.Display.RenderStressBallSize();
        renderStressBallScaleRequest.scale = currentBallSize;
        viewOutput.Display(renderStressBallScaleRequest);
    }
    public void Handle(BallSelectionEvents.Handle.UpdateMenu menu)
    {
        switch (menu)
        {

            case BallSelectionEvents.Handle.UpdateMenu.typeMenu:
                UpdateTypeMenu();
                break;
            case BallSelectionEvents.Handle.UpdateMenu.colorMenu:
                UpdateColorMenu();
                break;
            case BallSelectionEvents.Handle.UpdateMenu.sizeMenu:
                UpdateSizeMenu();
                break;
            default:
                print("no menu type sent");
                break;
        }
    }
    public void Handle(BallSelectionEvents.Handle.GetOverrideParamter overrideType)
    {
        interactor.Perform(BallSelectionEvents.Perform.GetOverrideParamter.colorOverrideSize);
    }
    #endregion

    #region present interactor response
    public void Present(BallSelectionEvents.Present.UpdateColorsMenu response)
    {
        var updateColorMenuRequest = new BallSelectionEvents.Display.UpdateColorMenu();
        currentColorsList = response.colors;
        List<string> colorsNames = response.colors.ConvertAll(f => f.ToString());
        updateColorMenuRequest.colors = colorsNames;
        viewOutput.Display(updateColorMenuRequest);
    }
    public void Present(BallSelectionEvents.Present.UpdateSizesMenu sizes)
    {
        List<string>  sizesList = new List<string>();
        float sizePointer = sizes.min;
        while (sizePointer <= sizes.max + (sizes.step / 2))
        {

            sizesList.Add(sizePointer.ToString("0.0"));
            sizePointer += sizes.step;
        } 
        var updateSizeMenuRequest = new BallSelectionEvents.Display.UpdateSizeMenu();
        updateSizeMenuRequest.sizes = sizesList;        
        currentSizesList = sizesList;
        viewOutput.Display(updateSizeMenuRequest);
    }
    public void Present(BallSelectionEvents.Present.UpdateStressBallColor realBallColor)
    {
         var sphereRenderRequest = new BallSelectionEvents.Display.RenderStressBallColor();
         sphereRenderRequest.color = realBallColor.color;
         viewOutput.Display(sphereRenderRequest);
    }
    public void Present(BallSelectionEvents.Present.SetColorOverrideSize color)
    {
        overrideSizeColor = color.overrideSizeColor;
    }
    #endregion

}

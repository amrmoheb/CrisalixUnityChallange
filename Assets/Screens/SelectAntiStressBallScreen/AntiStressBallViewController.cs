using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AntiStressBallViewController : MonoBehaviour, AntiStressBallPresenterOutput
{
    // Start is called before the first frame update

    public AntiStressBallPresenterInput presenter;
    public TMP_Dropdown typeSelectionDropDown;
    public TMP_Dropdown colorSelectionDropDown;
    public TMP_Dropdown sizeSelectionDropDown;
    public GameObject stressBallPrefab;
    GameObject generatedStressBall;
    Material generatedStressBallMat;
    Vector3 generatedStressBallscaleVector;
    public void InternalStart()
    {
        generatedStressBallscaleVector = new Vector3();
        generatedStressBall = Instantiate(stressBallPrefab, stressBallPrefab.transform.position, stressBallPrefab.transform.rotation);
        generatedStressBallMat = generatedStressBall.GetComponent<MeshRenderer>().material;
        presenter.Handle(BallSelectionEvents.Handle.GetOverrideParamter.colorOverrideSize);
        presenter.Handle(BallSelectionEvents.Handle.UpdateMenu.typeMenu);
    }

    #region UI Events
    public void OnTypeSelected() {
        var selectedtype = new BallSelectionEvents.Handle.TypeSelected();
        selectedtype.type = (BallType)typeSelectionDropDown.value;
        presenter.Handle(selectedtype);
        presenter.Handle(BallSelectionEvents.Handle.UpdateMenu.colorMenu);
        presenter.Handle(BallSelectionEvents.Handle.UpdateMenu.sizeMenu);
    }
    public void OnColorSelected() {
        var selectedColor = new BallSelectionEvents.Handle.ColorSelected();
        selectedColor.colorIndex = colorSelectionDropDown.value;
        presenter.Handle(selectedColor);
    }
    public void OnSizeSelected() {
        var selectedSize = new BallSelectionEvents.Handle.SizeSelected();
        selectedSize.sizeIndex = sizeSelectionDropDown.value;
        presenter.Handle(selectedSize);
    }

    #endregion

    #region display Presenter response
    public void Display(BallSelectionEvents.Display.UpdateTypeMenu eventResponse)
    {
        typeSelectionDropDown.ClearOptions();
        typeSelectionDropDown.AddOptions(eventResponse.elements);
        OnTypeSelected();
    }

    public void Display(BallSelectionEvents.Display.UpdateColorMenu eventResponse)
    {
        colorSelectionDropDown.ClearOptions();
        colorSelectionDropDown.AddOptions(eventResponse.colors);
        OnColorSelected();
    }

    public void Display(BallSelectionEvents.Display.UpdateSizeMenu eventResponse)
    {
        sizeSelectionDropDown.ClearOptions();
        sizeSelectionDropDown.AddOptions(eventResponse.sizes);
        OnSizeSelected();
    }

    public void Display(BallSelectionEvents.Display.RenderStressBallColor settings)
    {
        generatedStressBallMat.color =  settings.color;
    }

    public void Display(BallSelectionEvents.Display.RenderStressBallSize scale)
    {
        generatedStressBallscaleVector.x = scale.scale;
        generatedStressBallscaleVector.y = scale.scale;
        generatedStressBallscaleVector.z = scale.scale;
        generatedStressBall.transform.localScale = generatedStressBallscaleVector;
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour
{
    public static Router shared = new Router();
    public Transform ViewsParent;
    public GameObject AntiStressBallSelectionScreen;
    public AntiStressBallsScriptableObject AntiStreeBallsDataBase;
    GameObject GeneratedScreen;
    Vector3 ViewsParentPosition;
    // Start is called before the first frame update
    void Awake()
    {
        ViewsParentPosition = ViewsParent.transform.position;
        InialScreen();
    }
    void InialScreen() {
        InstatiateAntiStressBallSelectionScreen();
    }
    // Update is called once per frame

    public void InstatiateAntiStressBallSelectionScreen() {
         GeneratedScreen = Instantiate(AntiStressBallSelectionScreen, ViewsParent);
        AntiStressBallPresenter FullPresenter = new AntiStressBallPresenter();
        AntiStressBallInteractor FullInteractor = new AntiStressBallInteractor();
        AntiStressBallViewController view = GeneratedScreen.GetComponent<AntiStressBallViewController>();
        view.presenter = FullPresenter;
        FullPresenter.interactor = FullInteractor;
        FullPresenter.viewOutput = view;
        FullInteractor.presenter = FullPresenter;
        FullInteractor.AntiStreeBallsDataBase = AntiStreeBallsDataBase;
        view.InternalStart();
    }
}

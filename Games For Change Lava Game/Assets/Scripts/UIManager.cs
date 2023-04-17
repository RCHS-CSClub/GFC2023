using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject DieScreen;
    [SerializeField] GameObject Message1;
    [SerializeField] GameObject Message2;
    [SerializeField] GameObject Message3;
    [SerializeField] GameObject Message4;
    [SerializeField] GameObject Message5;

    public void ToggleDieScreen()
    {
        DieScreen.SetActive(!DieScreen.activeSelf);
    }

    public void SetStage(int index)
    {
        switch(index)
        {
            case 2:
                Message1.SetActive(false);
                Message2.SetActive(true);
                break;
            case 3:
                Message2.SetActive(false);
                Message3.SetActive(true);
                break;
            case 4:
                Message3.SetActive(false);
                Message4.SetActive(true);
                break;
            case 5:
                Message4.SetActive(false);
                Message5.SetActive(true);
                break;
        }
    }
}

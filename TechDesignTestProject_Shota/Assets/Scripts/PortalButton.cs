using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PortalButton : MonoBehaviour
{
    public event UnityAction OnButtonClicked;

    public void OnButtonClick() 
    {
        OnButtonClicked?.Invoke();   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public abstract GameObject Click();
    public abstract void EndHover();
    public abstract void Hover();
    public abstract void Selected();
    public abstract void EndSelected();
}

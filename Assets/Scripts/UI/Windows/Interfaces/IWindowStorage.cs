using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindowStorage 
{
    Dictionary<EWindowType, IWindow> AllWindows {get;}
    IWindow Get(EWindowType windowType);
    
}

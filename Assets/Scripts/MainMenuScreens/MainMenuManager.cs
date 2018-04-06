using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : UIScreenManager
{

    protected override void Awake()
    {
        allowGhost = true;
        base.Awake();
        allowGhost = true;
    }
}

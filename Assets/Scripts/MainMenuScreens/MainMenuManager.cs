using UniFramework.UISystem;

public class MainMenuManager : UIScreenManager
{

    protected override void Awake()
    {
        allowGhost = true;
        base.Awake();
        allowGhost = true;
    }
}

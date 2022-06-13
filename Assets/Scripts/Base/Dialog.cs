namespace Base.UI
{
    using System;
    
    public class Dialog : MyUI
    {
        protected override void Registration()
        {
            base.Registration();
            GeneralPanel.CurrentPanelChanged += OnCurrentPanelChanged;
        }

        private void OnCurrentPanelChanged(GeneralPanel currentPanel)
        {
            if (currentPanel is PanelHome)
                DeActivate();
        }
    }
}

namespace Base.UI
{
    using System;
    
    public class GeneralPanel : BasePanel
    {
        private static GeneralPanel _currentPanel;
        public static GeneralPanel CurrentPanel 
        {
            get => _currentPanel;
            set
            {
                _currentPanel = value;
                CurrentPanelChanged?.Invoke(_currentPanel);
            }
        }
        public static event Action<GeneralPanel> CurrentPanelChanged;

        private Type _prevPanelType;
        public Type PrevPanelType 
        {
            get => _prevPanelType;
            set
            {
                _prevPanelType = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            CurrentPanel = this;
        }
    }
}

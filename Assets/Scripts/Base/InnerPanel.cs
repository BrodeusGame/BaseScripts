namespace Base.UI
{
    using UnityEngine;

    public class InnerPanel : BasePanel
    {
        private GeneralPanel _dependedPanel;
        public GeneralPanel DependedPanel 
        {
            get => _dependedPanel;
            set
            {
                _dependedPanel = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            DependedPanel = GetComponentInParent<GeneralPanel>();
            if (!DependedPanel)
                Debug.LogError("DependedPanel is null!!" + GetType().FullName);
        }

    }
}
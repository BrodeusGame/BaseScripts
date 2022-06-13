namespace Base.UI
{
    using System;
    
    public class BasePanel : MyUI
    {
        public static event Action<BasePanel> PanelInitialized;
        public static event Action<BasePanel> PanelActivated;
        public static event Action<BasePanel> PanelDeActivated;
        public static event Action<BasePanel> PanelDestroyed;

        protected override void Initialize()
        {
            base.Initialize();
            PanelInitialized?.Invoke(this);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            PanelActivated?.Invoke(this);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            PanelDeActivated?.Invoke(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            PanelDestroyed?.Invoke(this);
        }
    }
}

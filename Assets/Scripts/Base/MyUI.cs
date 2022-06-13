namespace Base.UI
{
    using UnityEngine;

    [RequireComponent(typeof(RectTransform))]
    public class MyUI : MyObject
    {
        protected RectTransform _rT;

        protected override void Initialize()
        {
            base.Initialize();
            _rT = GetComponent<RectTransform>();
        }
    }
}

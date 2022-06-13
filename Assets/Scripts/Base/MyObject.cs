namespace Base
{
    using System;
    using UnityEngine;

    public class MyObject : MonoBehaviour
    {
        public virtual int VariantID { get; }

        public event Action Activated;
        public event Action DeActivated;
        public event Action Destroyed;

        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {

        }

        protected virtual void OnEnable()
        {
            Activated?.Invoke();
        }

        protected virtual void OnDisable()
        {
            DeActivated?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            UnRegistration();
            Destroyed?.Invoke();
        }

        protected virtual void Registration()
        {
            Application.quitting += UnRegistration;
        }

        protected virtual void UnRegistration()
        {
            Application.quitting -= UnRegistration;
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void DeActivate()
        {
            gameObject.SetActive(false);
        }
    }
}

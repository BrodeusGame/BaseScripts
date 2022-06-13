namespace Base.UI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class DialogYesNo : BaseDialog
    {
        [SerializeField] private Text _txtTitle;
        [SerializeField] private Text _txtDescription;
        [SerializeField] private Button _btnYes;
        [SerializeField] private Button _btnNo;

        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                _txtTitle.text = _title;
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                _txtDescription.text = _description;
            }
        }

        public event Action BtnYesClicked;
        public event Action BtnNoClicked;

        protected override void Registration()
        {
            base.Registration();
            _btnYes.onClick.AddListener(OnBtnYesClicked);
            _btnNo.onClick.AddListener(OnBtnNoClicked);
        }

        protected override void UnRegistration()
        {
            base.UnRegistration();
            _btnYes.onClick.RemoveListener(OnBtnYesClicked);
            _btnNo.onClick.RemoveListener(OnBtnNoClicked);
        }

        private void OnBtnYesClicked()
        {
            BtnYesClicked?.Invoke();
        }

        private void OnBtnNoClicked()
        {
            BtnNoClicked?.Invoke();
        }
    }
}

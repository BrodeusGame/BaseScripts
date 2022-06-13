namespace Base.UI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public enum DialogOkayType
    {
        DEFAULT,
        DONE,
        ERROR
    }


    public class DialogOkay : BaseDialog
    {
        [SerializeField] private DialogOkayType _type;
        public override int VariantID { get => _type.GetHashCode(); }

        [SerializeField] private Text _txtTitle;
        [SerializeField] private Text _txtDescription;
        [SerializeField] private Button _btnOkay;

        private string _title;
        public string Title 
        {
            get => _title;
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

        public event Action BtnOkayClicked;

        protected override void Registration()
        {
            base.Registration();
            _btnOkay.onClick.AddListener(OnBtnOkayClicked);
        }

        protected override void UnRegistration()
        {
            base.UnRegistration();
            _btnOkay.onClick.RemoveListener(OnBtnOkayClicked);
        }

        private void OnBtnOkayClicked()
        {
            BtnOkayClicked?.Invoke();
        }
    }
}

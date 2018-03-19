using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class ProductType : INotifyPropertyChanged
    {
        #region Static Fields

        private static int LastId
        {
            get { return ApplicationBase.Session.ProductType_LastId; }
            set { ApplicationBase.Session.ProductType_LastId = value; }
        }

        #endregion

        #region Business Properties

        private readonly int _productTypeId;

        public int ProductTypeId
        {
            get { return _productTypeId; }
        }

        private int? _parentProductTypeId;

        public int? ParentProductTypeId
        {
            get { return _parentProductTypeId; }
            set
            {
                if (_parentProductTypeId != value)
                {
                    _parentProductTypeId = value;
                    OnPropertyChanged(nameof(ParentProductTypeId));
                    IsDirty = true;
                }
            }
        }

        private string _productTypeName;

        public string ProductTypeName
        {
            get { return _productTypeName; }
            set
            {
                if (_productTypeName != value)
                {
                    _productTypeName = value;
                    OnPropertyChanged(nameof(ProductTypeName));
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Constructor

        public ProductType()
        {
            _isNew = true;
            IsDirty = false;
            _productTypeId = ++LastId;
            OnPropertyChanged(nameof(ProductTypeId));
        }

        #endregion

        #region Managing State

        private bool _isNew;

        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            private set
            {
                _isDirty = value;
                OnPropertyChanged(nameof(CancelButtonText));
            }
        }

        public string CancelButtonText
        {
            get
            {
                if (_isNew || _isDirty)
                    return "Cancel";

                return "Close";
            }
        }

        internal static void ClearCounter()
        {
            LastId = 0;
        }

        #endregion

        #region Business Methods

        public void Save()
        {
            _isNew = false;
            IsDirty = false;
            if (!ProductTypeList.Contains(ProductTypeId))
            {
                ProductTypeList.GetProductTypeList().Add(this);
            }
        }

        public void Cancel()
        {
            _isNew = false;
            IsDirty = false;
        }

        public void Delete()
        {
            if (ProductTypeList.Contains(ProductTypeId))
                ProductTypeList.GetProductTypeList().Remove(this);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class Supplier : INotifyPropertyChanged
    {
        #region Static Fields

        private static int LastId
        {
            get { return ApplicationBase.Session.Brand_LastId; }
            set { ApplicationBase.Session.Brand_LastId = value; }
        }

        #endregion

        #region Business Properties

        private int _supplierId;

        public int SupplierId
        {
            get { return _supplierId; }
            set
            {
                if (_supplierId != value)
                {
                    _supplierId = value;
                    OnPropertyChanged(nameof(SupplierId));
                    IsDirty = true;
                    if (_supplierId > LastId)
                        LastId = _supplierId;
                }
            }
        }

        private int? _parentSupplierId;

        public int? ParentSupplierId
        {
            get { return _parentSupplierId; }
            set
            {
                if (_parentSupplierId != value)
                {
                    _parentSupplierId = value;
                    OnPropertyChanged(nameof(ParentSupplierId));
                    IsDirty = true;
                }
            }
        }

        private string _supplierName;

        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    OnPropertyChanged(nameof(SupplierName));
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Constructor

        public Supplier(int supplierId, string supplierName, int parentSupplierId)
            : this(supplierId, supplierName)
        {
            _parentSupplierId = parentSupplierId;
        }

        public Supplier(int supplierId, string supplierName)
            : this()
        {
            SupplierId = supplierId;
            _supplierName = supplierName;
        }

        public Supplier()
        {
            _supplierId = ++LastId;
            _isNew = true;
            IsDirty = false;
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
            if (!SupplierList.Contains(SupplierId))
            {
                SupplierList.GetSupplierList().Add(this);
            }
        }

        public void Cancel()
        {
            _isNew = false;
            IsDirty = false;
        }

        public void Delete()
        {
            if (SupplierList.Contains(SupplierId))
            {
                DeleteChild(SupplierId);
                SupplierList.GetSupplierList().Remove(this);
            }
        }

        private static void DeleteChild(int parentSupplirId)
        {
            foreach (var childSupplier in SupplierList.GetChildSuppliers(parentSupplirId))
            {
                var childSupplierId = childSupplier.SupplierId;
                if (SupplierList.Contains(childSupplierId))
                {
                    DeleteChild(childSupplierId);
                    SupplierList.GetSupplierList().Remove(childSupplier);
                }
            }
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
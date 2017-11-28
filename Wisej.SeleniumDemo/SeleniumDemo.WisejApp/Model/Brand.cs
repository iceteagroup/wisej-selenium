using System.ComponentModel;

namespace SeleniumDemo.WisejApp.Model
{
    public class Brand : INotifyPropertyChanged
    {
        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        private readonly int _brandId;

        public int BrandId
        {
            get { return _brandId; }
        }

        private string _brandName;

        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (_brandName != value)
                {
                    _brandName = value;
                    OnPropertyChanged(nameof(BrandName));
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Constructor

        public Brand()
        {
            _isNew = true;
            IsDirty = false;
            _brandId = System.Threading.Interlocked.Increment(ref _lastId);
            OnPropertyChanged(nameof(BrandId));
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
            _lastId = 0;
        }

        #endregion

        #region Business Methods

        public void Save()
        {
            _isNew = false;
            IsDirty = false;
            if (!BrandList.Contains(BrandId))
            {
                BrandList.GetBrandList().Add(this);
            }
        }

        public void Cancel()
        {
            _isNew = false;
            IsDirty = false;
        }

        public void Delete()
        {
            if (BrandList.Contains(BrandId))
                BrandList.GetBrandList().Remove(this);
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
using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class Model : INotifyPropertyChanged
    {
        #region Static Fields

        private static int LastId
        {
            get { return ApplicationBase.Session.Model_LastId; }
            set { ApplicationBase.Session.Model_LastId = value; }
        }

        #endregion

        #region Business Properties

        private readonly int _modelId;

        public int ModelId
        {
            get { return _modelId; }
        }

        private string _modelName;

        public string ModelName
        {
            get { return _modelName; }
            set
            {
                if (_modelName != value)
                {
                    _modelName = value.ToUpper();
                    OnPropertyChanged(nameof(ModelName));
                }
            }
        }

        private int _brandId;

        public int BrandId
        {
            get { return _brandId; }
            set
            {
                if (_brandId != value)
                {
                    _brandId = value;
                    OnPropertyChanged(nameof(BrandId));
                }
            }
        }

        private int _productTypeId;

        public int ProductTypeId
        {
            get { return _productTypeId; }
            set
            {
                if (_productTypeId != value)
                {
                    _productTypeId = value;
                    OnPropertyChanged(nameof(ProductTypeId));
                }
            }
        }

        #endregion

        #region State Properties

        public bool IsNew { get; private set; }

        #endregion

        #region Constructor

        public Model()
        {
            IsNew = true;
            _modelId = ++LastId;
            OnPropertyChanged(nameof(ModelId));
        }

        #endregion

        #region state methods

        internal static void ClearCounter()
        {
            LastId = 0;
        }

        #endregion

        #region Business Methods

        public void Save()
        {
            if (!ModelList.Contains(ModelId))
            {
                ModelList.GetModelList().Add(this);
                IsNew = false;
            }
        }

        public void Delete()
        {
            if (ModelList.Contains(ModelId))
                ModelList.GetModelList().Remove(this);
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
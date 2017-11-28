using System.ComponentModel;

namespace SeleniumDemo.WisejApp.Model
{
    public class ProductTypeList : BindingList<ProductType>
    {
        private static ProductTypeList _instance;

        public static ProductTypeList GetProductTypeList()
        {
            if (_instance == null)
                BuildInstance();

            return _instance;
        }

        public static void ResetData()
        {
            if (_instance == null)
            {
                BuildInstance();
            }
            else
            {
                _instance.Clear();
                ProductType.ClearCounter();

                new ProductType {ProductTypeName = "Dish Washer"}.Save();
                new ProductType {ProductTypeName = "Dryer"}.Save();
                new ProductType {ProductTypeName = "Radio"}.Save();
                new ProductType {ProductTypeName = "Refrigerator"}.Save();
                new ProductType {ProductTypeName = "Vacuum Cleaner"}.Save();
                new ProductType {ProductTypeName = "Washers/Dryer"}.Save();
                new ProductType {ProductTypeName = "Washer"}.Save();
                new ProductType {ProductTypeName = "Set Top Box"}.Save();
                new ProductType {ProductTypeName = "TV"}.Save();
            }
        }

        public static bool Contains(int productTypeId)
        {
            foreach (var productType in _instance)
            {
                if (productType.ProductTypeId == productTypeId)
                    return true;
            }

            return false;
        }

        public static ProductType GetProductType(int productTypeId)
        {
            foreach (var productType in _instance)
            {
                if (productType.ProductTypeId == productTypeId)
                    return productType;
            }

            return null;
        }

        private static void BuildInstance()
        {
            _instance = new ProductTypeList();
            ResetData();
        }
    }
}
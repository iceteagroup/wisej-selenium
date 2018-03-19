using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class ProductTypeList : BindingList<ProductType>
    {
        private static ProductTypeList Instance
        {
            get { return ApplicationBase.Session.ProductTypeList; }
            set { ApplicationBase.Session.ProductTypeList = value; }
        }

        public static ProductTypeList GetProductTypeList()
        {
            if (Instance == null)
                BuildInstance();

            return Instance;
        }

        public static void ResetData()
        {
            if (Instance == null)
            {
                BuildInstance();
            }
            else
            {
                Instance.Clear();
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
                new ProductType {ProductTypeName = "TV Top Box"}.Save();
            }
        }

        public static bool Contains(int productTypeId)
        {
            foreach (var productType in Instance)
            {
                if (productType.ProductTypeId == productTypeId)
                    return true;
            }

            return false;
        }

        public static ProductType GetProductType(int productTypeId)
        {
            foreach (var productType in Instance)
            {
                if (productType.ProductTypeId == productTypeId)
                    return productType;
            }

            return null;
        }

        private static void BuildInstance()
        {
            Instance = new ProductTypeList();
            ResetData();
        }
    }
}
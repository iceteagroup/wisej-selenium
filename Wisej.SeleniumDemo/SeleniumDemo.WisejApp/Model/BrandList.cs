using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class BrandList : BindingList<Brand>
    {
        private static BrandList Instance
        {
            get { return ApplicationBase.Session.BrandList; }
            set { ApplicationBase.Session.BrandList = value; }
        }

        public static BrandList GetBrandList()
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
                Brand.ClearCounter();

                new Brand {BrandName = "Candy"}.Save();
                new Brand {BrandName = "Petroluz"}.Save();
                new Brand {BrandName = "Hoover"}.Save();
                new Brand {BrandName = "Kunft"}.Save();
                new Brand {BrandName = "LLG"}.Save();
                new Brand {BrandName = "LG"}.Save();
                new Brand {BrandName = "Philips"}.Save();
                new Brand {BrandName = "Samsung"}.Save();
                new Brand {BrandName = "Siemens"}.Save();
                new Brand {BrandName = "Whirlpool"}.Save();
            }
        }

        public static bool Contains(int brandId)
        {
            foreach (var brand in Instance)
            {
                if (brand.BrandId == brandId)
                    return true;
            }

            return false;
        }

        public static Brand GetBrand(int brandId)
        {
            foreach (var brand in Instance)
            {
                if (brand.BrandId == brandId)
                    return brand;
            }

            return null;
        }

        private static void BuildInstance()
        {
            Instance = new BrandList();
            ResetData();
        }
    }
}
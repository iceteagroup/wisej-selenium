using System.ComponentModel;

namespace SeleniumDemo.WisejApp.Model
{
    public class BrandList : BindingList<Brand>
    {
        private static BrandList _instance;

        public static BrandList GetBrandList()
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
                Brand.ClearCounter();

                new Brand {BrandName = "Candy"}.Save();
                new Brand {BrandName = "Electroluz"}.Save();
                new Brand {BrandName = "Hoover"}.Save();
                new Brand {BrandName = "Kunft"}.Save();
                new Brand {BrandName = "LG"}.Save();
                new Brand {BrandName = "Philips"}.Save();
                new Brand {BrandName = "Samsung"}.Save();
                new Brand {BrandName = "Siemens"}.Save();
                new Brand {BrandName = "Whirlpool"}.Save();
            }
        }

        public static bool Contains(int brandId)
        {
            foreach (var brand in _instance)
            {
                if (brand.BrandId == brandId)
                    return true;
            }

            return false;
        }

        public static Brand GetBrand(int brandId)
        {
            foreach (var brand in _instance)
            {
                if (brand.BrandId == brandId)
                    return brand;
            }

            return null;
        }

        private static void BuildInstance()
        {
            _instance = new BrandList();
            ResetData();
        }
    }
}
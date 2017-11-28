using System.ComponentModel;

namespace SeleniumDemo.WisejApp.Model
{
    public class ModelList : BindingList<Model>
    {
        private static ModelList _instance;

        public static ModelList GetModelList()
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
                Model.ClearCounter();
                new Model
                {
                    ModelName = "TV 97016",
                    BrandId = 7,
                    ProductTypeId = 9
                }.Save();
                new Model
                {
                    ModelName = "STB 4508",
                    BrandId = 5,
                    ProductTypeId = 8
                }.Save();
            }
        }

        public static bool Contains(int modelId)
        {
            foreach (var model in _instance)
            {
                if (model.ModelId == modelId)
                    return true;
            }

            return false;
        }

        public static Model GetModel(int modelId)
        {
            foreach (var model in _instance)
            {
                if (model.ModelId == modelId)
                    return model;
            }

            return null;
        }

        private static void BuildInstance()
        {
            _instance = new ModelList();
            ResetData();
        }
    }
}
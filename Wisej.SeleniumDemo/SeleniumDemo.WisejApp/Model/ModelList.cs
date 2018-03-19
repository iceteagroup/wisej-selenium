using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class ModelList : BindingList<Model>
    {
        private static ModelList Instance
        {
            get { return ApplicationBase.Session.ModelList; }
            set { ApplicationBase.Session.ModelList = value; }
        }

        public static ModelList GetModelList()
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
                Model.ClearCounter();
                new Model
                {
                    ModelName = "SMSTV 2020H",
                    BrandId = 8,
                    ProductTypeId = 9
                }.Save();
                new Model
                {
                    ModelName = "LG-TOP 4508",
                    BrandId = 6,
                    ProductTypeId = 8
                }.Save();
                new Model
                {
                    ModelName = "SWASH 0377",
                    BrandId = 1,
                    ProductTypeId = 7
                }.Save();
                new Model
                {
                    ModelName = "EZWD 3704",
                    BrandId = 2,
                    ProductTypeId = 6
                }.Save();
                new Model
                {
                    ModelName = "POWER H05",
                    BrandId = 3,
                    ProductTypeId = 5
                }.Save();
                new Model
                {
                    ModelName = "COMBI 150",
                    BrandId = 4,
                    ProductTypeId = 4
                }.Save();
                new Model
                {
                    ModelName = "PH FMAM218",
                    BrandId = 7,
                    ProductTypeId = 3
                }.Save();
                new Model
                {
                    ModelName = "DWASH 9721",
                    BrandId = 9,
                    ProductTypeId = 1
                }.Save();
                new Model
                {
                    ModelName = "WHIRL 0948/DRY",
                    BrandId = 10,
                    ProductTypeId = 2
                }.Save();
                new Model
                {
                    ModelName = "STV 2010",
                    BrandId = 6,
                    ProductTypeId = 9
                }.Save();
                new Model
                {
                    ModelName = "SMSTV 2017",
                    BrandId = 8,
                    ProductTypeId = 9
                }.Save();
                new Model
                {
                    ModelName = "TV 97016",
                    BrandId = 8,
                    ProductTypeId = 9
                }.Save();
            }
        }

        public static bool Contains(int modelId)
        {
            foreach (var model in Instance)
            {
                if (model.ModelId == modelId)
                    return true;
            }

            return false;
        }

        public static Model GetModel(int modelId)
        {
            foreach (var model in Instance)
            {
                if (model.ModelId == modelId)
                    return model;
            }

            return null;
        }

        private static void BuildInstance()
        {
            Instance = new ModelList();
            ResetData();
        }
    }
}
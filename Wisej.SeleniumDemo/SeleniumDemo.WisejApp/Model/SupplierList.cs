using System.Collections.Generic;
using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class SupplierList : BindingList<Supplier>
    {
        private static SupplierList Instance
        {
            get { return ApplicationBase.Session.SupplierList; }
            set { ApplicationBase.Session.SupplierList = value; }
        }

        public static SupplierList GetSupplierList()
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
                Supplier.ClearCounter();

                new Supplier(1, "Big John").Save();
                new Supplier(2, "Big Larry").Save();
                new Supplier(3, "Big Marylou").Save();
                new Supplier(4, "Big Anne").Save();
                new Supplier(5, "Patricia").Save();
                new Supplier(11, "Small John Silver", 1).Save();
                new Supplier(12, "Small John John", 1).Save();
                new Supplier(21, "Small Larry", 2).Save();
                new Supplier(31, "Small Marylou", 3).Save();
                new Supplier(41, "Small Anne", 4).Save();
                new Supplier(121, "Baby John Johnny", 12).Save();
                new Supplier(122, "Baby John Jonathan", 12).Save();
            }
        }

        public static bool Contains(int supplierId)
        {
            foreach (var supplier in Instance)
            {
                if (supplier.SupplierId == supplierId)
                    return true;
            }

            return false;
        }

        public static Supplier GetSupplier(int supplierId)
        {
            foreach (var supplier in Instance)
            {
                if (supplier.SupplierId == supplierId)
                    return supplier;
            }

            return null;
        }

        private static void BuildInstance()
        {
            Instance = new SupplierList();
            ResetData();
        }

        public static Supplier[] GetRootSuppliers()
        {
            var list = new List<Supplier>();

            foreach (var suppler in GetSupplierList())
            {
                if (suppler.ParentSupplierId == null)
                    list.Add(suppler);
            }

            return list.ToArray();
        }

        public static Supplier[] GetChildSuppliers(int parentSupplierId)
        {
            var list = new List<Supplier>();

            foreach (var suppler in Instance)
            {
                if (suppler.ParentSupplierId == parentSupplierId)
                    list.Add(suppler);
            }

            return list.ToArray();
        }
    }
}
﻿//------------------------------------------------------------------------------
//
// file name:Product.cs
// author: peidun
// create date:2008/6/6 10:00:37
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 商品
    /// </summary>
    [Serializable]
    public partial class Product : IComparable
    {
        public Product()
        {
        }
        public Product(string productid, string id, string name, string productDescription)
        {
            this.ProductId = productid;
            this.Id = id;
            this.ProductName = name;
            this.ProductDescription = productDescription;

        }
        private System.Collections.Generic.IList<Product> details;

        public System.Collections.Generic.IList<Product> Details
        {
            get { return details; }
            set { details = value; }
        }
        //private System.Collections.Generic.IList<ProductProcess> productProcess = new System.Collections.Generic.List<Model.ProductProcess>();

        //public System.Collections.Generic.IList<ProductProcess> ProductProcess
        //{
        //    get { return productProcess; }
        //    set { productProcess = value; }
        //}
        private System.Collections.Generic.IList<ProductMouldDetail> productMouldDetail = new System.Collections.Generic.List<Model.ProductMouldDetail>();

        public System.Collections.Generic.IList<ProductMouldDetail> ProductMouldDetail
        {
            get { return productMouldDetail; }
            set { productMouldDetail = value; }
        }

        public override string ToString()
        {
            return this._productName;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Product)
            {
                Product product = (Product)obj;
                return product.ProductName.CompareTo(this.ProductName);
            }

            throw new ArgumentException("obj");
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                return (obj as Model.Product)._productId == this._productId ? true : false;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //净重+/单位
        private string _netWeightUnit;
        public string NetWeightUnit
        {
            get
            {
                return this.NetWeight == 0 || this.NetWeight == null ? null : this.NetWeight.ToString() + "/" + this.WeightUnit.Id;
            }


        }
        private string proProcessName;

        public string ProProcessName
        {
            get { return proProcessName; }
            set { proProcessName = value; }
        }
        private string _productCategoryName;

        public string ProductCategoryName
        {
            get { return _productCategoryName; }
            set { _productCategoryName = value; }
        }
        private string _productProcessDescription;

        public string ProductProcessDescription
        {
            get { return _productProcessDescription; }
            set { _productProcessDescription = value; }
        }
        private int _indexs;

        public int Indexs
        {
            get { return _indexs; }
            set { _indexs = value; }
        }
        private string _proceProductId;

        public string ProceProductId
        {
            get { return _proceProductId; }
            set { _proceProductId = value; }
        }
        /// <summary>
        /// 加工后商品编号Id
        /// </summary>
        private string _proceId;
        public string ProceId
        {
            get { return _proceId; }
            set { _proceId = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool? _checked;
        /// <summary>
        /// 
        /// </summary>
        public bool? Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                this._checked = value;
            }
        }
        //public string  ProductTreeName
        //{
        //    get { 
        //     return (IsCustomerProduct == true ? ProductName + "{" + CustomerProductName + "}" : product.ProductName) + (string.IsNullOrEmpty(product.ProductVersion) ? "" : "-" + product.ProductVersion);

        //    }

        //  }

        public string ProductNameWithVersion
        {
            get { return this.ProductName + "    版次:" + this.ProductVersion; }
        }

        public static string Pro_ProductNameWithVersion = "ProductNameWithVersion";
    }
}

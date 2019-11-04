﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：DepotInDetail.autogenerated.cs
// author: mayanjun
// create date：2011-11-22 11:06:24
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class DepotInDetail
	{
		#region Data

		/// <summary>
		/// 编号
		/// </summary>
		private string _depotInDetailId;
		
		/// <summary>
		/// 位置编号
		/// </summary>
		private string _depotPositionId;
		
		/// <summary>
		/// 头编号
		/// </summary>
		private string _depotInId;
		
		/// <summary>
		/// 商品编号
		/// </summary>
		private string _productId;
		
		/// <summary>
		/// 单位
		/// </summary>
		private string _productUnit;
		
		/// <summary>
		/// 单价
		/// </summary>
		private decimal? _depotInPrice;
		
		/// <summary>
		/// 数量
		/// </summary>
		private double? _depotInQuantity;
		
		/// <summary>
		/// 金额
		/// </summary>
		private decimal? _depotInTotal;
		
		/// <summary>
		/// 说明
		/// </summary>
        //private string _description;
		
		/// <summary>
		/// 
		/// </summary>
		private string _pronoteHeaderId;
		
		/// <summary>
		/// 
		/// </summary>
		private int? _inumber;
		
		/// <summary>
		/// 
		/// </summary>
		private string _descriptions;
		
		/// <summary>
		/// 
		/// </summary>
		private string _invoiceId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _invoiceDetailId;
		
		/// <summary>
		/// 产品
		/// </summary>
		private Product _product;
		/// <summary>
		/// 其他入库
		/// </summary>
		private DepotIn _depotIn;
		/// <summary>
		/// 库库货位
		/// </summary>
		private DepotPosition _depotPosition;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 编号
		/// </summary>
		public string DepotInDetailId
		{
			get 
			{
				return this._depotInDetailId;
			}
			set 
			{
				this._depotInDetailId = value;
			}
		}

		/// <summary>
		/// 位置编号
		/// </summary>
		public string DepotPositionId
		{
			get 
			{
				return this._depotPositionId;
			}
			set 
			{
				this._depotPositionId = value;
			}
		}

		/// <summary>
		/// 头编号
		/// </summary>
		public string DepotInId
		{
			get 
			{
				return this._depotInId;
			}
			set 
			{
				this._depotInId = value;
			}
		}

		/// <summary>
		/// 商品编号
		/// </summary>
		public string ProductId
		{
			get 
			{
				return this._productId;
			}
			set 
			{
				this._productId = value;
			}
		}

		/// <summary>
		/// 单位
		/// </summary>
		public string ProductUnit
		{
			get 
			{
				return this._productUnit;
			}
			set 
			{
				this._productUnit = value;
			}
		}

		/// <summary>
		/// 单价
		/// </summary>
		public decimal? DepotInPrice
		{
			get 
			{
				return this._depotInPrice;
			}
			set 
			{
				this._depotInPrice = value;
			}
		}

		/// <summary>
		/// 数量
		/// </summary>
		public double? DepotInQuantity
		{
			get 
			{
				return this._depotInQuantity;
			}
			set 
			{
				this._depotInQuantity = value;
			}
		}

		/// <summary>
		/// 金额
		/// </summary>
		public decimal? DepotInTotal
		{
			get 
			{
				return this._depotInTotal;
			}
			set 
			{
				this._depotInTotal = value;
			}
		}

		/// <summary>
		/// 说明
		/// </summary>
        //public string Description
        //{
        //    get 
        //    {
        //        return this._description;
        //    }
        //    set 
        //    {
        //        this._description = value;
        //    }
        //}

		/// <summary>
		/// 
		/// </summary>
		public string PronoteHeaderId
		{
			get 
			{
				return this._pronoteHeaderId;
			}
			set 
			{
				this._pronoteHeaderId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? Inumber
		{
			get 
			{
				return this._inumber;
			}
			set 
			{
				this._inumber = value;
			}
		}

		/// <summary>
		/// 说明
		/// </summary>
		public string Descriptions
		{
			get 
			{
				return this._descriptions;
			}
			set 
			{
				this._descriptions = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string InvoiceId
		{
			get 
			{
				return this._invoiceId;
			}
			set 
			{
				this._invoiceId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string InvoiceDetailId
		{
			get 
			{
				return this._invoiceDetailId;
			}
			set 
			{
				this._invoiceDetailId = value;
			}
		}
	
		/// <summary>
		/// 产品
		/// </summary>
		public virtual Product Product
		{
			get
			{
				return this._product;
			}
			set
			{
				this._product = value;
			}
			
		}
		/// <summary>
		/// 其他入库
		/// </summary>
		public virtual DepotIn DepotIn
		{
			get
			{
				return this._depotIn;
			}
			set
			{
				this._depotIn = value;
			}
			
		}
		/// <summary>
		/// 库存货位
		/// </summary>
		public virtual DepotPosition DepotPosition
		{
			get
			{
				return this._depotPosition;
			}
			set
			{
				this._depotPosition = value;
			}
			
		}
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PRO_DepotInDetailId = "DepotInDetailId";
		
		/// <summary>
		/// 位置编号
		/// </summary>
		public readonly static string PRO_DepotPositionId = "DepotPositionId";
		
		/// <summary>
		/// 头编号
		/// </summary>
		public readonly static string PRO_DepotInId = "DepotInId";
		
		/// <summary>
		/// 商品编号
		/// </summary>
		public readonly static string PRO_ProductId = "ProductId";
		
		/// <summary>
		/// 单位
		/// </summary>
		public readonly static string PRO_ProductUnit = "ProductUnit";
		
		/// <summary>
		/// 单价
		/// </summary>
		public readonly static string PRO_DepotInPrice = "DepotInPrice";
		
		/// <summary>
		/// 数量
		/// </summary>
		public readonly static string PRO_DepotInQuantity = "DepotInQuantity";
		
		/// <summary>
		/// 金额
		/// </summary>
		public readonly static string PRO_DepotInTotal = "DepotInTotal";
		
		/// <summary>
		/// 说明
		/// </summary>
        //public readonly static string PRO_Description = "Description";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_PronoteHeaderId = "PronoteHeaderId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_Inumber = "Inumber";
		
		/// <summary>
		/// 说明
		/// </summary>
		public readonly static string PRO_Descriptions = "Descriptions";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_InvoiceId = "InvoiceId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_InvoiceDetailId = "InvoiceDetailId";
		

		#endregion
	}
}

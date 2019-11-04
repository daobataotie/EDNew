﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceHCDetail.autogenerated.cs
// author: mayanjun
// create date：2010-11-17 11:05:40
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class InvoiceHCDetail
	{
		#region Data

		/// <summary>
		/// 编号
		/// </summary>
		private string _invoiceHCDetailId;
		
		/// <summary>
		/// 编号2
		/// </summary>
		private string _invoiceJRDetailId;
		
		/// <summary>
		/// 商品编号
		/// </summary>
		private string _productId;
		
		/// <summary>
		/// 单据编号
		/// </summary>
		private string _invoiceId;
		
		/// <summary>
		/// 数量
		/// </summary>
		private double? _invoiceHCDetailQuantity;
		
		/// <summary>
		/// 说明
		/// </summary>
		private string _invoiceHCDetailNote;
		
		/// <summary>
		/// 单位
		/// </summary>
		private string _invoiceProductUnit;
		
		/// <summary>
		/// 
		/// </summary>
		private string _depotPositionId;
		
		/// <summary>
		/// 库库货位
		/// </summary>
		private DepotPosition _depotPosition;
		/// <summary>
		/// 借入还出单
		/// </summary>
		private InvoiceHC _invoice;
		/// <summary>
		/// 借入单商品明细
		/// </summary>
		private InvoiceJRDetail _invoiceJRDetail;
		/// <summary>
		/// 产品
		/// </summary>
		private Product _product;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 编号
		/// </summary>
		public string InvoiceHCDetailId
		{
			get 
			{
				return this._invoiceHCDetailId;
			}
			set 
			{
				this._invoiceHCDetailId = value;
			}
		}

		/// <summary>
		/// 编号2
		/// </summary>
		public string InvoiceJRDetailId
		{
			get 
			{
				return this._invoiceJRDetailId;
			}
			set 
			{
				this._invoiceJRDetailId = value;
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
		/// 单据编号
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
		/// 数量
		/// </summary>
		public double? InvoiceHCDetailQuantity
		{
			get 
			{
				return this._invoiceHCDetailQuantity;
			}
			set 
			{
				this._invoiceHCDetailQuantity = value;
			}
		}

		/// <summary>
		/// 说明
		/// </summary>
		public string InvoiceHCDetailNote
		{
			get 
			{
				return this._invoiceHCDetailNote;
			}
			set 
			{
				this._invoiceHCDetailNote = value;
			}
		}

		/// <summary>
		/// 单位
		/// </summary>
		public string InvoiceProductUnit
		{
			get 
			{
				return this._invoiceProductUnit;
			}
			set 
			{
				this._invoiceProductUnit = value;
			}
		}

		/// <summary>
		/// 
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
		/// 库库货位
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
		/// 借入还出单
		/// </summary>
		public virtual InvoiceHC Invoice
		{
			get
			{
				return this._invoice;
			}
			set
			{
				this._invoice = value;
			}
			
		}
		/// <summary>
		/// 借入单商品明细
		/// </summary>
		public virtual InvoiceJRDetail InvoiceJRDetail
		{
			get
			{
				return this._invoiceJRDetail;
			}
			set
			{
				this._invoiceJRDetail = value;
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
		/// 编号
		/// </summary>
		public readonly static string PRO_InvoiceHCDetailId = "InvoiceHCDetailId";
		
		/// <summary>
		/// 编号2
		/// </summary>
		public readonly static string PRO_InvoiceJRDetailId = "InvoiceJRDetailId";
		
		/// <summary>
		/// 商品编号
		/// </summary>
		public readonly static string PRO_ProductId = "ProductId";
		
		/// <summary>
		/// 单据编号
		/// </summary>
		public readonly static string PRO_InvoiceId = "InvoiceId";
		
		/// <summary>
		/// 数量
		/// </summary>
		public readonly static string PRO_InvoiceHCDetailQuantity = "InvoiceHCDetailQuantity";
		
		/// <summary>
		/// 说明
		/// </summary>
		public readonly static string PRO_InvoiceHCDetailNote = "InvoiceHCDetailNote";
		
		/// <summary>
		/// 单位
		/// </summary>
		public readonly static string PRO_InvoiceProductUnit = "InvoiceProductUnit";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_DepotPositionId = "DepotPositionId";
		

		#endregion
	}
}

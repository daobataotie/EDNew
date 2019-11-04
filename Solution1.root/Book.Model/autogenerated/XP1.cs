﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：XP1.autogenerated.cs
// author: mayanjun
// create date：2015/4/18 下午 12:51:54
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class XP1
	{
		#region Data

		/// <summary>
		/// 冲销应付款情况1编号
		/// </summary>
		private string _xP1Id;
		
		/// <summary>
		/// 进货单编号
		/// </summary>
		private string _invoiceCGId;
		
		/// <summary>
		/// 付款单据编号
		/// </summary>
		private string _invoiceFKId;
		
		/// <summary>
		/// 冲销应付款情况1冲销金额
		/// </summary>
		private decimal? _xP1Money;
		
		/// <summary>
		/// 进库单
		/// </summary>
		private InvoiceCG _invoiceCG;
		/// <summary>
		/// 付款单
		/// </summary>
		private InvoiceFK _invoiceFK;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 冲销应付款情况1编号
		/// </summary>
		public string XP1Id
		{
			get 
			{
				return this._xP1Id;
			}
			set 
			{
				this._xP1Id = value;
			}
		}

		/// <summary>
		/// 进货单编号
		/// </summary>
		public string InvoiceCGId
		{
			get 
			{
				return this._invoiceCGId;
			}
			set 
			{
				this._invoiceCGId = value;
			}
		}

		/// <summary>
		/// 付款单据编号
		/// </summary>
		public string InvoiceFKId
		{
			get 
			{
				return this._invoiceFKId;
			}
			set 
			{
				this._invoiceFKId = value;
			}
		}

		/// <summary>
		/// 冲销应付款情况1冲销金额
		/// </summary>
		public decimal? XP1Money
		{
			get 
			{
				return this._xP1Money;
			}
			set 
			{
				this._xP1Money = value;
			}
		}
	
		/// <summary>
		/// 进库单
		/// </summary>
		public virtual InvoiceCG InvoiceCG
		{
			get
			{
				return this._invoiceCG;
			}
			set
			{
				this._invoiceCG = value;
			}
			
		}
		/// <summary>
		/// 付款单
		/// </summary>
		public virtual InvoiceFK InvoiceFK
		{
			get
			{
				return this._invoiceFK;
			}
			set
			{
				this._invoiceFK = value;
			}
			
		}
		/// <summary>
		/// 冲销应付款情况1编号
		/// </summary>
        public readonly static string PROPERTY_XP1ID = "XP1Id";

        /// <summary>                 
        /// 进货单编号               
        /// </summary>                
        public readonly static string PROPERTY_INVOICECGID = "InvoiceCGId";

        /// <summary>                 
        /// 付款单据编号            
        /// </summary>                
        public readonly static string PROPERTY_INVOICEFKID = "InvoiceFKId";

        /// <summary>                 
        /// 冲销应付款情况1冲销金额
        /// </summary>                
        public readonly static string PROPERTY_XP1MONEY = "XP1Money";
		

		#endregion
	}
}
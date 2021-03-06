﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：MouldAttachment.autogenerated.cs
// author: mayanjun
// create date：2010-9-29 10:57:27
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class MouldAttachment
	{
		#region Data

		/// <summary>
		/// 附件编号
		/// </summary>
		private string _mouldAttachmentId;
		
		/// <summary>
		/// 模板编号
		/// </summary>
		private string _mouldId;
		
		/// <summary>
		/// 产品图档
		/// </summary>
		private byte[] _picture;
		
		/// <summary>
		/// 图档说明
		/// </summary>
		private string _description;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 产品模具
		/// </summary>
		private ProductMould _mould;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 附件编号
		/// </summary>
		public string MouldAttachmentId
		{
			get 
			{
				return this._mouldAttachmentId;
			}
			set 
			{
				this._mouldAttachmentId = value;
			}
		}

		/// <summary>
		/// 模板编号
		/// </summary>
		public string MouldId
		{
			get 
			{
				return this._mouldId;
			}
			set 
			{
				this._mouldId = value;
			}
		}

		/// <summary>
		/// 产品图档
		/// </summary>
		public byte[] Picture
		{
			get 
			{
				return this._picture;
			}
			set 
			{
				this._picture = value;
			}
		}

		/// <summary>
		/// 图档说明
		/// </summary>
		public string Description
		{
			get 
			{
				return this._description;
			}
			set 
			{
				this._description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			get 
			{
				return this._insertTime;
			}
			set 
			{
				this._insertTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			get 
			{
				return this._updateTime;
			}
			set 
			{
				this._updateTime = value;
			}
		}
	
		/// <summary>
		/// 产品模具
		/// </summary>
		public virtual ProductMould Mould
		{
			get
			{
				return this._mould;
			}
			set
			{
				this._mould = value;
			}
			
		}
		/// <summary>
		/// 附件编号
		/// </summary>
		public readonly static string PROPERTY_MOULDATTACHMENTID = "MouldAttachmentId";
		
		/// <summary>
		/// 模板编号
		/// </summary>
		public readonly static string PROPERTY_MOULDID = "MouldId";
		
		/// <summary>
		/// 产品图档
		/// </summary>
		public readonly static string PROPERTY_PICTURE = "Picture";
		
		/// <summary>
		/// 图档说明
		/// </summary>
		public readonly static string PROPERTY_DESCRIPTION = "Description";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PROPERTY_INSERTTIME = "InsertTime";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PROPERTY_UPDATETIME = "UpdateTime";
		

		#endregion
	}
}

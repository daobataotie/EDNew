﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Sequence.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:17
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class Sequence
	{
		#region Data

		/// <summary>
		/// 键
		/// </summary>
		private string _key;
		
		/// <summary>
		/// 值
		/// </summary>
		private int? _val;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 键
		/// </summary>
		public string Key
		{
			get 
			{
				return this._key;
			}
			set 
			{
				this._key = value;
			}
		}

		/// <summary>
		/// 值
		/// </summary>
		public int? Val
		{
			get 
			{
				return this._val;
			}
			set 
			{
				this._val = value;
			}
		}
	
		/// <summary>
		/// 键
		/// </summary>
		public readonly static string PROPERTY_KEY = "Key";
		
		/// <summary>
		/// 值
		/// </summary>
		public readonly static string PROPERTY_VAL = "Val";
		

		#endregion
	}
}

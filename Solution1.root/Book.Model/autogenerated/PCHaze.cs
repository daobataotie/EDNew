﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCHaze.autogenerated.cs
// author: mayanjun
// create date：2015/1/18 下午 08:12:17
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class PCHaze
	{
		#region Data

		/// <summary>
		/// 
		/// </summary>
		private string _pCHazeId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _pCDataInputId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _noId;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _leftHaze;
		
		/// <summary>
		/// 
		/// </summary>
		private decimal? _rightHaze;
		
		/// <summary>
		/// 
		/// </summary>
		private string _judge;
		
		/// <summary>
		/// 
		/// </summary>
		private PCDataInput _pCDataInput;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 
		/// </summary>
		public string PCHazeId
		{
			get 
			{
				return this._pCHazeId;
			}
			set 
			{
				this._pCHazeId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PCDataInputId
		{
			get 
			{
				return this._pCDataInputId;
			}
			set 
			{
				this._pCDataInputId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string NoId
		{
			get 
			{
				return this._noId;
			}
			set 
			{
				this._noId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? LeftHaze
		{
			get 
			{
				return this._leftHaze;
			}
			set 
			{
				this._leftHaze = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? RightHaze
		{
			get 
			{
				return this._rightHaze;
			}
			set 
			{
				this._rightHaze = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Judge
		{
			get 
			{
				return this._judge;
			}
			set 
			{
				this._judge = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public virtual PCDataInput PCDataInput
		{
			get
			{
				return this._pCDataInput;
			}
			set
			{
				this._pCDataInput = value;
			}
			
		}
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_PCHazeId = "PCHazeId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_PCDataInputId = "PCDataInputId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_NoId = "NoId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_LeftHaze = "LeftHaze";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_RightHaze = "RightHaze";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_Judge = "Judge";
		

		#endregion
	}
}
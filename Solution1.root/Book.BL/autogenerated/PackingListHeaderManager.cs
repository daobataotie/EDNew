﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingListHeaderManager.autogenerated.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PackingListHeaderManager
    {
        ///<summary>
        /// Data accessor of dbo.PackingListHeader
        ///</summary>
        private static readonly DA.IPackingListHeaderAccessor accessor = (DA.IPackingListHeaderAccessor)Accessors.Get("PackingListHeaderAccessor");

        /// <summary>
        /// Select by primary key.
        /// </summary>		
        public Model.PackingListHeader Get(string packingNo)
        {
            return accessor.Get(packingNo);
        }

        public bool HasRows(string packingNo)
        {
            return accessor.HasRows(packingNo);
        }

        public bool HasRows()
        {
            return accessor.HasRows();
        }


        public bool HasRowsBefore(Model.PackingListHeader e)
        {
            return accessor.HasRowsBefore(e);
        }

        public bool HasRowsAfter(Model.PackingListHeader e)
        {
            return accessor.HasRowsAfter(e);
        }

        public Model.PackingListHeader GetFirst()
        {
            return accessor.GetFirst();
        }

        public Model.PackingListHeader GetLast()
        {
            return accessor.GetLast();
        }

        public Model.PackingListHeader GetPrev(Model.PackingListHeader e)
        {
            return accessor.GetPrev(e);
        }

        public Model.PackingListHeader GetNext(Model.PackingListHeader e)
        {
            return accessor.GetNext(e);
        }
        /// <summary>
        /// Select all.
        /// </summary>
        public IList<Model.PackingListHeader> Select()
        {
            return accessor.Select();
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int Count()
        {
            return accessor.Count();
        }

        /// <summary>
        /// 获取指定状态、指定分页，并按指定要求排序的记录
        /// </summary>
        public IList<Model.PackingListHeader> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
        {
            return accessor.Select(orderDescription, pagingDescription);
        }

        public bool ExistsPrimary(string id)
        {
            return accessor.ExistsPrimary(id);
        }
    
    }
}

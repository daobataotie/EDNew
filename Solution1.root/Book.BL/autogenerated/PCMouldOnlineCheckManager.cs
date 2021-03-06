﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCMouldOnlineCheckManager.autogenerated.cs
// author: mayanjun
// create date：2015/4/13 上午 10:11:44
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PCMouldOnlineCheckManager
    {
        ///<summary>
        /// Data accessor of dbo.PCMouldOnlineCheck
        ///</summary>
        private static readonly DA.IPCMouldOnlineCheckAccessor accessor = (DA.IPCMouldOnlineCheckAccessor)Accessors.Get("PCMouldOnlineCheckAccessor");

        /// <summary>
        /// Select by primary key.
        /// </summary>		
        public Model.PCMouldOnlineCheck Get(string pCMouldOnlineCheckId)
        {
            return accessor.Get(pCMouldOnlineCheckId);
        }

        public bool HasRows(string pCMouldOnlineCheckId)
        {
            return accessor.HasRows(pCMouldOnlineCheckId);
        }

        public bool HasRows()
        {
            return accessor.HasRows();
        }


        public bool HasRowsBefore(Model.PCMouldOnlineCheck e)
        {
            return accessor.HasRowsBefore(e);
        }

        public bool HasRowsAfter(Model.PCMouldOnlineCheck e)
        {
            return accessor.HasRowsAfter(e);
        }

        public Model.PCMouldOnlineCheck GetFirst()
        {
            return accessor.GetFirst();
        }

        public Model.PCMouldOnlineCheck GetLast()
        {
            return accessor.GetLast();
        }

        public Model.PCMouldOnlineCheck GetPrev(Model.PCMouldOnlineCheck e)
        {
            return accessor.GetPrev(e);
        }

        public Model.PCMouldOnlineCheck GetNext(Model.PCMouldOnlineCheck e)
        {
            return accessor.GetNext(e);
        }
        /// <summary>
        /// Select all.
        /// </summary>
        public IList<Model.PCMouldOnlineCheck> Select()
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
        public IList<Model.PCMouldOnlineCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
        {
            return accessor.Select(orderDescription, pagingDescription);
        }
        public bool ExistsPrimary(string id)
        {
            return accessor.ExistsPrimary(id);
        }

    }
}

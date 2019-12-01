//------------------------------------------------------------------------------
//
// file name：PackingListDetailManager.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.PackingListDetail.
    /// </summary>
    public partial class PackingListDetailManager
    {
		
		/// <summary>
		/// Delete PackingListDetail by primary key.
		/// </summary>
		public void Delete(string packingListDetailId)
		{
			//
			// todo:add other logic here
			//
			accessor.Delete(packingListDetailId);
		}

		/// <summary>
		/// Insert a PackingListDetail.
		/// </summary>
        public void Insert(Model.PackingListDetail packingListDetail)
        {
			//
			// todo:add other logic here
			//
            accessor.Insert(packingListDetail);
        }
		
		/// <summary>
		/// Update a PackingListDetail.
		/// </summary>
        public void Update(Model.PackingListDetail packingListDetail)
        {
			//
			// todo: add other logic here.
			//
            accessor.Update(packingListDetail);
        }

        public IList<Model.PackingListDetail> SelectByHeader(string headerId)
        {
            return accessor.SelectByHeader(headerId);
        }
    }
}

//------------------------------------------------------------------------------
//
// file name：PortManager.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.Port.
    /// </summary>
    public partial class PortManager
    {
		
		/// <summary>
		/// Delete Port by primary key.
		/// </summary>
		public void Delete(string portId)
		{
			//
			// todo:add other logic here
			//
			accessor.Delete(portId);
		}

		/// <summary>
		/// Insert a Port.
		/// </summary>
        public void Insert(Model.Port port)
        {
			//
			// todo:add other logic here
			//
            accessor.Insert(port);
        }
		
		/// <summary>
		/// Update a Port.
		/// </summary>
        public void Update(Model.Port port)
        {
			//
			// todo: add other logic here.
			//
            accessor.Update(port);
        }
    }
}

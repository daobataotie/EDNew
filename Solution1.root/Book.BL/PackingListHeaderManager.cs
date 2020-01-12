//------------------------------------------------------------------------------
//
// file name：PackingListHeaderManager.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.PackingListHeader.
    /// </summary>
    public partial class PackingListHeaderManager
    {
        private static readonly DA.IPackingListDetailAccessor accessorDetail = (DA.IPackingListDetailAccessor)Accessors.Get("PackingListDetailAccessor");

        /// <summary>
        /// Delete PackingListHeader by primary key.
        /// </summary>
        public void Delete(string packingNo)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();

                accessorDetail.DeleteByHeader(packingNo);
                accessor.Delete(packingNo);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Insert a PackingListHeader.
        /// </summary>
        public void Insert(Model.PackingListHeader packingListHeader)
        {
            //
            // todo:add other logic here
            //

            Validate(packingListHeader);

            if (this.ExistsPrimary(packingListHeader.PackingNo))
                throw new Helper.MessageValueException(string.Format("已存在相同的PACKINGNO：{0}", packingListHeader.PackingNo));

            try
            {
                BL.V.BeginTransaction();

                packingListHeader.InsertTime = DateTime.Now;
                packingListHeader.UpdateTime = DateTime.Now;
                accessor.Insert(packingListHeader);

                foreach (var item in packingListHeader.Details)
                {
                    item.PackingListHeaderId = packingListHeader.PackingNo;

                    accessorDetail.Insert(item);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Update a PackingListHeader.
        /// </summary>
        public void Update(Model.PackingListHeader packingListHeader,string oldId)
        {
            //
            // todo: add other logic here.
            //

            Validate(packingListHeader);

            try
            {
                BL.V.BeginTransaction();

                //删除详细
                accessorDetail.DeleteByHeader(oldId);
                accessor.Delete(oldId);

                packingListHeader.UpdateTime = DateTime.Now;
                accessor.Insert(packingListHeader);

                foreach (var item in packingListHeader.Details)
                {
                    item.PackingListHeaderId = packingListHeader.PackingNo;

                    accessorDetail.Insert(item);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        private void Validate(Model.PackingListHeader model)
        {
            if (string.IsNullOrEmpty(model.PackingNo))
                throw new Helper.RequireValueException(Model.PackingListHeader.PRO_PackingNo);
            if (model.PackingDate == null)
                throw new Helper.RequireValueException(Model.PackingListHeader.PRO_PackingDate);
            //if (string.IsNullOrEmpty(model.CustomerId))
            //    throw new Helper.RequireValueException(Model.PackingListHeader.PRO_CustomerId);
            if (string.IsNullOrEmpty(model.PerSS))
                throw new Helper.RequireValueException(Model.PackingListHeader.PRO_PerSS);
            //if (model.SailingOnOrAbout == null)
            //    throw new Helper.RequireValueException(Model.PackingListHeader.PRO_SailingOnOrAbout);
            if (string.IsNullOrEmpty(model.FromPortId))
                throw new Helper.RequireValueException(Model.PackingListHeader.PRO_FromPortId);
            if (string.IsNullOrEmpty(model.ToPortId))
                throw new Helper.RequireValueException(Model.PackingListHeader.PRO_ToPortId);

            foreach (var item in model.Details)
            {
                //if (string.IsNullOrEmpty(item.PLTNo))
                //    throw new Helper.RequireValueException(Model.PackingListDetail.PRO_PLTNo);
                if (string.IsNullOrEmpty(item.CartonNo))
                    throw new Helper.RequireValueException(Model.PackingListDetail.PRO_CartonNo);
            }
        }

        public Book.Model.PackingListHeader GetDetail(string packingNo)
        {
            Model.PackingListHeader header = this.Get(packingNo);
            if (header != null)
                header.Details = accessorDetail.SelectByHeader(packingNo);

            return header;
        }

        public IList<Model.PackingListHeader> SelectByCondition(DateTime startDate, DateTime endDate, string customerId)
        {
            return accessor.SelectByCondition(startDate, endDate, customerId);
        }
    }
}

﻿//------------------------------------------------------------------------------
//
// file name：MaterialManager.cs
// author: mayanjun
// create date：2013-5-4 16:09:32
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.Material.
    /// </summary>
    public partial class MaterialManager
    {

        /// <summary>
        /// Delete Material by primary key.
        /// </summary>
        public void Delete(string materialId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(materialId);
        }

        /// <summary>
        /// Insert a Material.
        /// </summary>
        public void Insert(Model.Material material)
        {
            //
            // todo:add other logic here
            //
            material.InsertTime = DateTime.Now;
            material.UpdateTime = DateTime.Now;
            accessor.Insert(material);
        }

        /// <summary>
        /// Update a Material.
        /// </summary>
        public void Update(Model.Material material)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(material);
        }

        public void Update(IList<Model.Material> materialList)
        {
            this.Validate(materialList);

            foreach (Model.Material materail in materialList)
            {
                if (this.ExistsPrimary(materail.MaterialId))
                {
                    materail.UpdateTime = DateTime.Now;
                    accessor.Update(materail);
                }
                else
                    this.Insert(materail);
            }
        }

        private void Validate(IList<Model.Material> materialList)
        {
            foreach (Model.Material material in materialList)
            {
                if (string.IsNullOrEmpty(material.Id) || string.IsNullOrEmpty(material.MaterialCategoryName))
                    throw new Helper.RequireValueException(Model.Material.PRO_Id);
            }

            //if (materialList.GroupBy<Model.Material, string, List<Model.Material>>(m => m.Id, m => materialList as List<Model.Material>).Count<Model.Material>() > 1)

            var result = from r in materialList
                         group r by r.Id into s
                         select new { a = s.Count() };
            var result2 = from r in materialList
                          group r by r.MaterialCategoryName into s
                          select new { b = s.Count() };

            foreach (var item in result)
            {
                if (item.a > 1)
                    throw new Helper.InvalidValueException(Model.Material.PRO_Id);
            }
            foreach (var item in result2)
            {
                if (item.b > 1)
                    throw new Helper.InvalidValueException(Model.Material.PRO_MaterialCategoryName);
            }
        }

        public double CountJWeightByMaterial(string MaterialId)
        {
            return accessor.CountJWeightByMaterial(MaterialId);
        }
    }
}


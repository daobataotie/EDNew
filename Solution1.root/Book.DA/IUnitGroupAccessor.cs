﻿//------------------------------------------------------------------------------
//
// file name：IUnitGroupAccessor.cs
// author: peidun
// create date：2009-08-03 9:37:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.UnitGroup
    /// </summary>
    public partial interface IUnitGroupAccessor : IAccessor
    {
         bool existsInsertName(string name);
         bool existsUpdateName(string name, string id);
    }
}


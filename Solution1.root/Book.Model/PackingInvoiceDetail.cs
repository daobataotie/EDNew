//------------------------------------------------------------------------------
//
// file name：PackingInvoiceDetail.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class PackingInvoiceDetail
    {

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CUSTNO
        {
            get
            {
                string str = "";
                if (this.PackingInvoiceHeader != null && this.PackingInvoiceHeader.Customer != null)
                    str = this.PackingInvoiceHeader.Customer.Id;
                return str;
            }
        }

        public string ShowQty
        {

            get
            {
                return string.Format("{0} {1}", this.Quantity.Value.ToString("F0"), (string.IsNullOrEmpty(this.PackingInvoiceHeader.Unit) ? "PCS" : this.PackingInvoiceHeader.Unit));
            }
        }

        public readonly static string PRO_CUSTNO = "CUSTNO";

        public readonly static string PRO_ShowQty = "ShowQty";
    }
}
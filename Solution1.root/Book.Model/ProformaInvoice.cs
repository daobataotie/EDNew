//------------------------------------------------------------------------------
//
// file name：ProformaInvoice.cs
// author: mayanjun
// create date：2019/3/13 18:44:58
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ProformaInvoice : Model.Invoice
    {
        System.Collections.Generic.IList<ProformaInvoiceDetail> _details = new System.Collections.Generic.List<Model.ProformaInvoiceDetail>();

        public System.Collections.Generic.IList<ProformaInvoiceDetail> Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public string CustomerFullName { get; set; }

        public string BankName { get; set; }
    }
}
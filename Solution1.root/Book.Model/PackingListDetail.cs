//------------------------------------------------------------------------------
//
// file name：PackingListDetail.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class PackingListDetail
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CUSTNO
        {
            get
            {
                string str = "";
                if (this.PackingListHeader != null && this.PackingListHeader.Customer != null)
                    str = this.PackingListHeader.Customer.Id;
                return str;
            }
        }

        public string ShowQty
        {
            get
            {
                string str = "";
                str = string.Format("@{0} {1}", this.BoxMaxQuantity, (string.IsNullOrEmpty(PackingListHeader.Unit) ? "PCS" : PackingListHeader.Unit)) +
                    "       " +
                    string.Format("{0} {1}", this.Quantity, (string.IsNullOrEmpty(PackingListHeader.Unit) ? "PCS" : PackingListHeader.Unit));
                return str;
            }
        }

        public string ShowNetWeight
        {
            get
            {
                string str = "";
                str = string.Format("@{0} KGS", this.BoxMaxNetWeight) +
                    "       " +
                    string.Format("{0} KGS", this.NetWeight);
                return str;
            }
        }

        public string ShowGrossWeight
        {

            get
            {
                string str = "";
                str = string.Format("@{0} KGS", this.BoxMaxGrossWeight) +
                    "       " +
                    string.Format("{0} KGS", this.GrossWeight);
                return str;
            }
        }


        public readonly static string PRO_CUSTNO = "CUSTNO";

        public readonly static string PRO_ShowQty = "ShowQty";

        public readonly static string PRO_ShowNetWeight = "ShowNetWeight";

        public readonly static string PRO_ShowGrossWeight = "ShowGrossWeight";
    }
}
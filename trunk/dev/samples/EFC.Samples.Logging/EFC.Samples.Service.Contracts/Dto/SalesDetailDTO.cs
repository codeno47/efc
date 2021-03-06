//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2013-07-17 - 13:27:02
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EFC.Samples.Service.Contracts.Dto
{
    [DataContract()]
    public partial class SalesDetailDTO
    {
        [DataMember()]
        public Int32 SalesDetailsId { get; set; }

        [DataMember()]
        public Nullable<DateTime> InvoiceDate { get; set; }

        [DataMember()]
        public String InvoiceNo { get; set; }

        [DataMember()]
        public Int32 ShopId { get; set; }

        [DataMember()]
        public Nullable<Int32> ProductAttributeId { get; set; }

        [DataMember()]
        public Nullable<Decimal> Quantity { get; set; }

        [DataMember()]
        public Nullable<Decimal> Amount { get; set; }

        [DataMember()]
        public Nullable<Int32> UserId { get; set; }

        public SalesDetailDTO()
        {
        }

        public SalesDetailDTO(Int32 salesDetailsId, Nullable<DateTime> invoiceDate, String invoiceNo, Int32 shopId, Nullable<Int32> productAttributeId, Nullable<Decimal> quantity, Nullable<Decimal> amount, Nullable<Int32> userId)
        {
			this.SalesDetailsId = salesDetailsId;
			this.InvoiceDate = invoiceDate;
			this.InvoiceNo = invoiceNo;
			this.ShopId = shopId;
			this.ProductAttributeId = productAttributeId;
			this.Quantity = quantity;
			this.Amount = amount;
			this.UserId = userId;
        }
    }
}

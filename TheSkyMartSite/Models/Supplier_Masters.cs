//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheSkyMartSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier_Masters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier_Masters()
        {
            this.Price_master = new HashSet<Price_master>();
        }
    
        public int Supplier_ID { get; set; }
        public string Supplier_name { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email_id { get; set; }
        public Nullable<double> Credit_limit { get; set; }
        public Nullable<int> Payment_term { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Active_status { get; set; }
        public Nullable<int> Location_ID { get; set; }
    
        public virtual Location_master Location_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price_master> Price_master { get; set; }
    }
}
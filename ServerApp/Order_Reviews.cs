//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Reviews
    {
        public System.Guid Review_Id { get; set; }
        public Nullable<System.Guid> Order_Id { get; set; }
        public int Mark { get; set; }
        public string Details { get; set; }
    
        public virtual Order Order { get; set; }
    }
}

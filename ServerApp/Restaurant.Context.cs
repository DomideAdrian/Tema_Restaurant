﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RestaurantEntities : DbContext
    {
        public RestaurantEntities()
            : base("name=RestaurantEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Loyal_Customers> Loyal_Customers { get; set; }
        public virtual DbSet<Order_Reviews> Order_Reviews { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Processing> Processings { get; set; }
        public virtual DbSet<Product_Category> Product_Category { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
    
        public virtual int Insert_Bill(Nullable<System.Guid> billId, Nullable<System.Guid> orderId, Nullable<double> total, Nullable<System.DateTime> data)
        {
            var billIdParameter = billId.HasValue ?
                new ObjectParameter("BillId", billId) :
                new ObjectParameter("BillId", typeof(System.Guid));
    
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(System.Guid));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(double));
    
            var dataParameter = data.HasValue ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Bill", billIdParameter, orderIdParameter, totalParameter, dataParameter);
        }
    
        public virtual int Insert_Category(Nullable<System.Guid> category_Id, string category_Name)
        {
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(System.Guid));
    
            var category_NameParameter = category_Name != null ?
                new ObjectParameter("Category_Name", category_Name) :
                new ObjectParameter("Category_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Category", category_IdParameter, category_NameParameter);
        }
    
        public virtual int Insert_Courier(Nullable<System.Guid> courierId, string name, string phone)
        {
            var courierIdParameter = courierId.HasValue ?
                new ObjectParameter("CourierId", courierId) :
                new ObjectParameter("CourierId", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Courier", courierIdParameter, nameParameter, phoneParameter);
        }
    
        public virtual int Insert_Loyal_Customer(Nullable<System.Guid> loialityId, Nullable<System.Guid> idUser, Nullable<System.DateTime> period, Nullable<double> total)
        {
            var loialityIdParameter = loialityId.HasValue ?
                new ObjectParameter("LoialityId", loialityId) :
                new ObjectParameter("LoialityId", typeof(System.Guid));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(System.Guid));
    
            var periodParameter = period.HasValue ?
                new ObjectParameter("Period", period) :
                new ObjectParameter("Period", typeof(System.DateTime));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Loyal_Customer", loialityIdParameter, idUserParameter, periodParameter, totalParameter);
        }
    
        public virtual int Insert_Order(Nullable<System.Guid> order_Id, Nullable<System.Guid> idUser, Nullable<System.Guid> courierId)
        {
            var order_IdParameter = order_Id.HasValue ?
                new ObjectParameter("Order_Id", order_Id) :
                new ObjectParameter("Order_Id", typeof(System.Guid));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(System.Guid));
    
            var courierIdParameter = courierId.HasValue ?
                new ObjectParameter("CourierId", courierId) :
                new ObjectParameter("CourierId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Order", order_IdParameter, idUserParameter, courierIdParameter);
        }
    
        public virtual int Insert_Order_Status(Nullable<System.Guid> status_Id, Nullable<System.Guid> order_Id, string order_Status, Nullable<System.DateTime> last_Update)
        {
            var status_IdParameter = status_Id.HasValue ?
                new ObjectParameter("Status_Id", status_Id) :
                new ObjectParameter("Status_Id", typeof(System.Guid));
    
            var order_IdParameter = order_Id.HasValue ?
                new ObjectParameter("Order_Id", order_Id) :
                new ObjectParameter("Order_Id", typeof(System.Guid));
    
            var order_StatusParameter = order_Status != null ?
                new ObjectParameter("Order_Status", order_Status) :
                new ObjectParameter("Order_Status", typeof(string));
    
            var last_UpdateParameter = last_Update.HasValue ?
                new ObjectParameter("Last_Update", last_Update) :
                new ObjectParameter("Last_Update", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Order_Status", status_IdParameter, order_IdParameter, order_StatusParameter, last_UpdateParameter);
        }
    
        public virtual int Insert_Processing(Nullable<System.Guid> processing_Id, Nullable<System.Guid> product_Id, Nullable<System.Guid> order_Id)
        {
            var processing_IdParameter = processing_Id.HasValue ?
                new ObjectParameter("Processing_Id", processing_Id) :
                new ObjectParameter("Processing_Id", typeof(System.Guid));
    
            var product_IdParameter = product_Id.HasValue ?
                new ObjectParameter("Product_Id", product_Id) :
                new ObjectParameter("Product_Id", typeof(System.Guid));
    
            var order_IdParameter = order_Id.HasValue ?
                new ObjectParameter("Order_Id", order_Id) :
                new ObjectParameter("Order_Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Processing", processing_IdParameter, product_IdParameter, order_IdParameter);
        }
    
        public virtual int Insert_Product(Nullable<System.Guid> product_Id, string productName, Nullable<System.Guid> category_Id, Nullable<double> price, Nullable<int> time, string description)
        {
            var product_IdParameter = product_Id.HasValue ?
                new ObjectParameter("Product_Id", product_Id) :
                new ObjectParameter("Product_Id", typeof(System.Guid));
    
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(System.Guid));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(double));
    
            var timeParameter = time.HasValue ?
                new ObjectParameter("Time", time) :
                new ObjectParameter("Time", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Product", product_IdParameter, productNameParameter, category_IdParameter, priceParameter, timeParameter, descriptionParameter);
        }
    
        public virtual int Insert_Review(Nullable<System.Guid> review_Id, Nullable<System.Guid> order_Id, Nullable<int> mark, string details)
        {
            var review_IdParameter = review_Id.HasValue ?
                new ObjectParameter("Review_Id", review_Id) :
                new ObjectParameter("Review_Id", typeof(System.Guid));
    
            var order_IdParameter = order_Id.HasValue ?
                new ObjectParameter("Order_Id", order_Id) :
                new ObjectParameter("Order_Id", typeof(System.Guid));
    
            var markParameter = mark.HasValue ?
                new ObjectParameter("Mark", mark) :
                new ObjectParameter("Mark", typeof(int));
    
            var detailsParameter = details != null ?
                new ObjectParameter("Details", details) :
                new ObjectParameter("Details", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Review", review_IdParameter, order_IdParameter, markParameter, detailsParameter);
        }
    
        public virtual int Insert_User(string customerName, string password, string phone, string address, Nullable<System.Guid> idUser)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_User", customerNameParameter, passwordParameter, phoneParameter, addressParameter, idUserParameter);
        }
    
        public virtual int Set_Voucher(Nullable<System.Guid> idUser, Nullable<double> value)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(System.Guid));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Set_Voucher", idUserParameter, valueParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int User_Login(string customerName, string password, ObjectParameter idUser, ObjectParameter telefon, ObjectParameter voucher)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Login", customerNameParameter, passwordParameter, idUser, telefon, voucher);
        }
    }
}

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AmaraProject.WasteManager.Module.BusinessObjects
{

    //Location(CountryName,StateName,
    //Bank(Name,Desc

    //WasteCategory(Name,Description)
    //WasteItem(CategoryId,Name,Description
    //WasteBuyer(Name,Location,Bank,AccountNo)
    //WasteSeller(Name,Location,Bank,AccountNo)

    //WasteListing(SellerId,DateListed,ListingNo
    //ListingItem(ListingId,ItemId,Price
    //

    //SalesInvoice(ListingId,BuyerId,InvoiceDate,Amount
    //InvoiceItem(







    [Table(nameof(Location))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    //[RuleCombinationOfPropertiesIsUnique("UniqBankCode", DefaultContexts.Save, "Code")]
    [RuleCombinationOfPropertiesIsUnique("UniqLocationName", DefaultContexts.Save, "Name")]
    public partial class Location : BaseEntity<int>, ITreeNode
    {
        private Location parent;
        private IList<Location> children;

        public Location()
        {
            Children = new BindingList<Location>();
        }

        //[MaxLength(32)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        //[Column(TypeName = "nvarchar(32)")]
        public LocationHeaderType LocationType { get; set; }




        public virtual Location Parent
        {
            get { return parent; }
            set { SetReferencePropertyValue(ref parent, value); }
        }

        [Browsable(false)]
        [ForeignKey(nameof(Parent))]
        public int? ParentId { get; set; }


        //public virtual HashSet<LocationType> Children { get; set; }

        [DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        [InverseProperty(nameof(Parent))]
        public virtual IList<Location> Children
        {
            get { return children; }
            set { SetReferencePropertyValue(ref children, value); }
        }

        IBindingList ITreeNode.Children
        {
            get { return Children as IBindingList; }
        }

        ITreeNode ITreeNode.Parent
        {
            get { return Parent as ITreeNode; }
        }


        [NotMapped, Browsable(false), RuleFromBoolProperty("LocationTypeCircularReferences",
        DefaultContexts.Save,
        "Circular refrerence detected. To correct this error, set the Parent property to another value.",
        UsedProperties = nameof(Parent))]
        public bool IsValid
        {
            get
            {
                Location currentObj = Parent;
                while (currentObj != null)
                {
                    if (currentObj == this)
                    {
                        return false;
                    }
                    currentObj = currentObj.Parent;
                }
                return true;
            }
        }





        [MaxLength(128)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }

        [MaxLength(256)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Address { get; set; }






        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }

    }




    [Table(nameof(Bank))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Banks")]
    [RuleCombinationOfPropertiesIsUnique("UniqBankCode", DefaultContexts.Save, "Code")]
    [RuleCombinationOfPropertiesIsUnique("UniqBankName", DefaultContexts.Save, "Name")]
    public partial class Bank : BaseEntity<int>
    {
        public Bank()
        {

        }


        [MaxLength(16)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Code { get; set; }

        [MaxLength(64)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }

        [MaxLength(128)]
        //[System.ComponentModel.DataAnnotations.Required][RuleRequiredField(DefaultContexts.Save)]
        public string Address { get; set; }


        [MaxLength(128)]
        //[System.ComponentModel.DataAnnotations.Required][RuleRequiredField(DefaultContexts.Save)]
        public string ContactName { get; set; }

        [MaxLength(128)]
        public string ContactDetails { get; set; }

        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


    }





    [Table(nameof(WasteCategory))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Waste Categories")]
    [RuleCombinationOfPropertiesIsUnique("UniqWasteCategoryName", DefaultContexts.Save, "Name")]
    public partial class WasteCategory : BaseEntity<int>
    {
        public WasteCategory()
        {

        }



        [MaxLength(128)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }

        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


        [DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        //[DevExpress.ExpressApp.DC.Aggregated]
        public virtual List<WasteItem> Items { get; set; }

    }





    [Table(nameof(WasteItem))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Waste Items")]
    [RuleCombinationOfPropertiesIsUnique("UniqWasteItemCode", DefaultContexts.Save, "Code")]
    [RuleCombinationOfPropertiesIsUnique("UniqWasteItemName", DefaultContexts.Save, "Name")]
    public partial class WasteItem : BaseEntity<int>
    {
        public WasteItem()
        {

        }

        [Browsable(false)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual WasteCategory Category { get; set; }

        [MaxLength(16)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Code { get; set; }

        [MaxLength(128)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }



        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


    }



    [Table(nameof(WasteBuyer))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Waste Buyers")]
    [RuleCombinationOfPropertiesIsUnique("UniqWasteBuyerName", DefaultContexts.Save, "Name")]
    public partial class WasteBuyer : BaseEntity<int>
    {
        public WasteBuyer()
        {

        }

        [Browsable(false)]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }


        [Browsable(false)]
        public int BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }


        [MaxLength(128)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }

        [MaxLength(20)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string AccountNo { get; set; }

        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


        [ModelDefault("AllowEdit", "False")]
        [DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        //[DevExpress.ExpressApp.DC.Aggregated]
        public virtual List<SalesInvoice> Invoices { get; set; }

    }



    [Table(nameof(WasteSeller))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Waste Sellers")]
    [RuleCombinationOfPropertiesIsUnique("UniqWasteSellerName", DefaultContexts.Save, "Name")]
    public partial class WasteSeller : BaseEntity<int>
    {
        public WasteSeller()
        {

        }

        [Browsable(false)]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }


        [Browsable(false)]
        public int BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }


        [MaxLength(128)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get; set; }

        [MaxLength(20)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string AccountNo { get; set; }

        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Name}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


    }



    [Table(nameof(WasteListing))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Waste Listing")]
    public partial class WasteListing : BaseEntity<int>
    {
        public WasteListing()
        {
            Random rand = new Random();
            var date = DateTime.UtcNow;
            ListingNo = $"LST-{date.ToString("yyyMMdd")}-{date.ToString("hms")}{rand.Next(1, 10)}";

        }

        [Browsable(false)]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public virtual WasteSeller Seller { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime ListingDate { get; set; }

        [MaxLength(20)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string ListingNo { get; set; }

        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Seller?.DisplayTitle} - {ListingNo}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


        [DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        [DevExpress.ExpressApp.DC.Aggregated]
        public virtual List<ListingItem> Items { get; set; }


        [DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        [DevExpress.ExpressApp.DC.Aggregated]
        public virtual List<SalesInvoice> Invoices { get; set; }
    }



    [Table(nameof(ListingItem))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Listing Items")]
    [RuleCombinationOfPropertiesIsUnique("UniqListingItemId", DefaultContexts.Save, "ListingId,ItemId")]
    public partial class ListingItem : BaseEntity<int>
    {
        public ListingItem()
        {

        }

        [Browsable(false)]
        public int ListingId { get; set; }

        [ForeignKey(nameof(ListingId))]
        public virtual WasteListing Listing { get; set; }

        [Browsable(false)]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual WasteItem Item { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public int Quantity { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public decimal Price { get; set; }



        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Item?.DisplayTitle}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


    }



    [Table(nameof(SalesInvoice))]
    [DefaultClassOptions]
    [DefaultProperty("DisplayTitle")]
    [XafDisplayName("Sales Invoice")]
    public partial class SalesInvoice : BaseEntity<int>
    {
        public SalesInvoice()
        {
            Random rand = new Random();
            var date = DateTime.UtcNow;
            InvoiceNo = $"INV-{date.ToString("yyyMMdd")}-{date.ToString("hms")}{rand.Next(1, 10)}";

        }


        [Browsable(false)]
        public int ListingId { get; set; }

        [ForeignKey(nameof(ListingId))]
        public virtual WasteListing Listing { get; set; }


        [Browsable(false)]
        public int BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public virtual WasteBuyer Buyer { get; set; }

        [MaxLength(20)]
        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public string InvoiceNo { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime InvoiceDate { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [RuleRequiredField(DefaultContexts.Save)]
        public decimal Amount { get; set; }


        [NotMapped]
        public override string DisplayTitle
        {
            get
            {
                return $"{Listing?.DisplayTitle} - {InvoiceNo}";
            }
        }



        public override void OnCreated()
        {

            base.OnCreated();



        }
        public override void OnSaving()
        {
            base.OnSaving();

        }
        public override void OnLoaded()
        {

            base.OnLoaded();

        }


       


    }



}

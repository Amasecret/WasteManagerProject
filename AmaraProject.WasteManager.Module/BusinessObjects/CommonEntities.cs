using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
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
    //Bank

    //WasteCategory(Name,Description)
    //WasteItem(CategoryId,Name,Description
    //Vendor(
    //Customer

    //Customer
    //CustomerListing(
    //ListingItem(
    //

    //SalesInvoice(
    //InvoiceItem(


    public enum LocationHeaderType
    {
        Country = 1, State = 2, LGA = 3, Region = 4, Area = 5, Zone = 6, Street = 7
    }


    public abstract class BaseEntity<TId> :  IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {

        #region IObjectSpaceLink members  
        protected IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }


        [NotMapped]
        protected EFObjectSpace EFObjectSpace
        {
            get { return (EFObjectSpace)objectSpace; }
        }


        [NotMapped]
        protected WasteManagerDbContext DbContext
        {
            get { return new WasteManagerDbContext(EFObjectSpace.ObjectContext); }
        }




        #endregion

        protected PermissionPolicyUser GetCurrentUser()
        {
            return objectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        }


        public virtual void OnCreated()
        {
            

        }

        public virtual void OnSaving()
        {
           
        }

        public virtual void OnLoaded()
        {
        }


        [Key]
        [DetailViewLayout("Metadata", LayoutGroupType.SimpleEditorsGroup, 120)]
        [DevExpress.Persistent.Base.Index(90)]
        public virtual TId Id { get; set; }


       


        ////[MaxLength(256)]
        //[DetailViewLayout("MainTab", LayoutGroupType.TabbedGroup, 121)]
        ////[Column(TypeName = "nvarchar(max)")]
        ////[DetailViewLayout("Metadata", LayoutGroupType.SimpleEditorsGroup, 120)]
        //[DevExpress.Persistent.Base.Index(100)]
        //[FieldSize(FieldSizeAttribute.Unlimited), VisibleInListView(false)]
        //[EditorAlias(EditorAliases.RichTextPropertyEditor)]
        //public string Description { get; set; }

       
       



        [NotMapped]
        [DevExpress.Persistent.Base.Index(89)]
        [DetailViewLayout("Metadata", LayoutGroupType.SimpleEditorsGroup, 120)]
        public abstract string DisplayTitle
        {
            get;
        }

     
        #region INotifyPropertyChanged
        private PropertyChangedEventHandler propertyChanged;



        protected bool SetPropertyValue<T>(ref T propertyValue, T newValue, [CallerMemberName] string propertyName = null) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(propertyValue, newValue))
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetPropertyValue<T>(ref T? propertyValue, T? newValue, [CallerMemberName] string propertyName = null) where T : struct
        {
            if (EqualityComparer<T?>.Default.Equals(propertyValue, newValue))
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetPropertyValue(ref string propertyValue, string newValue, [CallerMemberName] string propertyName = null)
        {
            if (propertyValue == newValue)
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetReferencePropertyValue<T>(ref T propertyValue, T newValue, [CallerMemberName] string propertyName = null) where T : class
        {
            if (propertyValue == newValue)
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { propertyChanged += value; }
            remove { propertyChanged -= value; }
        }
        #endregion

    }




}

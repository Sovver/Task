using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Task.Module.BusinessObjects
{
    [DefaultClassOptions]
   
    public class Person : BaseObject
    { 
        public Person(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        private string _name;


        public string FullName
        {
            get
            {
                return _name;
            }
            set
            {
                SetPropertyValue("Задача", ref _name, value);
            }
        }

        [Association]
        public XPCollection<work> Works
        {
            get
            {
                return GetCollection<work>("Works")
;
            }

        }
        public string СписокДел
        {
            get
            {
                if (Works != null)
                    return string.Join(", ", Works.Select(t => t.Дело).ToArray());
                else
                    return "N/A";

            }
        }
    }
}
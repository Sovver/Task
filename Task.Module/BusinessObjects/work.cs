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

    public class work : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public work(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

          
        }
        private string _tag;
        private string _comment;
        private DateTime _data;
        private bool _completed;
        private Task _task;
        private string _tak;
        private Person _person;


        public string Дело
        {
            get
            {
                return _tag;
            }
            set
            {
                SetPropertyValue("Задача", ref _tag, value);
            }
        }

        public string Комментарий
        {
            get
            {
                return _comment;
            }
            set
            {
                SetPropertyValue("Комментарий", ref _comment, value);
            }
        }

        public DateTime Дата
        {
            get
            {
                return _data;
            }
            set
            {
                SetPropertyValue("Дата", ref _data, value);
            }
        }

        public bool Готовность
        {
            get
            {

                if (Task.Готовность == true)
                {
                    _completed = true;
                    return _completed;
                }
                else
                {

                    return _completed;

                }
            }
            set
            {
                SetPropertyValue("Готовность", ref _completed, value);
            }
        }

        public string Задача
        {
            get
            {
                if (Task != null)
                {
                    _tak = Task.Задача;
                    return _tak;
                }


                else
                {
                    return "N/A";
                }
            }
            set
            {
                SetPropertyValue("Комментарий", ref _tak, value);
            }
        }


        public string Статус
        {
            get
            {

                if (Готовность == true)
                {
                    return "завершенно";
                }
                else
                {
                    var periodNow = DateTime.Now;
                    TimeSpan date3 = Дата.Subtract(periodNow);
                    var periodTo = new TimeSpan(120, 0, 0);
                    if (Дата < periodNow)
                    {
                        return "Проблема";
                    }
                    else if (periodTo > date3)
                    {
                        return "Tребует внимания";
                    }
                    else
                    {
                        return "N/A";
                    }
                }

            }
        }

        public int Ch
        {
            get
            {
                if (Статус == "завершенно")
                {
                    return 1;
                }
                else if (Статус == "Tребует внимания")
                {
                    return 2;
                }
                else if (Статус == "Проблема")
                {
                    return 3;
                }
                else

                {
                   
                    return 0;
                }

            }
        }
       
        [Association]
        public Task Task
        {
            get
            {
                return _task;
            }
            set
            {
                SetPropertyValue("Task", ref _task, value);
            }
        }

        [Association]
        public Person Работник
        {
            get
            {
                return _person;
            }
            set
            {
                SetPropertyValue("Person", ref _person, value);
            }
        }
    }

    
}


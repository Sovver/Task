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
   
    public class Task : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Task(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
          
          

        }
        private string _task;
        private string _comment;
        private DateTime _data;
        private bool _completed;
        private int _c;
       // private int _ui;


        //[Size(2000)]
        public string Задача
        {
            get
            {
                return _task;
            }
            set
            {
                SetPropertyValue("Задача", ref _task, value);
            }
        }

        public string Клмментарий
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
                return _completed;
            }
            set
            {
                SetPropertyValue("Готовность", ref _completed, value);
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
                    var periodTo = new TimeSpan(120,0,0);
                    int count1 = Список.ToCharArray().Where(c => c == '1').Count();
                    
                    int count3 = Список.ToCharArray().Where(c => c == '3').Count();
                    if (Дата < periodNow)
                    {
                        return "Проблема";
                    }

                    else if (count3 == Che)
                    {
                        return "Проблема";
                    }
                    else if (count3 >= 1)
                    {
                        return "Tребует внимания";
                    }
                    else if (periodTo > date3)
                    {
                        return "Tребует внимания";
                    }

                    else if (count1 == Che)
                    {
                        return "Все задания выполнены";
                    }
                    else 
                    {
                        return "N/A";
                    }
                }

            }
        }
        [Association]
        public XPCollection<work> Дела
        {
            get
            {
                return GetCollection<work>("Дела")
;
            }

        }
        public string СписокДел
        {
            get
            {
                if (Дела != null)
                    return string.Join(", ", Дела.Select(t => t.Дело).ToArray());
                else
                    return "N/A";

            }
        }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        private string Список
        {
            get
            {
                if (Дела != null)
                    
                return string.Join(", ", Дела.Select(t => t.Ch).ToArray());
                else
                    return "N/A";

            }
        }

        
        private int Che
        {
            get
            {
                var count = Список.Where((n) => n >= '0' && n <= '9').Count();
                return count;
            }
            set
            {
                SetPropertyValue("Готовность", ref _c, value);
            }
        }
    }





}

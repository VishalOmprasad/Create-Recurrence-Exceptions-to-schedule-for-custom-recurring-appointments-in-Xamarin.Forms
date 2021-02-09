using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace RecurrenceExceptions
{
    public class Meeting 
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color EventColor { get; set; }
        public string RecurrenceRule { get; set; }
        public DateTime ActualDate { get; set; }
        public object RecurrenceID { get; set; }
        public object Id { get; set; }
        public ObservableCollection<DateTime> RecurrenceExceptionDates { get; set; } = new ObservableCollection<DateTime>();

    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace RecurrenceExceptions
{
    public class CustomAppointmentModel : INotifyPropertyChanged
    {

        private ObservableCollection<Meeting> meetings;
        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime MoveDate { get; set; } = new DateTime(2017, 09, 03, 09, 0, 0);
        public Command AddCustomExceptionDates { get; set; }
        public Command RemoveCustomExceptionDates { get; set; }
        public Command AddCustomExceptionAppointment { get; set; }
        public Command RemoveCustomExceptionAppointment { get; set; }
        public ObservableCollection<Meeting> EventCollection
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("EventCollection");
            }
        }
        public CustomAppointmentModel()
        {
            this.EventCollection = new ObservableCollection<Meeting>();
            // Set the commands for Add/Remove the exception dates.
            this.SetUpCommands();

            // Create the new recurrence exception dates.
            var exceptionDate = new DateTime(2017, 09, 07);

            //Adding schedule appointment in schedule appointment collection 
            var recurrenceAppointment = new Meeting()
            {
                Id = 1,
                From = new DateTime(2017, 09, 01, 10, 0, 0),
                To = new DateTime(2017, 09, 01, 12, 0, 0),
                EventName = "Occurs Daily",
                EventColor = Color.Blue
            };
            recurrenceAppointment.RecurrenceRule = "FREQ=DAILY;COUNT=20";
            // Add RecuurenceExceptionDates to appointment.
            recurrenceAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            {
               exceptionDate
            };

            //Adding schedule appointment in schedule appointment collection
            EventCollection.Add(recurrenceAppointment);
        }

        /// <summary>
        /// Set up commands for Add/Remove the exception Appointments.
        /// </summary>
        private void SetUpCommands()
        {
            AddCustomExceptionDates = new Command(TapAddExceptionDates);
            RemoveCustomExceptionDates = new Command(TapRemoveExceptionDates);
            AddCustomExceptionAppointment = new Command(AddRecurrenceExceptionAppointment);
            RemoveCustomExceptionAppointment = new Command(RemoveRecurrenceExceptionAppointment);
        }

        /// <summary>
        /// Removes the recurrence exception appointment.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void RemoveRecurrenceExceptionAppointment(object obj)
        {
            if (this.EventCollection.Count > 1)
            {
                var exceptionAppointment = this.EventCollection[1];
                this.EventCollection.Remove(exceptionAppointment);
            }
        }

        /// <summary>
        /// Adds the recurrence exception appointment.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void AddRecurrenceExceptionAppointment(object obj)
        {
            var recurrenceAppointment = this.EventCollection[0];
            var exceptionDate = new DateTime(2017, 09, 07);

            // Add duplicate appointment to the current recurrence series
            var exceptionAppointment = new Meeting()
            {
                Id = 2,
                From = new DateTime(2017, 09, 07, 12, 0, 0),
                To = new DateTime(2017, 09, 07, 14, 0, 0),
                EventName = "Meeting",
                EventColor = Color.Red,
                RecurrenceID = 1,
                ActualDate = exceptionDate
            };

            this.EventCollection.Add(exceptionAppointment);
        }

        /// <summary>
        /// Taps the remove exception dates.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void TapRemoveExceptionDates(object obj)
        {
            // Remove recurrence exception dates.
            EventCollection[0].RecurrenceExceptionDates.RemoveAt(0);
        }

        /// <summary>
        /// Taps the add exception dates.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void TapAddExceptionDates(object obj)
        {
            // Add recurrence exception dates.
            EventCollection[0].RecurrenceExceptionDates.Add(new DateTime(2017, 09, 04));
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

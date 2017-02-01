﻿using EventMaker_ASS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker_ASS.Common;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace EventMaker_ASS.ViewModel
{
    public class EventViewModel // : INotifyPropertyChanged
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }

        private DateTimeOffset _date;

        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private TimeSpan _time;

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// Nedenforstående property eventhandler er af datatypen Eventhandler. 
        /// Metoden i eventhandleren CreateEvnet kan nu tilgås via´"filstien"
        /// Handler.EventHandler. 
        /// </summary>
        /// 

        /// Fuld property af events som også er oprettet i EventCatalogSingleton filen. 

        private ObservableCollection<Event> _events;

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; }
        }


        public Handler.EventHandler eh { get; set; }

        public ICommand CreateEventCommand { get; set; }

        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            Events = EventCatalogSingleton.Instance.Events;

            eh = new Handler.EventHandler(this);
            CreateEventCommand = new RelayCommand(eh.CreateEvent, null);
        }

    }
}

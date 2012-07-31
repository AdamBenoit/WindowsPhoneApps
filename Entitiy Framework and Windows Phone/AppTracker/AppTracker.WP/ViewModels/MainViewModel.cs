using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using AppTracker.WP.Models;
using System.Data.Linq;


namespace AppTracker.WP
{
    public class MainViewModel : INotifyPropertyChanged
    {
       private const string ConnectionString = @"isostore:/AppTrackerDatabase.sdf";
       private AppTrackerDataContext _context = new AppTrackerDataContext(ConnectionString);

       public MainViewModel()
        {
            try
            {
                if (!_context.DatabaseExists())
                {
                    // create database if it does not exist
                    var dd = new DefaultData.DefaultData(_context);
                    if (dd.CreateDatabase(true))
                    {
                        if (Debugger.IsAttached)
                        {
                            MessageBox.Show("Database created.");
                        }
                    }
                    else
                    {
                        if (Debugger.IsAttached)
                        {
                            MessageBox.Show("Error creating database");
                        }
                    }
                    if (dd.PopulateCategoriesTable() && dd.PopulatePlatformsTable() && dd.PopulateStatusTable() && dd.PopulateTagsTable() && dd.PopulateIdeasTable())
                    {
                        if (Debugger.IsAttached)
                        {
                            MessageBox.Show("Tables populated");
                        }
                    }
                    else
                    {
                        if (Debugger.IsAttached)
                        {
                            MessageBox.Show("Error populating tables.");
                        }
                    }
                }
                else
                {
                    if (Debugger.IsAttached)
                    {
                        MessageBox.Show("Database Exists.");
                    }
                }
            }
            catch (Exception ex )
            {
                if (Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        private ObservableCollection<Idea> _ideas; 
        public ObservableCollection<Idea> Ideas
        {
            get
            {
                return _ideas;
            }
            set
            {
                if (value != _ideas)
                {
                    _ideas = value;
                    NotifyPropertyChanged("Ideas");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            var ideas = _context.Ideas.Where(i => i.Id != 0);
            Ideas = new ObservableCollection<Idea>(ideas.ToList());

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
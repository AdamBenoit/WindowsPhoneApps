using System;
using System.Collections.Generic;
using System.Windows;
using AppTracker.WP.Models;

namespace AppTracker.WP.DefaultData
{
    public class DefaultData
    {
        private AppTrackerDataContext _context;

        public DefaultData(AppTrackerDataContext context)
        {
            _context = context;
        }

        public bool CreateDatabase(bool deleteExisting = false)
        {
            try
            {
                if (_context.DatabaseExists())
                {
                    if(deleteExisting)
                    {
                        _context.DeleteDatabase();
                    }
                    else
                    {
                        return false;
                    }
                 }   
                _context.CreateDatabase();
                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }

        public bool PopulateCategoriesTable()
        {
            try
            {
                var categories = new List<Category>();

                var category = new Category { Id = 1, Name = "Productivity" };
                categories.Add(category);

                category = new Category { Id = 2, Name = "Games" };
                categories.Add(category);

                category = new Category { Id = 3, Name = "Other" };
                categories.Add(category);


                _context.Categories.InsertAllOnSubmit(categories);
                _context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }

        public bool PopulateStatusTable()
        {
            try
            {
                var statuses = new List<Status>();

                var status = new Status { Id = 1, Name = "In Progress", Description = "Description Description Description Description Description" };
                statuses.Add(status);

                status = new Status { Id = 2, Name = "Games", Description = "Description Description Description Description Description" };
                statuses.Add(status);

                status = new Status { Id = 3, Name = "Other", Description = "Description Description Description Description Description" };
                statuses.Add(status);

                _context.Status.InsertAllOnSubmit(statuses);
                _context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }

        public bool PopulatePlatformsTable()
        {
            try
            {
                var platforms = new List<Platform>();

                var platform = new Platform { Id = 1, Name = "Windows Phone", Description = "Description Description Description Description Description" };
                platforms.Add(platform);

                platform = new Platform { Id = 2, Name = "Android", Description = "Description Description Description Description Description" };
                platforms.Add(platform);

                platform = new Platform { Id = 3, Name = "iOS", Description = "Description Description Description Description Description" };
                platforms.Add(platform);

                _context.Platforms.InsertAllOnSubmit(platforms);
                _context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }

        public bool PopulateTagsTable()
        {
            try
            {
                var tags = new List<Tag>();

                var tag = new Tag { Id = 1, Name = "Tag 1", Description = "Description Description Description Description Description" };
                tags.Add(tag);

                tag = new Tag { Id = 2, Name = "Tag 2", Description = "Description Description Description Description Description" };
                tags.Add(tag);

                tag = new Tag { Id = 3, Name = "Tag 3", Description = "Description Description Description Description Description" };
                tags.Add(tag);

                _context.Tags.InsertAllOnSubmit(tags);
                _context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }

        public bool PopulateIdeasTable()
        {
            try
            {
                var ideas = new List<Idea>();

                var idea = new Idea { Id = 1, Name = "Idea 1", Description = "Description Description Description Description Description", CategoryId = 1, StatusId = 3, DateAdded = DateTime.Now, DateUpdated = DateTime.Now };
                ideas.Add(idea);

                idea = new Idea { Id = 2, Name = "Idea 2", Description = "Description Description Description Description Description", CategoryId = 2, StatusId = 1, DateAdded = DateTime.Now, DateUpdated = DateTime.Now };
                ideas.Add(idea);

                idea = new Idea { Id = 3, Name = "Idea 3", Description = "Description Description Description Description Description", CategoryId = 3, StatusId = 2, DateAdded = DateTime.Now, DateUpdated = DateTime.Now};
                ideas.Add(idea);

                _context.Ideas.InsertAllOnSubmit(ideas);
                _context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            }
        }
    }
}
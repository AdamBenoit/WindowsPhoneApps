﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("AppTrackerDataModel", "CategoryIdea", "Category", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(AppTracker.Entities.Category), "Idea", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(AppTracker.Entities.Idea), true)]
[assembly: EdmRelationshipAttribute("AppTrackerDataModel", "IdeaNote", "Idea", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(AppTracker.Entities.Idea), "Note", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(AppTracker.Entities.Note), true)]

#endregion

namespace AppTracker.Entities
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AppTrackerDataModelContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AppTrackerDataModelContainer object using the connection string found in the 'AppTrackerDataModelContainer' section of the application configuration file.
        /// </summary>
        public AppTrackerDataModelContainer() : base("name=AppTrackerDataModelContainer", "AppTrackerDataModelContainer")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AppTrackerDataModelContainer object.
        /// </summary>
        public AppTrackerDataModelContainer(string connectionString) : base(connectionString, "AppTrackerDataModelContainer")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AppTrackerDataModelContainer object.
        /// </summary>
        public AppTrackerDataModelContainer(EntityConnection connection) : base(connection, "AppTrackerDataModelContainer")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Idea> Ideas
        {
            get
            {
                if ((_Ideas == null))
                {
                    _Ideas = base.CreateObjectSet<Idea>("Ideas");
                }
                return _Ideas;
            }
        }
        private ObjectSet<Idea> _Ideas;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Category> Categories
        {
            get
            {
                if ((_Categories == null))
                {
                    _Categories = base.CreateObjectSet<Category>("Categories");
                }
                return _Categories;
            }
        }
        private ObjectSet<Category> _Categories;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Note> Notes
        {
            get
            {
                if ((_Notes == null))
                {
                    _Notes = base.CreateObjectSet<Note>("Notes");
                }
                return _Notes;
            }
        }
        private ObjectSet<Note> _Notes;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Ideas EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToIdeas(Idea idea)
        {
            base.AddObject("Ideas", idea);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Categories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCategories(Category category)
        {
            base.AddObject("Categories", category);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Notes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToNotes(Note note)
        {
            base.AddObject("Notes", note);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppTrackerDataModel", Name="Category")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Category : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Category object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Category CreateCategory(global::System.Int32 id, global::System.String name)
        {
            Category category = new Category();
            category.Id = id;
            category.Name = name;
            return category;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AppTrackerDataModel", "CategoryIdea", "Idea")]
        public EntityCollection<Idea> Ideas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Idea>("AppTrackerDataModel.CategoryIdea", "Idea");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Idea>("AppTrackerDataModel.CategoryIdea", "Idea", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppTrackerDataModel", Name="Idea")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Idea : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Idea object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        /// <param name="categoryId">Initial value of the CategoryId property.</param>
        public static Idea CreateIdea(global::System.Int32 id, global::System.String name, global::System.String description, global::System.Int32 categoryId)
        {
            Idea idea = new Idea();
            idea.Id = id;
            idea.Name = name;
            idea.Description = description;
            idea.CategoryId = categoryId;
            return idea;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                OnCategoryIdChanging(value);
                ReportPropertyChanging("CategoryId");
                _CategoryId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CategoryId");
                OnCategoryIdChanged();
            }
        }
        private global::System.Int32 _CategoryId;
        partial void OnCategoryIdChanging(global::System.Int32 value);
        partial void OnCategoryIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AppTrackerDataModel", "CategoryIdea", "Category")]
        public Category Category
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("AppTrackerDataModel.CategoryIdea", "Category").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("AppTrackerDataModel.CategoryIdea", "Category").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Category> CategoryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("AppTrackerDataModel.CategoryIdea", "Category");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Category>("AppTrackerDataModel.CategoryIdea", "Category", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AppTrackerDataModel", "IdeaNote", "Note")]
        public EntityCollection<Note> Notes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Note>("AppTrackerDataModel.IdeaNote", "Note");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Note>("AppTrackerDataModel.IdeaNote", "Note", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppTrackerDataModel", Name="Note")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Note : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Note object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="ideaId">Initial value of the IdeaId property.</param>
        /// <param name="noteText">Initial value of the NoteText property.</param>
        public static Note CreateNote(global::System.Int32 id, global::System.Int32 ideaId, global::System.String noteText)
        {
            Note note = new Note();
            note.Id = id;
            note.IdeaId = ideaId;
            note.NoteText = noteText;
            return note;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdeaId
        {
            get
            {
                return _IdeaId;
            }
            set
            {
                OnIdeaIdChanging(value);
                ReportPropertyChanging("IdeaId");
                _IdeaId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IdeaId");
                OnIdeaIdChanged();
            }
        }
        private global::System.Int32 _IdeaId;
        partial void OnIdeaIdChanging(global::System.Int32 value);
        partial void OnIdeaIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NoteText
        {
            get
            {
                return _NoteText;
            }
            set
            {
                OnNoteTextChanging(value);
                ReportPropertyChanging("NoteText");
                _NoteText = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NoteText");
                OnNoteTextChanged();
            }
        }
        private global::System.String _NoteText;
        partial void OnNoteTextChanging(global::System.String value);
        partial void OnNoteTextChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AppTrackerDataModel", "IdeaNote", "Idea")]
        public Idea Idea
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Idea>("AppTrackerDataModel.IdeaNote", "Idea").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Idea>("AppTrackerDataModel.IdeaNote", "Idea").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Idea> IdeaReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Idea>("AppTrackerDataModel.IdeaNote", "Idea");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Idea>("AppTrackerDataModel.IdeaNote", "Idea", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
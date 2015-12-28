﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SteamAchievements.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="steam")]
	internal partial class SteamDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAchievement(Achievement instance);
    partial void UpdateAchievement(Achievement instance);
    partial void DeleteAchievement(Achievement instance);
    partial void InsertUserAchievement(UserAchievement instance);
    partial void UpdateUserAchievement(UserAchievement instance);
    partial void DeleteUserAchievement(UserAchievement instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public SteamDataContext() : 
				base(global::SteamAchievements.Data.Properties.Settings.Default.steamConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SteamDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SteamDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SteamDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SteamDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Achievement> Achievements
		{
			get
			{
				return this.GetTable<Achievement>();
			}
		}
		
		public System.Data.Linq.Table<UserAchievement> UserAchievements
		{
			get
			{
				return this.GetTable<UserAchievement>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.steam_Achievement")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Achievement : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _GameId;
		
		private string _Description;
		
		private string _ImageUrl;
		
		private string _ApiName;
		
		private EntitySet<UserAchievement> _steam_UserAchievements;
		
		private bool serializing;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnGameIdChanging(int value);
    partial void OnGameIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnImageUrlChanging(string value);
    partial void OnImageUrlChanged();
    partial void OnApiNameChanging(string value);
    partial void OnApiNameChanged();
    #endregion
		
		public Achievement()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameId", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public int GameId
		{
			get
			{
				return this._GameId;
			}
			set
			{
				if ((this._GameId != value))
				{
					this.OnGameIdChanging(value);
					this.SendPropertyChanging();
					this._GameId = value;
					this.SendPropertyChanged("GameId");
					this.OnGameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageUrl", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string ImageUrl
		{
			get
			{
				return this._ImageUrl;
			}
			set
			{
				if ((this._ImageUrl != value))
				{
					this.OnImageUrlChanging(value);
					this.SendPropertyChanging();
					this._ImageUrl = value;
					this.SendPropertyChanged("ImageUrl");
					this.OnImageUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApiName", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string ApiName
		{
			get
			{
				return this._ApiName;
			}
			set
			{
				if ((this._ApiName != value))
				{
					this.OnApiNameChanging(value);
					this.SendPropertyChanging();
					this._ApiName = value;
					this.SendPropertyChanged("ApiName");
					this.OnApiNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Achievement_UserAchievement", Storage="_steam_UserAchievements", ThisKey="Id", OtherKey="AchievementId")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7, EmitDefaultValue=false)]
		public EntitySet<UserAchievement> UserAchievements
		{
			get
			{
				if ((this.serializing 
							&& (this._steam_UserAchievements.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._steam_UserAchievements;
			}
			set
			{
				this._steam_UserAchievements.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_steam_UserAchievements(UserAchievement entity)
		{
			this.SendPropertyChanging();
			entity.Achievement = this;
		}
		
		private void detach_steam_UserAchievements(UserAchievement entity)
		{
			this.SendPropertyChanging();
			entity.Achievement = null;
		}
		
		private void Initialize()
		{
			this._steam_UserAchievements = new EntitySet<UserAchievement>(new Action<UserAchievement>(this.attach_steam_UserAchievements), new Action<UserAchievement>(this.detach_steam_UserAchievements));
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
		
		[global::System.Runtime.Serialization.OnSerializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerializing(StreamingContext context)
		{
			this.serializing = true;
		}
		
		[global::System.Runtime.Serialization.OnSerializedAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerialized(StreamingContext context)
		{
			this.serializing = false;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.steam_UserAchievement")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class UserAchievement : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private long _SteamUserId;
		
		private int _AchievementId;
		
		private System.DateTime _Date;
		
		private bool _Published;
		
		private bool _Hidden;
		
		private EntityRef<Achievement> _steam_Achievement;
		
		private EntityRef<User> _User;
		
		private bool serializing;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFacebookUserIdChanging(long value);
    partial void OnFacebookUserIdChanged();
    partial void OnAchievementIdChanging(int value);
    partial void OnAchievementIdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnPublishedChanging(bool value);
    partial void OnPublishedChanged();
    partial void OnHiddenChanging(bool value);
    partial void OnHiddenChanged();
    #endregion
		
		public UserAchievement()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="int not null", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SteamUserId", DbType="BigInt NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public long FacebookUserId
		{
			get
			{
				return this._SteamUserId;
			}
			set
			{
				if ((this._SteamUserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFacebookUserIdChanging(value);
					this.SendPropertyChanging();
					this._SteamUserId = value;
					this.SendPropertyChanged("FacebookUserId");
					this.OnFacebookUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AchievementId", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public int AchievementId
		{
			get
			{
				return this._AchievementId;
			}
			set
			{
				if ((this._AchievementId != value))
				{
					if (this._steam_Achievement.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAchievementIdChanging(value);
					this.SendPropertyChanging();
					this._AchievementId = value;
					this.SendPropertyChanged("AchievementId");
					this.OnAchievementIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="datetime not null")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Published", DbType="bit not null")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public bool Published
		{
			get
			{
				return this._Published;
			}
			set
			{
				if ((this._Published != value))
				{
					this.OnPublishedChanging(value);
					this.SendPropertyChanging();
					this._Published = value;
					this.SendPropertyChanged("Published");
					this.OnPublishedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hidden", DbType="bit not null")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public bool Hidden
		{
			get
			{
				return this._Hidden;
			}
			set
			{
				if ((this._Hidden != value))
				{
					this.OnHiddenChanging(value);
					this.SendPropertyChanging();
					this._Hidden = value;
					this.SendPropertyChanged("Hidden");
					this.OnHiddenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Achievement_UserAchievement", Storage="_steam_Achievement", ThisKey="AchievementId", OtherKey="Id", IsForeignKey=true)]
		public Achievement Achievement
		{
			get
			{
				return this._steam_Achievement.Entity;
			}
			set
			{
				Achievement previousValue = this._steam_Achievement.Entity;
				if (((previousValue != value) 
							|| (this._steam_Achievement.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._steam_Achievement.Entity = null;
						previousValue.UserAchievements.Remove(this);
					}
					this._steam_Achievement.Entity = value;
					if ((value != null))
					{
						value.UserAchievements.Add(this);
						this._AchievementId = value.Id;
					}
					else
					{
						this._AchievementId = default(int);
					}
					this.SendPropertyChanged("Achievement");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_UserAchievement", Storage="_User", ThisKey="FacebookUserId", OtherKey="FacebookUserId", IsForeignKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7, EmitDefaultValue=false)]
		public User User
		{
			get
			{
				if ((this.serializing 
							&& (this._User.HasLoadedOrAssignedValue == false)))
				{
					return null;
				}
				return this._User.Entity;
			}
			set
			{
				if ((this._User.Entity != value))
				{
					this.SendPropertyChanging();
					this._User.Entity = value;
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			this._steam_Achievement = default(EntityRef<Achievement>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
		
		[global::System.Runtime.Serialization.OnSerializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerializing(StreamingContext context)
		{
			this.serializing = true;
		}
		
		[global::System.Runtime.Serialization.OnSerializedAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerialized(StreamingContext context)
		{
			this.serializing = false;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.steam_User")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _FacebookUserId;
		
		private string _SteamUserId;
		
		private string _AccessToken;
		
		private bool _AutoUpdate;
		
		private bool _PublishDescription;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFacebookUserIdChanging(long value);
    partial void OnFacebookUserIdChanged();
    partial void OnSteamUserIdChanging(string value);
    partial void OnSteamUserIdChanged();
    partial void OnAccessTokenChanging(string value);
    partial void OnAccessTokenChanged();
    partial void OnAutoUpdateChanging(bool value);
    partial void OnAutoUpdateChanged();
    partial void OnPublishDescriptionChanging(bool value);
    partial void OnPublishDescriptionChanged();
    #endregion
		
		public User()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FacebookUserId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public long FacebookUserId
		{
			get
			{
				return this._FacebookUserId;
			}
			set
			{
				if ((this._FacebookUserId != value))
				{
					this.OnFacebookUserIdChanging(value);
					this.SendPropertyChanging();
					this._FacebookUserId = value;
					this.SendPropertyChanged("FacebookUserId");
					this.OnFacebookUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SteamUserId", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string SteamUserId
		{
			get
			{
				return this._SteamUserId;
			}
			set
			{
				if ((this._SteamUserId != value))
				{
					this.OnSteamUserIdChanging(value);
					this.SendPropertyChanging();
					this._SteamUserId = value;
					this.SendPropertyChanged("SteamUserId");
					this.OnSteamUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessToken", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string AccessToken
		{
			get
			{
				return this._AccessToken;
			}
			set
			{
				if ((this._AccessToken != value))
				{
					this.OnAccessTokenChanging(value);
					this.SendPropertyChanging();
					this._AccessToken = value;
					this.SendPropertyChanged("AccessToken");
					this.OnAccessTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AutoUpdate", DbType="Bit NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public bool AutoUpdate
		{
			get
			{
				return this._AutoUpdate;
			}
			set
			{
				if ((this._AutoUpdate != value))
				{
					this.OnAutoUpdateChanging(value);
					this.SendPropertyChanging();
					this._AutoUpdate = value;
					this.SendPropertyChanged("AutoUpdate");
					this.OnAutoUpdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublishDescription", DbType="Bit NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public bool PublishDescription
		{
			get
			{
				return this._PublishDescription;
			}
			set
			{
				if ((this._PublishDescription != value))
				{
					this.OnPublishDescriptionChanging(value);
					this.SendPropertyChanging();
					this._PublishDescription = value;
					this.SendPropertyChanged("PublishDescription");
					this.OnPublishDescriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
}
#pragma warning restore 1591

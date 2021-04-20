﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reflection;
using System.Windows;
using Common.Constants;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;

namespace Common.Bases
{
    public class ViewModelBase : BindableBase, INotifyDataErrorInfo
    {
        private string _title;

        public string Title
        {
            set => SetProperty(ref _title, value);
            get => _title;
        }

        public IEventAggregator EventAggregator { get; }

        public IContainerProvider Container { get; }

        protected CompositeDisposable Disposable { get; } = new CompositeDisposable();

        protected ViewModelBase()
        {
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            Container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            RegisterProperties();
            RegisterCommands();
            RegisterEvents();
            Init();
        }

        protected virtual void RegisterEvents()
        {

        }

        protected virtual void RegisterProperties()
        {
            var className = this.GetType().Name;
            if (className.EndsWith(TitleName.SuffixName))
            {
                var fieldName = $"{className.Substring(0, className.Length - TitleName.SuffixName.Length)}Name";
                if (typeof(TitleName).GetField(fieldName, BindingFlags.Public| BindingFlags.Static)?.GetValue(null) is string titleName)
                {
                    Title = titleName;
                }
                else
                {
                    Title = string.Empty;
                }
            }
        }

        protected virtual void RegisterCommands() {}

        protected virtual void Init() {}



        private ErrorsContainer<string> _errorsContainer;

        protected ErrorsContainer<string> ErrorsContainer
        {
            get
            {
                if (_errorsContainer == null)
                    _errorsContainer = new ErrorsContainer<string>(OnErrorsChanged);

                return _errorsContainer;
            }
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorsContainer.GetErrors(propertyName);
        }

        public bool HasErrors { get; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
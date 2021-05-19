using System;
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
using Prism.Services.Dialogs;

namespace Common.Bases
{
    public class ViewModelBase : BindableBase, INotifyDataErrorInfo,IDialogAware
    {

        public IEventAggregator EventAggregator { get; }

        public IContainerProvider Container { get; }

        public IDialogService DialogService { get; }

        protected CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public event Action<IDialogResult> RequestClose;

        public bool HasErrors { get; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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

        private string _title;

        public string Title
        {
            set => SetProperty(ref _title, value);
            get => _title;
        }

        protected ViewModelBase()
        {
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            Container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            DialogService = Container.Resolve<IDialogService>();
            RequestClose += ViewModel_Close;
            RegisterProperties();
            RegisterCommands();
            RegisterEvents();
            Init();
        }

        protected virtual void ViewModel_Close(IDialogResult obj)
        {

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

        protected virtual void Init()
        {

        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorsContainer.GetErrors(propertyName);
        }


        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            DialogOpened(parameters);
        }

        protected virtual void DialogOpened(IDialogParameters parameters)
        {

        }

    }
}
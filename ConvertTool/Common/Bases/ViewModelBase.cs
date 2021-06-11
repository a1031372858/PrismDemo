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
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Common.Bases
{
    public class ViewModelBase : BindableBase, INotifyDataErrorInfo, IDialogAware
    {

        public IEventAggregator EventAggregator { get; }

        public IContainerProvider Container { get; }

        public IDialogService DialogService { get; }

        public event Action<IDialogResult> RequestClose;

        protected CompositeDisposable Disposable { get; } = new CompositeDisposable();

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

        private string _title = string.Empty;

        public string Title
        {
            set => SetProperty(ref _title, value);
            get => _title;
        }

        private string _tipsMessage = string.Empty;

        public string TipsMessage
        {
            set => SetProperty(ref _tipsMessage, value);
            get => _tipsMessage;
        }

        private Visibility _messageBoxVisibility = Visibility.Collapsed;

        public Visibility MessageBoxVisibility
        {
            set => SetProperty(ref _messageBoxVisibility, value);
            get => _messageBoxVisibility;
        }

        public DelegateCommand EscCommand { set; get; }
        public DelegateCommand MessageCloseCommand { set; get; }
        

        protected ViewModelBase()
        {
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            Container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            DialogService = Container.Resolve<IDialogService>();
            RegisterBaseCommands();
            RegisterProperties();
            RegisterCommands();
            RegisterEvents();
            Init();
        }

        private void RegisterBaseCommands()
        {
            EscCommand=new DelegateCommand(ExitMethod);
            MessageCloseCommand = new DelegateCommand(CloseMessage);
        }

        private void CloseMessage()
        {
            MessageBoxVisibility = Visibility.Collapsed;
        }



        /// <summary>
        /// 1注册属性
        /// </summary>
        protected virtual void RegisterProperties() { }

        /// <summary>
        /// 2注册命令
        /// </summary>
        protected virtual void RegisterCommands() { }

        /// <summary>
        /// 3注册事件
        /// </summary>
        protected virtual void RegisterEvents() { }

        /// <summary>
        /// 4数据初始化
        /// </summary>
        protected virtual void Init() { }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorsContainer.GetErrors(propertyName);
        }


        protected virtual void ExitMethod()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }


        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }


        public void OnDialogOpened(IDialogParameters parameters)
        {
            DialogOpened(parameters);
        }

        protected virtual void DialogOpened(IDialogParameters parameters) { }

        public void ShowMessage(string msg)
        {
            TipsMessage = msg;
            MessageBoxVisibility = Visibility.Visible;
        }
    }
}
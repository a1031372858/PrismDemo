﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common.Bases;
using Prism.Services.Dialogs;

namespace Common.Views
{
    /// <summary>
    /// DialogWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogWindow : IDialogWindow
    {
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result",
            typeof(IDialogResult), typeof(IDialogWindow), new PropertyMetadata(null));

        public DialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result
        {
            get => (IDialogResult)GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        private void Header_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for PageMessage.xaml
    /// </summary>
    public partial class PageMessage : Page
    {
        public PageMessage()
        {
            InitializeComponent();
        }
        public void ImageBackClick(object sender, RoutedEventArgs e)
        {
            PageHomeDoctor page = new PageHomeDoctor();
            this.NavigationService.Navigate(page);
        }
    }
}

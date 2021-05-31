// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using BibliBookDesktop.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliBookDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();

            serviceCollection.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite("Data Source = Book.db");
            });

            serviceCollection.AddScoped<LivreServices>();

            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }

    }

    // Workaround for compiler error "error MC3050: Cannot find the type 'local:Main'"
    // It seems that, although WPF's design-time build can see Razor components, its runtime build cannot.
    public partial class Main { }
}

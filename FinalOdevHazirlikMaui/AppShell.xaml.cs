﻿using System.Runtime.CompilerServices;

namespace FinalOdevHazirlikMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public void SetFlyoutBehavior(FlyoutBehavior behavior)
        {
            this.FlyoutBehavior = behavior;
        }

        public void OpenFlyout()
        {
            this.FlyoutIsPresented = true;
        }

        
    }
}

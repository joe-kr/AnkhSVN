﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ankh.UI.Controls
{
    /// <summary>
    /// Provides a link to sign-up for CollabNet's CloudForge services
    /// </summary>
    public partial class CloudForgeControl : UserControl
    {
        private static readonly string CF_SIGNUP_URL = "https://app.cloudforge.com/subscriptions/new/?product=Free&source=ankhsvn";

        public CloudForgeControl()
        {
            InitializeComponent();
            this.cloudForgePictureBox.MaximumSize = Size.Add(this.cloudForgePictureBox.Image.Size, this.cloudForgePictureBox.Margin.Size);
            this.cloudForgePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void cloudForgePictureBox_Click(object sender, EventArgs e)
        {
            IAnkhServiceProvider sp = Parent as IAnkhServiceProvider;
            if (sp != null)
            {
                Ankh.VS.IAnkhWebBrowser wb = sp.GetService<Ankh.VS.IAnkhWebBrowser>();
                if (wb != null)
                {
                    Ankh.VS.AnkhBrowserArgs args = new Ankh.VS.AnkhBrowserArgs();
                    args.External = true;
                    Uri cfSignUpUrl = new Uri(CF_SIGNUP_URL);
                    wb.Navigate(cfSignUpUrl, args);
                }
            }
        }
    }
}

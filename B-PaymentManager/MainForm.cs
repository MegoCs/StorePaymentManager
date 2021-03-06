﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_PaymentManager
{
    public partial class MainForm : Form
    {
        ConnectionClass dbObject;
        AddProduct addPro;
        SellingOperation sellOp;
        AddClient addClient;
        ClientPaymentManger clientPaymentManger;
        ProductsShortageReport shortageForm;
        GardReport gardForm;
        private ConfigForm configForm;
        private PartnershipManagement partnershipFram;

        public MainForm()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            dbObject = new ConnectionClass();
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Brush _textBrush;

                // Get the item from the collection.
                TabPage _tabPage = tabControl1.TabPages[e.Index];

                // Get the real bounds for the tab rectangle.
                Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

                if (e.State == DrawItemState.Selected)
                {

                    // Draw a different background color, and don't paint a focus rectangle.
                    _textBrush = new SolidBrush(Color.Red);
                    g.FillRectangle(Brushes.Gray, e.Bounds);
                }
                else
                {
                    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                    e.DrawBackground();
                }

                // Use our own font.
                Font _tabFont = new Font("Arial", (float)24.0, FontStyle.Bold, GraphicsUnit.Pixel);

                // Draw string. Center the text.
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;
                g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ عام من برجاء الاغلاق و المحاولة مره اخرى");
                Logger.WriteLog("[" + DateTime.Now + "] " + ex.Message + ".");
            }
        }

        private void addNewClientBtn_SalesTab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = this.tabControl1.TabPages["AddClientTab"];
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    sellOp = new SellingOperation();
                    sellOp.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 2)
                {
                    addPro = new AddProduct();
                    addPro.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 3)
                {
                    clientPaymentManger = new ClientPaymentManger();
                    clientPaymentManger.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 4)
                {
                    addClient = new AddClient();
                    addClient.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 5)
                {
                    shortageForm = new ProductsShortageReport();
                    shortageForm.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 6)
                {
                    gardForm = new GardReport();
                    gardForm.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 8)
                {
                    configForm = new ConfigForm();
                    configForm.ShowDialog();
                }
                if (tabControl1.SelectedIndex == 7)
                {
                    partnershipFram = new PartnershipManagement();
                    partnershipFram.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ عام من برجاء الاغلاق و المحاولة مره اخرى");
                Logger.WriteLog("[" + DateTime.Now + "] " + ex.Message + ".");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FunctionsClass func = new FunctionsClass();
        }
    }
}
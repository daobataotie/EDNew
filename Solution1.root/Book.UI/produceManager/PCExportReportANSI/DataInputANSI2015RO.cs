﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.PCExportReportANSI
{
    public partial class DataInputANSI2015RO : DevExpress.XtraReports.UI.XtraReport
    {
        public DataInputANSI2015RO()
        {
            InitializeComponent();
        }

        public DataInputANSI2015RO(Model.PCDataInput pcDataInput, Model.PCExportReportANSI pcExportReportANSI, int tag)
            : this()
        {
            if (pcDataInput == null)
                return;

            this.TCTSData.Text = pcDataInput.PCDataInputDate.HasValue ? pcDataInput.PCDataInputDate.Value.ToString("yyyy-MM-dd") : "";
            this.TCTSQuantity.Text = pcDataInput.PCPerspectiveList.Count.ToString();
            this.TCTSEmployee.Text = pcDataInput.Employee3 == null ? "" : pcDataInput.Employee3.ToString();

            string customer = string.Empty;
            if (pcExportReportANSI != null)
            {
                this.xrSubreportANSI.ReportSource = new ANSI2015RO(pcExportReportANSI, tag);
                customer = pcExportReportANSI.Customer.CustomerName;
            }
            if (string.IsNullOrEmpty(customer))
                customer = pcDataInput.CustomerShortName;
            this.xrSubreportProductTest.ReportSource = new ProductTestRO(pcDataInput, customer);

            if (pcDataInput.PCOpticalMachineList != null && pcDataInput.PCOpticalMachineList.Count != 0)
                this.xrSubreportPCOpticalMachine.ReportSource = new PCOpticalMachineRO(pcDataInput.PCOpticalMachineList, pcDataInput);

            if (pcDataInput.PCHazeList != null && pcDataInput.PCHazeList.Count != 0)
                this.xrSubreportPCHaze.ReportSource = new PCHazeRO(pcDataInput.PCHazeList, pcDataInput);

            if (pcDataInput.PCDefinitionList != null && pcDataInput.PCDefinitionList.Count != 0)
                this.subReport_PCDefinition.ReportSource = new PCDefinitionRO(pcDataInput.PCDefinitionList);
        }

        private void DataInputANSIRO_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //RO ro = this.xrSubreportANSI.ReportSource as RO;
            //ro.ANSI = pcExportReportANSI;
        }

    }
}

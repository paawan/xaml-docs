using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
	}

    #region radgridview-backward-compatibility_0
    GridViewColumn ageColumn = this.radGridView.Columns["Age"];
    ColumnFilterDescriptor ageColumnFilter = new ColumnFilterDescriptor(ageColumn);
    // ...
    ageColumnFilter.DistinctFilter.DistinctValues.Add(5);
    ageColumnFilter.FieldFilter.Filter1.Operator = FilterOperator.IsLessThan;
    ageColumnFilter.FieldFilter.Filter1.Value = 10;
    // ...
    this.radGridView.FilterDescriptors.Add(ageColumnFilter);
    #endregion

    #region radgridview-backward-compatibility_2
    GridViewColumn ageColumn = this.radGridView.Columns["Age"];
    // Getting it from the property will create it and associate it with its column automatically.
    IColumnFilterDescriptor ageColumnFilter = ageColumn.ColumnFilterDescriptor;
    ageColumnFilter.SuspendNotifications();
    // ...
    ageColumnFilter.DistinctFilter.AddDistinctValue(5);
    ageColumnFilter.FieldFilter.Filter1.Operator = FilterOperator.IsLessThan;
    ageColumnFilter.FieldFilter.Filter1.Value = 10;
    // ...
    // There is no need to manually add the column filter to this.radGridView.FilterDescriptors
    // When the column filter is activated/deactivated it is automatically added/removed to this collection.
    ageColumnFilter.ResumeNotifications();
    #endregion

    #region radgridview-backward-compatibility_4
    this.radGridView.FilterDescriptors.Remove(columnFilterDescriptor);
    #endregion

    #region radgridview-backward-compatibility_6
    // Calling ClearFilter will automatically remove filter descriptor from the grid.
    myColumn.ClearFilters();
    #endregion

    #region radgridview-backward-compatibility_8
    this.radGridView.FilterDescriptors.Clear();
    #endregion

    #region radgridview-backward-compatibility_10
    this.radGridView.FilterDescriptors.SuspendNotifications();
    foreach (var column in this.radGridView.Columns)
    {
	    column.ClearFilters();
    }
    this.radGridView.FilterDescriptors.ResumeNotifications();
    #endregion

    #region radgridview-backward-compatibility_12
    public MainWindow()
    {
        InitializeComponent();
        this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
    }
    #endregion
    #region radgridview-backward-compatibility_14
    public MainPage()
    {
        InitializeComponent();
        Dispatcher.BeginInvoke(new Action(() => this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name)));
    }
    #endregion

}


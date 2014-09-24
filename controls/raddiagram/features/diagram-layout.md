---
title: Layout
page_title: Layout
description: Layout
slug: raddiagram-features-diagram-layout
tags: layout
published: True
position: 10
---

# Layout



__Layout__ in the __RadDiagram__ refers to the way the __Shapes__ are arranged on the diagramming surface. __RadDiagram__ provides a dozen of Layout algorithms which can be easily customized.
	  

>Please note that the examples in this tutorial are showcasing Telerik Windows8 theme. In the
		  {% if site.site_name == 'Silverlight' %}[Setting a Theme](http://www.telerik.com/help/silverlight/common-styling-apperance-setting-theme.html#Setting_Application-Wide_Built-In_Theme_in_the_Code-Behind){% endif %}{% if site.site_name == 'WPF' %}[Setting a Theme](http://www.telerik.com/help/wpf/common-styling-apperance-setting-theme-wpf.html#Setting_Application-Wide_Built-In_Theme_in_the_Code-Behind){% endif %}
		  article you can find more information on how to set an application-wide theme.
		

## Sugiyama Layout

The __Sugiyama__ is a __layered__ layout type which organizes a diagram in layers and attempts to minimize the amount of crossings between the connections and the layers.
		

Sugiyama is the default layout algorithm in __RadDiagram__. Using it is straightforward - just invoke the __RadDiagram.Layout()__ method or use the __Layout__ DiagramCommand:
		

* use the __RadDiagram Layout()__ method:
			  

	
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <StackPanel HorizontalAlignment="Center" Orientation="Horizontal">
            <telerik:RadButton Margin="5,0"
                               Click="Layout"
                               Content="Layout" />
        </StackPanel>
        <telerik:RadDiagram x:Name="diagram"
                            Grid.Row="1"
                            Margin="5" />
    </Grid>			  
			  



	
private void Layout(object sender, RoutedEventArgs e)
{
    diagram.Layout();
}			  
			  



	
Private Sub Layout(sender As Object, e As RoutedEventArgs)
	diagram.Layout()
End Sub			  
			  



* use the __DiagramCommands Layout__ command:
			  

	
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <StackPanel HorizontalAlignment="Center" Orientation="Horizontal">
            <telerik:RadButton Margin="5,0"
                               Command="telerik:DiagramCommands.Layout"
                               CommandTarget="{Binding ElementName=diagram}"
                               Content="LayoutCommand" />
        </StackPanel>
        <telerik:RadDiagram x:Name="diagram"
                            Grid.Row="1"
                            Margin="5" />
    </Grid>		  
			  



The __Layout()__ method provides two optional parameters - the type of the Layout (Sugiyama or Tree) and the corresponding layout settings (SugiyamaSettings or TreeLayoutSettings):

{{region raddiagram-features-layout-0}}
	private void RadButton_Click(object sender, RoutedEventArgs e)
	{
		SugiyamaSettings settings = new SugiyamaSettings()
		{
			HorizontalDistance = 50,
			VerticalDistance = 20,
			Orientation =  Telerik.Windows.Diagrams.Core.Orientation.Horizontal,
			TotalMargin = new Size(20,20),
			ShapeMargin = new Size(10,10),	
		};
		this.diagram.Layout(LayoutType.Sugiyama, settings);
	}
	{{endregion}}



{{region raddiagram-features-layout-0}}
	Private Sub RadButton_Click(sender As Object, e As RoutedEventArgs)
		Dim settings As New SugiyamaSettings() With { 
			 .HorizontalDistance = 50, 
			 .VerticalDistance = 20, 
			 .Orientation = Telerik.Windows.Diagrams.Core.Orientation.Horizontal, 
			 .TotalMargin = New Size(20, 20), 
			 .ShapeMargin = New Size(10, 10) 
		}
		Me.diagram.Layout(LayoutType.Sugiyama, settings)
	End Sub
	{{endregion}}



Below you can see how random shapes and connections are being arranged with the given layout configuration:![raddiagram-features-layout-Sugiyama](images/raddiagram-features-layout-Sugiyama.png)

## Tree Layout

The Tree Layout Type organizes a diagram in a tree-like fashion. There are eight additional subtypes of Tree Layout:
		

* __Tree-down:__ - a standard hierarchical layout with node spreading from the root downwards.
			  

* __Tree-up:__ - a standard hierarchical layout with node spreading from the root upwards.
			  

* __Tree-left:__ - a standard hierarchical layout with node spreading from the root to the left.
			  

* __Tree-right:__ - a standard hierarchical layout with node spreading from the root to the right.
			  

* __Mindmap-vertical:__ - a classic mindmapping pattern with wings stacked vertically.
			  

* __Mindmap-horizontal:__ - a classic mindmapping pattern with wings stacked horizontally.
			  

* __Tip-over tree:__ - much like the tree-down layout but nodes are organized as standard trees from the first-child level on to reduce the spreading and usage of space.
			  

* __Radial:__ - siblings are organized on circular level emanating from the center/root outwards.
			  

Below you can see a snapshots of random diagrams laid out with Tree Layout types:
<table><tr><td>

<b>Tree-down:</b></td><td>![raddiagram-features-layout-tree-down](images/raddiagram-features-layout-tree-down.png)</td></tr><tr><td>

<b>Tree-up:</b></td><td>![raddiagram-features-layout-tree-up](images/raddiagram-features-layout-tree-up.png)</td></tr><tr><td>

<b>Tree-left:</b></td><td>![raddiagram-features-layout-tree-left](images/raddiagram-features-layout-tree-left.png)</td></tr><tr><td>

<b>Tree-right:</b></td><td>![raddiagram-features-layout-tree-right](images/raddiagram-features-layout-tree-right.png)</td></tr><tr><td>

<b>Mindmap-vertical:</b></td><td>![raddiagram-features-layout-mindmap-vertical](images/raddiagram-features-layout-mindmap-vertical.png)</td></tr><tr><td>

<b>Mindmap-horizontal:</b></td><td>![raddiagram-features-layout-mindmap-horizontal](images/raddiagram-features-layout-mindmap-horizontal.png)</td></tr><tr><td>

<b>Tip-over tree:</b></td><td>![raddiagram-features-layout-tipovertree](images/raddiagram-features-layout-tipovertree.png)</td></tr><tr><td>

<b>Radial:</b></td><td>![raddiagram-features-layout-radial](images/raddiagram-features-layout-radial.png)</td></tr></table>

Here is how this could be achieved in code behind.	

{{region raddiagram-features-layout-1}}
	private void RadButton_Click(object sender, RoutedEventArgs e)
	{
		TreeLayoutSettings settings = new TreeLayoutSettings()
		{
			TreeLayoutType = TreeLayoutType.TreeDown,
			VerticalDistance = 20,				
		};
		settings.Roots.Add(this.diagram.Shapes[0]);
		this.diagram.Layout(LayoutType.Tree, settings);
	}
	{{endregion}}



{{region raddiagram-features-layout-1}}
	Private Sub RadButton_Click(sender As Object, e As RoutedEventArgs)
		Dim settings As New TreeLayoutSettings() With { 
			 .TreeLayoutType = TreeLayoutType.TreeDown, 
			 .VerticalDistance = 20 
		}
		settings.Roots.Add(Me.diagram.Shapes(0))
		Me.diagram.Layout(LayoutType.Tree, settings)
	End Sub
	{{endregion}}



## Layout Settings

__Component Layout and Settings__

One important aspect with respect to diagram layout is the concept of graph component. If a diagram consists of separate sub-diagrams with no connection between them they are called components of a diagram.
		

When applying a diagram layout to a diagram consisting of one or more components a layout is applied to each components and thereafter the components are organized in a grid.![raddiagram-features-layout-gridcomponent](images/raddiagram-features-layout-gridcomponent.png)

The splitting in components is automatic and the grid layout of the components applied to both the tree layout and the layered layout types.

The grid layout has the following settings which are both present as part of the __SugiyamaLayoutSettings__ and the __TreeLayoutSettings__:
		

* __ComponentMargin:__ the margin each component has in the grid layout.
			  

* __ComponentsGridWidth:__the total width of the grid wherein the components are laid out.
			  

* __TotalMargin:__ the margin around the (virtual) grid.
			  

__Sugiyama specific settings__

* __VerticalDistance__: the vertical spacing between the layers.
			  

* __HorizontalDistance__: the horizontal spacing between the layers.
			  

__Tree layout settings__

* __TreeLayoutType__: the subtype of the tree layout: TreeDown, TreeUp, TreeLeft, TreeRight, TipOverTree, RadialTree, MindmapVertical, MindmapHorizontal. See the examples above for more details.
			  

* __VerticalSeparation__: (applies only to the four standard tree types  and the TipOverTree) the vertical separation between tree level.
			  

* __HorizontalSeparation__: (applies only to the four standard tree types and the TipOverTree) the horizontal separation between siblings on the same level.
			  

* __UnderneathVerticalTopOffset__: (applies only to the TipOverTree type) the offset from the parent of the first child.
			  

* __UnderneathHorizontalOffset__: (applies only to the TipOverTree type) the horizontal offset between parent and child.
			  

* __UnderneathVerticalSeparation__: (applies only to the TipOverTree type) the vertical offset between subsequent children.
			  

* __Roots__: The Roots of the components. Use this collection of IShapes to set the roots of the trees in your diagram before layout.
			  

* __TipOverTreeStartLevel__: this property applies only to the TipOverTree type and gets or sets the level from which a tip-over tree arrangement should be applied. A value of zero means that the children underneath the root will have a tip-over arrangement, a value of one means the grand-children of the root will have this applied and so on.
			  

* __RadialSeparation__: (applies only to the RadialTree type) the radial distance between levels.
			  

* __RadialFirstLevelSeparation__: (applies only to the RadialTree type) the radial distance between the root and the first level.
			  

* __KeepComponentsInOneRadialLayout__: (applies only to the RadialTree type) if set to true the default behavior of organizing components into a grid will be overridden and the components will be considered as part of one radial tree. To this end a virtual root will be added which unifies the different components. See the example below.
			  

* __StartRadialAngle__: The radial layout allows you to use a sector instead of the full 360 degrees. This start angle defines the beginning of this sector.
			  

* __EndRadialAngle__: This end angle defines the end of the sector used (the part of 360 degrees used).
			  

* __AnimateTransitions__: This property allows you to animate the dynamic changes of a Diagram layout. When you set the value of the property to __True__ and dynamically change the layout settings of a Diagramming solution, an animation will be applied during the transition of the settings.
			  

Below you can see the explanation of the main __TreeLayout Settings__ for the base 4 types (Up, Down, Left, Right) + TipOverTree.
		![raddiagram-features-layout-settings](images/raddiagram-features-layout-settings.png)

Below you can see how the __KeepComponentsInOneRadialLayout__ actually works when you have more than one component:
		![raddiagram-features-layout-radiallayout](images/raddiagram-features-layout-radiallayout.png)

# See Also

 * [Populating with Data]({%slug raddiagram-data-overview%})

 * [Routing]({%slug raddiagram-features-routing%})
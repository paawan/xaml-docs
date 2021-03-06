---
title: Grouping
page_title: Grouping
description: Grouping
slug: radtilelist-grouping
tags: grouping
published: True
position: 0
---

# Grouping



__RadTileList__ can arrange tiles into separate sections depending on each user's requirements. Those groups can be modified through its __GroupTemplate__ property as follows: 

#### __XAML__

{{region radtilelist-grouping-0}}

		<Grid.Resources>
			<DataTemplate x:Key="GroupTemplate">
				<TextBlock Text="{Binding}" FontWeight="Bold"/>
			</DataTemplate>
		</Grid.Resources>
	
		<telerik:RadTileList GroupTemplate="{StaticResource GroupTemplate}">
	
{{endregion}}



You can get all generated sections through TileList's __Groups__ property of type __ObservableCollection &lt;TileGroup&gt;__.

## Manually generated tiles

When working with manually generated tiles, you need to declare each group separately and place the tiles in its Items collection. Each one can have custom __Header__ and __DisplayIndex__.

The definition of __RadTileList__ in such scenario will look like:  {% if site.site_name == 'Silverlight' %}

#### __XAML__

{{region radtilelist-grouping-1}}

	<telerik:RadTileList x:Name="RadTileList"
                     GroupTemplate="{StaticResource GroupTemplate}">
		<telerik:RadTileList.Groups>
			<telerik:TileGroup Header="Europe" DisplayIndex="0">
				<telerik:TileGroup.Items>
					<telerik:Tile Background="#FF006AC1" Content="Italy" />
					<telerik:Tile Background="#FF006AC1" Content="Germany" />
				</telerik:TileGroup.Items>
			</telerik:TileGroup>
			<telerik:TileGroup Header="Asia" DisplayIndex="1">
				<telerik:TileGroup.Items>
					<telerik:Tile Background="#FF006AC1" Content="China" />
					<telerik:Tile Background="#FF006AC1" Content="India" />
				</telerik:TileGroup.Items>
			</telerik:TileGroup>
		</telerik:RadTileList.Groups>
	</telerik:RadTileList>
{{endregion}}

{% endif %}{% if site.site_name == 'WPF' %}

#### __XAML__

{{region radtilelist-grouping-2}}

	<telerik:RadTileList x:Name="RadTileList"
                     GroupTemplate="{StaticResource GroupTemplate}">
		<telerik:RadTileList.Groups>
			<telerik:TileGroup Header="Europe" DisplayIndex="0">
				<telerik:TileGroup.Items>
					<telerik:Tile Background="#FFA300AB" Content="Italy" />
					<telerik:Tile Background="#FFA300AB" Content="Germany" />
				</telerik:TileGroup.Items>
			</telerik:TileGroup>
			<telerik:TileGroup Header="Asia" DisplayIndex="1">
				<telerik:TileGroup.Items>
					<telerik:Tile Background="#FFA300AB" Content="China" />
					<telerik:Tile Background="#FFA300AB" Content="India" />
				</telerik:TileGroup.Items>
			</telerik:TileGroup>
		</telerik:RadTileList.Groups>
	</telerik:RadTileList>
{{endregion}}

{% endif %}

And the result will be:

{% if site.site_name == 'Silverlight' %}

![Grouping SL](images/Grouping_SL.PNG){% endif %}{% if site.site_name == 'WPF' %}

![Grouping WPF](images/Grouping_WPF.PNG){% endif %}

## Autogenerated tiles

__RadTileList__ gives the user an option to bind it directly to particular data source and display each item in a tile. In this case if you want to group them by a particular property, you can simply set __GroupMember__ property of __TileList__ and have all groups generated for you automatically.

For example, if we use the source available in [Autogenerated tiles]({%slug radtilelist-autogenerated-tiles%}) article, we can define __RadTileList__ as:
        

#### __XAML__

{{region radtilelist-grouping-3}}

	<telerik:RadTileList x:Name="RadTileList" 
	                     GroupMember="Occupation"
	                     ItemTemplate="{StaticResource ItemTemplate}"/>
{{endregion}}



{% if site.site_name == 'Silverlight' %}

![Grouping Autogenerated Tiles SL](images/Grouping_AutogeneratedTiles_SL.PNG){% endif %}{% if site.site_name == 'WPF' %}

![Grouping Autogenerated Tiles WPF](images/Grouping_AutogeneratedTiles_WPF.PNG){% endif %}

## CollectionViewSource with GroupDescriptions

__RadTileList__ accepts __CollectionViewSource__ as data source, it will evaluate its __GroupDescriptions__ and generate corresponding groups based on that. 

For example:
        

#### __XAML__

{{region radtilelist-grouping-4}}

	<Grid.Resources>
		<CollectionViewSource x:Key="GroupedItems" Source="{Binding Employees}" >
			<CollectionViewSource.GroupDescriptions>
				<PropertyGroupDescription PropertyName="Occupation" />
			</CollectionViewSource.GroupDescriptions>
		</CollectionViewSource>
	</Grid.Resources>
	<telerik:RadTileList x:Name="RadTileList" 
                     ItemsSource="{Binding Source={StaticResource GroupedItems}}"
                     ItemTemplate="{StaticResource ItemTemplate}"/>
	
{{endregion}}



The result will be again:

{% if site.site_name == 'Silverlight' %}

![Grouping Autogenerated Tiles SL](images/Grouping_AutogeneratedTiles_SL.PNG){% endif %}{% if site.site_name == 'WPF' %}

![Grouping Autogenerated Tiles WPF](images/Grouping_AutogeneratedTiles_WPF.PNG){% endif %}

>note __RadTileList__ supports grouping at one level only. If you want to modify the group, you need to clear the __GroupDescriptions__ collection of the source and add new __PropertyGroupDescription__ after that. 
      

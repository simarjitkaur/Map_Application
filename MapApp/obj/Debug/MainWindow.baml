   M S B A M L   `   `   `  ����A  =MapApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MapAppMapApp  5   	       MapApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MapApp     5   	   [ WEsri.ArcGISRuntime, Version=100.7.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013  5   	     � Title$  Population Map��5	   	   $	��500��6    $	��800��6-   .��5
      � .+�5   
   ,  &Esri.ArcGISRuntime.UI.Controls.MapView  -   5          Name$ 	MyMapView��5      $��Stretch=�6*   $��5,0,0,-0.333q�6q   $��Stretch=�6�      WrapAroundMode$ EnabledWhenSupported=�6�   �� 5   
    �� Orientation$ Vertical=�6    J� Opacity$ .5Q�6-   $
��Left=�6:   
���   �.+�5      �� $��World Population��6   $��26(�60   $
��Bold"�6>   
�������6P   �� 5      $��Select a basemap��6   $
��Bold"�60   $��14(�6C   
�������6Q   �� 5      -   5         ��Name$ BasemapCombobox��5      $��5,5,0,0q�60   6w   �� 5      $��Select a location��6   $
��Bold"�60   $��14(�6B   
�������6P   �� 5      -   5         ��Name$ GoTimeListbox��5      $��5,5,0,0q�6-   6r   �� 5      -   5         ��Name$ CountryTitleLabel��5      $��Country��6/   $��14(�6B   $��30��6P   $
��Bold"�6\   
�������6n   �� 5      -   5        $ CountryValueLabel��5      $��12(�60   $��30��6>   
�������6J   �� 5      -   5        $ RegionTitleLabel��5      $��Region��6.   $��14(�6?   $
��Bold"�6M   $
��Left=�6_   
�������6z   �� 5      -   5        $ RegionValueLabel��5      $��12(�6.   $
��Left=�6<   $��30��6W   
�������6c   �� 5      -   5        $ PopulationTitleLabel��5      $��2015 Population��62   $��14(�6L   $
��Bold"�6Z   $
��Left=�6l   
�������6�   �� 5      -	   5        $ PopulationValueLabel��5      $��12(�62   $
��Left=�6A   $��30��6\   
�������6h   5      5      5      
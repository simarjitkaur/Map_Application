using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MapApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFeatureLayer();
            LoadBasemaps();
            LoadLocation();
            
        }

        /// <summary>
        /// Loading feature layer
        /// </summary>
        private void LoadFeatureLayer()
        {
            try
            {
                MyMapView.Map = new Esri.ArcGISRuntime.Mapping.Map();
                MyMapView.Map.Basemap = Basemap.CreateStreetsNightVector();

                Esri.ArcGISRuntime.Mapping.Map MyMap = new Esri.ArcGISRuntime.Mapping.Map(Esri.ArcGISRuntime.Mapping.Basemap.CreateTerrainWithLabelsVector());

                Uri coronaUri = new Uri("https://services1.arcgis.com/4yjifSiIG17X0gW4/arcgis/rest/services/World_Population_Data_2015_from_UN/FeatureServer/0");
                FeatureLayer flayer = new FeatureLayer(coronaUri);

                MyMapView.Map.OperationalLayers.Add(flayer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Load basemap options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        
        private void LoadBasemaps()
        {
            BasemapCombobox.SelectedIndex = 3;
            BasemapCombobox.Items.Add("World Street Map");
            BasemapCombobox.Items.Add("World Topographic Map");
            BasemapCombobox.Items.Add("World Imagery");
            BasemapCombobox.Items.Add("Night Streets Basemap");
            BasemapCombobox.Items.Add("Open Street Map");
            
        }
        /// <summary>
        /// Load Location for map
        /// </summary>
        private void LoadLocation()
        {
            GoTimeListbox.Items.Add("Canada");
            GoTimeListbox.Items.Add("Thailand");
            GoTimeListbox.Items.Add("Iceland");
            GoTimeListbox.Items.Add("India");
            GoTimeListbox.Items.Add("Rock of Gibraltar");
        }
        /// <summary>
        /// Change map according to option select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>

        private async void MyMapView_GeoViewTapped(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            try
            {
                IReadOnlyCollection<IdentifyLayerResult> idLayerResults = await MyMapView.IdentifyLayersAsync(e.Position, 10, false, 5);
                if (idLayerResults.Count > 0)
                {
                    IdentifyLayerResult idResults = idLayerResults.FirstOrDefault();

                    FeatureLayer idLayer = idResults.LayerContent as FeatureLayer;

                    idLayer.ClearSelection();

                    foreach (GeoElement idElement in idResults.GeoElements)
                    {
                        Feature idFeature = idElement as Feature;

                        idLayer.SelectFeature(idFeature);

                        IDictionary<string, object> atteributes = idFeature.Attributes;

                        string attKey = string.Empty;
                        object attVal = new object();

                        foreach (var attribute in atteributes)
                        {
                            attKey = attribute.Key;
                            attVal = attribute.Value;

                            if (string.Compare(attKey, "Country") == 0)
                            {
                                CountryValueLabel.Content = attVal;
                            }
                            if (string.Compare(attKey, "Major_Region") == 0)
                            {
                                RegionValueLabel.Content = attVal;
                            }
                            if (string.Compare(attKey, "pop2015") == 0)
                            {
                                string pop = attVal + "000";
                                int.TryParse(pop, out int result);
                                string formatString = String.Format("{0:n0}", result);
                                PopulationValueLabel.Content = formatString;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BasemapCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int index = BasemapCombobox.SelectedIndex;
                switch (index)
                {
                    case 0:
                        MyMapView.Map.Basemap = Basemap.CreateStreetsVector();
                        break;
                    case 1:
                        MyMapView.Map.Basemap = Basemap.CreateTopographicVector();
                        break;
                    case 2:
                        MyMapView.Map.Basemap = Basemap.CreateImageryWithLabelsVector();
                        break;
                    case 3:
                        MyMapView.Map.Basemap = Basemap.CreateStreetsNightVector();
                        break;
                    default:
                        MyMapView.Map.Basemap = Basemap.CreateOpenStreetMap();
                        break;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private async void GoTimeListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                double x = 1.0;
                double y = 1.0;

                int index = GoTimeListbox.SelectedIndex;

                switch (index)
                {
                    case 0:  //Canada
                        x = -113.7129785;
                        y = 54.6985831;
                        break;
                    case 1: //Thailand
                        x = 96.9946297;
                        y = 13.0003408;
                        break;
                    case 2:  //Iceland
                        x = -23.7277777;
                        y = 64.7967723;
                        break;
                    case 3: //India
                        x = 73.7293199;
                        y = 20.7505273;
                        break;
                    case 4: //Rock of Gibraltar
                        x = -5.3504789;
                        y = 36.1440926;
                        break;
                }
                MapPoint point = new MapPoint(x, y, SpatialReference.Create(4326));
                await MyMapView.SetViewpointCenterAsync(point);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
    }
}

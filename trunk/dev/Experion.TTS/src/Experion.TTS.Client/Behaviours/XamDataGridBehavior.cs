namespace Experion.TTS.Client.Behaviours
{
    using Infragistics.Windows.DataPresenter;
    using Infragistics.Windows.DataPresenter.Events;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Interactivity;

    namespace Behaviors
    {
        /// <summary>
        /// XamDataGridBehavior.
        /// </summary>
        public class XamDataGridBehavior : Behavior<XamDataGrid>
        {
            public static readonly DependencyProperty SelectedItemsProperty =
                DependencyProperty.Register(
                    "SelectedItems",
                    typeof(IEnumerable),
                    typeof(XamDataGridBehavior),
                    new FrameworkPropertyMetadata()
                    {
                        BindsTwoWayByDefault = true,
                        DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    });

            public IEnumerable SelectedItems
            {
                get
                {
                    return GetValue(SelectedItemsProperty) as IEnumerable;
                }
                set
                {
                    SetValue(SelectedItemsProperty, value);
                }
            }

            public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
                "SelectedItem",
                typeof(object),
                typeof(XamDataGridBehavior),
                new FrameworkPropertyMetadata()
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                });

            public Object SelectedItem
            {
                get
                {
                    return GetValue(SelectedItemProperty);
                }
                set
                {
                    SetValue(SelectedItemProperty, value);
                }
            }

            protected override void OnAttached()
            {
                base.OnAttached();

                AssociatedObject.SelectedItemsChanged += OnSelectedItemsChanged;

            }

            /// <summary>
            /// Called when [selected items changed].
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="SelectedItemsChangedEventArgs"/> instance containing the event data.</param>
            private void OnSelectedItemsChanged(object sender, SelectedItemsChangedEventArgs e)
            {

                var dataGrid = (sender as XamDataGrid);


                SelectedItems = (from item in dataGrid.SelectedItems select (item as DataRecord).DataItem).ToList();


                if (dataGrid.SelectedItems.DataPresenter.ActiveDataItem != null)
                {

                    SelectedItem = dataGrid.SelectedItems.DataPresenter.ActiveDataItem;

                }

            }



            protected override void OnDetaching()
            {
                AssociatedObject.SelectedItemsChanged -= OnSelectedItemsChanged;

                base.OnDetaching();
            }
        }
    }


}

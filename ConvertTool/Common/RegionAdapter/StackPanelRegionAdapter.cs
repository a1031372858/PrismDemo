using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace Common.RegionAdapter
{
    public class StackPanelRegionAdapter:RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement item in e.NewItems)
                        {
                            regionTarget.Children.Add(item);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (FrameworkElement item in e.NewItems)
                        {
                            regionTarget.Children.Remove(item);
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        break;
                    case NotifyCollectionChangedAction.Move:
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
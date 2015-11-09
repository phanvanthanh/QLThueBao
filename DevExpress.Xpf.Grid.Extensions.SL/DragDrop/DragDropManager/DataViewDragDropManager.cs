#region Copyright (c) 2000-2012 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{                                                                   }
{                                                                   }
{       Copyright (c) 2000-2012 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2000-2012 Developer Express Inc.

using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System.Windows.Media;
using System.Collections;
using System;
using System.Windows.Threading;
using DevExpress.Xpf.Utils;
using System.ComponentModel;
#if SL
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Data.Browsing;
using PropertyMetadata = DevExpress.Xpf.Core.WPFCompatibility.SLPropertyMetadata;
#endif
namespace DevExpress.Xpf.Grid {
	public abstract class DataViewDragDropManager : DragDropManagerBase {
		public static readonly DependencyProperty AllowScrollingProperty = DependencyPropertyManager.Register("AllowScrolling",
			typeof(bool), typeof(DataViewDragDropManager), new PropertyMetadata(true));
		public static readonly DependencyProperty AllowAutoExpandProperty = DependencyPropertyManager.Register("AllowAutoExpand",
			typeof(bool), typeof(DataViewDragDropManager), new PropertyMetadata(true));
		public static readonly DependencyProperty AutoExpandDelayProperty = DependencyPropertyManager.Register("AutoExpandDelay",
			typeof(int), typeof(DataViewDragDropManager), 
			new PropertyMetadata(1000, (s, e) => {
				((DataViewDragDropManager)s).AutoExpandTimer.Interval = TimeSpan.FromMilliseconds((int)e.NewValue);
			}));
		public DataViewDragDropManager() {
			ScrollSpeed = 1;
			ScrollSpacing = 10;
		}
		protected internal override IList ItemsSource {
			get {
				IListSource source = DataControl.ItemsSource as IListSource;
				if(source != null)
					return source.GetList();
				return DataControl.ItemsSource as IList;
			}
		}
		protected internal DataControlBase DataControl { get { return AssociatedObject as DataControlBase; } }
		public virtual DataViewBase View { get { return null; } }
		protected internal override void OnDrop(DragDropManagerBase sourceManager, UIElement source, Point pt) { }
		protected DispatcherTimer scrollTimer;
		protected DispatcherTimer AutoExpandTimer;
		public bool AllowScrolling {
			get { return (bool)GetValue(AllowScrollingProperty); }
			set { SetValue(AllowScrollingProperty, value); }
		}
		public bool AllowAutoExpand {
			get { return (bool)GetValue(AllowAutoExpandProperty); }
			set { SetValue(AllowAutoExpandProperty, value); }
		}
		public int AutoExpandDelay {
			get { return (int)GetValue(AutoExpandDelayProperty); }
			set { SetValue(AutoExpandDelayProperty, value); }
		}
		protected internal Point LastPosition { get; set; }
		public double ScrollSpacing { get; set; }
		public double ScrollSpeed { get; set; }
		public void InvalidateScrolling(Point point) {
			Rect rect = LayoutHelper.GetRelativeElementRect(View.ScrollContentPresenter, DataControl);
			double position = point.Y - rect.Top;
			if(position > 0 && position < ScrollSpacing) {
				View.ChangeVerticalScrollOffsetBy(-ScrollSpeed);
			}
			if(position > View.ScrollContentPresenter.ActualHeight - ScrollSpacing && position < View.ScrollContentPresenter.ActualHeight) {
				View.ChangeVerticalScrollOffsetBy(ScrollSpeed);
			}
		}
		protected override void OnAttached() {
			base.OnAttached();
			DataControlBase dataCtrl = DataControl;;
			if(dataCtrl != null) {
				DataViewDragDropManager.SetDragDropManager(dataCtrl, this);
				DragDropHelper = new DragDropElementHelper(CreateDragSource(this));
				scrollTimer = new DispatcherTimer();
				scrollTimer.Interval = TimeSpan.FromMilliseconds(100);
				scrollTimer.Tick += new EventHandler(scrollTimer_Tick);
				AutoExpandTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(AutoExpandDelay) };
				AutoExpandTimer.Tick += new EventHandler(AutoExpandTimer_Tick);
				DragManager.SetDropTargetFactory(dataCtrl, new DragDropManagerDropTargetFactory());
			}
		}
		protected virtual ISupportDragDrop CreateDragSource(DataViewDragDropManager dataViewDragDropManager) {
			return null;
		}
		protected override void OnDetaching() {
			base.OnDetaching();
			if(DataControl != null) {
				scrollTimer.Tick -= new EventHandler(scrollTimer_Tick);
				AutoExpandTimer.Tick -= new EventHandler(AutoExpandTimer_Tick);
			}
		}
		void scrollTimer_Tick(object sender, EventArgs e) {
			if(AllowScrolling)
				InvalidateScrollingAndPerformDropToView(dragOverSourceManager, LastPosition);
		}
		void AutoExpandTimer_Tick(object sender, EventArgs e) {
			if(AllowAutoExpand)
				DataControl.Dispatcher.BeginInvoke(new Action(() => PerformAutoExpand()));
		}
		protected virtual void PerformAutoExpand() { }
		protected void InvalidateScrollingAndPerformDropToView(DragDropManagerBase sourceManager, Point point) {
			InvalidateScrolling(point);
			View.UpdateLayout();
			DataControl.Dispatcher.BeginInvoke(new Action(() => PerformDropToView(sourceManager)));
		}
		protected int HoverRowHandle;
		protected internal override void OnDragOver(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			LastPosition = pt;
			scrollTimer.Start();
			UpdateHoverRowHandle(source, pt);
			if(IsExpandable) {
				AutoExpandTimer.Stop();
				AutoExpandTimer.Start();
			} else
				AutoExpandTimer.Stop();
			if(AllowScrolling)
				InvalidateScrollingAndPerformDropToView(sourceManager, pt);
			else
				PerformDropToView(sourceManager);
			base.OnDragOver(sourceManager, source, pt);
		}
		private void UpdateHoverRowHandle(UIElement source, Point pt) {
			HoverRowHandle = GetOverRowHandle(source, pt);
		}
		internal virtual int GetOverRowHandle(UIElement source, Point pt) {
			return GridControl.InvalidRowHandle;
		}
		internal virtual bool IsExpandable { 
			get {
				return false;
			} 
		}
		protected internal GridViewHitInfoBase GetHitInfo(RoutedEventArgs e) {
			return GetHitInfo(e.OriginalSource as DependencyObject);
		}
		protected virtual GridViewHitInfoBase GetHitInfo(DependencyObject element) {
			return null;
		}
		protected virtual void PerformDropToView(DragDropManagerBase sourceManager) { }
		protected internal override void OnDragLeave() {
			StopScrollTimer();
			StopAutoExpandTimer();
			HoverRowHandle = GridControl.InvalidRowHandle;
			base.OnDragLeave();
		}
		private void StopAutoExpandTimer() {
			if(AutoExpandTimer.IsEnabled)
				AutoExpandTimer.Stop();
		}
		void StopScrollTimer() {
			if(scrollTimer.IsEnabled)
				scrollTimer.Stop();
		}
		protected class DragDropHitTestResult : DragDropObjectBase {
			public UIElement Element { get; private set; }
			public DragDropHitTestResult(DragDropManagerBase manager)
				: base(manager) {
			}
			public HitTestResultBehavior CallBack(HitTestResult result) {
				Element = result.VisualHit as UIElement;
				if(Element == null || !UIElementHelper.IsVisibleInTree(Element as FrameworkElement) || !Element.IsHitTestVisible) {
					return HitTestResultBehavior.Continue;
				}
				return HitTestResultBehavior.Stop;
			}
		}
		protected UIElement GetVisibleHitTestElement(Point pt) {
			DragDropHitTestResult result = new DragDropHitTestResult(this);
#if SL
			UIElement root = LayoutHelper.FindRoot(DataControl) as UIElement;
			Point location = LayoutHelper.GetRelativeElementRect(DataControl, root).TopLeft();
			System.Windows.Controls.Primitives.Popup popup = root as System.Windows.Controls.Primitives.Popup;
			if(popup!=null)
				PointHelper.Offset(ref location, popup.HorizontalOffset, popup.VerticalOffset);
			PointHelper.Offset(ref location, pt.X, pt.Y);
			HitTestHelper.HitTest(DataControl, null, new HitTestResultCallback(result.CallBack), new PointHitTestParameters(location), true);
#else
			VisualTreeHelper.HitTest(DataControl, null, new HitTestResultCallback(result.CallBack), new PointHitTestParameters(pt));
#endif
			return result.Element;
		}
		protected FrameworkElement GetRowElement(DependencyObject hitElement) {
			DataViewHitTestVisitorBase visitor = CreateFindRowElementHitTestVisitor(this);
			return GetElementAcceptVisitor(hitElement, visitor);
		}
		protected virtual DataViewHitTestVisitorBase CreateFindRowElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return null;
		}
		protected FrameworkElement GetDataAreaElement(DependencyObject hitElement) {
			DataViewHitTestVisitorBase visitor = CreateFindDataAreaElementHitTestVisitor(this);
			return GetElementAcceptVisitor(hitElement, visitor);
		}
		protected virtual DataViewHitTestVisitorBase CreateFindDataAreaElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return null;
		}
		internal virtual FrameworkElement GetElementAcceptVisitor(DependencyObject hitElement, DataViewHitTestVisitorBase visitor) { 
			return null; 
		}
		protected void SetPropertyValue(object obj, string propertyName, object value) {
			if(propertyName.Contains(".")) {
				DevExpress.Data.Access.ComplexPropertyDescriptor complexDesc = new DevExpress.Data.Access.ComplexPropertyDescriptor(obj, propertyName);
				complexDesc.SetValue(obj, value);
			} else
				TypeDescriptor.GetProperties(obj)[propertyName].SetValue(obj, value);
		}
		protected object GetPropertyValue(object obj, string propertyName) {
			return TypeDescriptor.GetProperties(obj)[propertyName].GetValue(obj);
		}
		protected void SetAddRowsDropInfo(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			sourceManager.SetDropTargetType(DropTargetType.DataArea);
			sourceManager.ShowDropMarker(GetDataAreaElement(hitElement), TableDragIndicatorPosition.None);
		}
		protected void AddRows(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			DataControl.BeginDataUpdate();
			foreach(object row in sourceManager.DraggingRows)
				AddRow(sourceManager, row, insertRowHandle);
			DataControl.EndDataUpdate();
		}
		protected virtual void AddRow(DragDropManagerBase sourceManager, object row, int insertRowHandle) { }
		protected DropTargetType GetDropTargetType(FrameworkElement row) {
			switch(GetDragIndicatorPositionForRowElement(row)) {
				case TableDragIndicatorPosition.Top:
					return DropTargetType.InsertRowsBefore;
				case TableDragIndicatorPosition.Bottom:
					return DropTargetType.InsertRowsAfter;
				case TableDragIndicatorPosition.InRow:
					return DropTargetType.InsertRowsIntoNode;
				default:
					return DropTargetType.None;
			}
		}
		protected bool RestoreSelection {
			get {
				return DataControl.ItemsSource is System.Collections.Specialized.INotifyCollectionChanged || DataControl.ItemsSource is IBindingList;
			}
		}
		protected void SetDropMarkerVisibility(bool visible) {
			if(!visible)
				HideDropMarker();
		}
		protected virtual TableDragIndicatorPosition GetDragIndicatorPositionForRowElement(FrameworkElement rowElement) {
			return TableDragIndicatorPosition.None;
		}
	}
}

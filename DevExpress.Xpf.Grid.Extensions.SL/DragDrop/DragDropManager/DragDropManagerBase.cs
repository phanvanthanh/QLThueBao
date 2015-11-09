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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections;
using System;
using System.Windows.Threading;
using DevExpress.Xpf.Editors;
using System.Windows.Interactivity;
#if !SL
using DevExpress.Xpf.Utils;
#else
using DevExpress.Xpf.Core.WPFCompatibility;
using PropertyMetadata = DevExpress.Xpf.Core.WPFCompatibility.SLPropertyMetadata;
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid {
	public abstract class DragDropManagerBase : Behavior<DependencyObject> {
		static readonly DependencyProperty DragDropManagerProperty = DependencyPropertyManager.RegisterAttached(
			"DropManager",
			typeof(DragDropManagerBase),
			typeof(FrameworkElement),
			new PropertyMetadata(null));
		public static void SetDragDropManager(UIElement element, DragDropManagerBase value) {
			element.SetValue(DragDropManagerProperty, value);
		}
		public static DragDropManagerBase GetDragDropManager(UIElement element) {
			return (DragDropManagerBase)element.GetValue(DragDropManagerProperty);
		}
		public bool AllowDrop {
			get { return (bool)GetValue(AllowDropProperty); }
			set { SetValue(AllowDropProperty, value); }
		}
		public static readonly DependencyProperty AllowDropProperty;
		public static readonly DependencyProperty TemplatesContainerProperty;
		public static readonly DependencyProperty RootElementProperty;
		public static readonly DependencyProperty DragElementTemplateProperty;
		public static readonly DependencyProperty AllowDragProperty;
		static DragDropManagerBase() {
			Type ownerType = typeof(DragDropManagerBase);
			AllowDropProperty =
				DependencyPropertyManager.Register("AllowDrop", typeof(bool), ownerType, new PropertyMetadata(true));
			TemplatesContainerProperty =
				DependencyPropertyManager.Register("TemplatesContainer", typeof(DragDropTemplatesContainer), ownerType, new PropertyMetadata(null));
			RootElementProperty =
				DependencyPropertyManager.Register("RootElement", typeof(FrameworkElement), ownerType, new PropertyMetadata(null));
			DragElementTemplateProperty =
				DependencyPropertyManager.Register("DragElementTemplate", typeof(DataTemplate), ownerType, new UIPropertyMetadata(null));
			AllowDragProperty =
				DependencyPropertyManager.Register("AllowDrag", typeof(bool), ownerType, new UIPropertyMetadata(true));
		}
		public bool AllowDrag {
			get { return (bool)GetValue(AllowDragProperty); }
			set { SetValue(AllowDragProperty, value); }
		}
		public DragDropTemplatesContainer TemplatesContainer {
			get { return (DragDropTemplatesContainer)GetValue(TemplatesContainerProperty); }
			set { SetValue(TemplatesContainerProperty, value); }
		}
		protected internal DragDropElementHelper DragDropHelper { get; set; }
		#region inner classes
		public class DragDropManagerDropTargetFactory : IDropTargetFactory {
			IDropTarget IDropTargetFactory.CreateDropTarget(UIElement dropTargetElement) {
				return new DragDropManagerDropTarget(DragDropManagerBase.GetDragDropManagerBySourceElement(dropTargetElement));
			}
		}
		public class DragDropManagerDropTarget : IDropTarget {
			DragDropManagerBase dragDropManager;
			public DragDropManagerDropTarget(DragDropManagerBase dragDropManager) {
				this.dragDropManager = dragDropManager;
			}
			void IDropTarget.Drop(UIElement source, Point pt) {
				DragDropManagerBase sourceManager = GridDragDropManager.GetDragDropManagerBySourceElement(source);
				if(!dragDropManager.AllowDrop) {
					return;
				}
				dragDropManager.OnDrop(sourceManager, source, pt);
			}
			void IDropTarget.OnDragLeave() {
				dragDropManager.OnDragLeave();
			}
			void IDropTarget.OnDragOver(UIElement source, Point pt) {
				DragDropManagerBase sourceManager = GridDragDropManager.GetDragDropManagerBySourceElement(source);
				dragDropManager.OnDragOver(sourceManager, source, pt);
				if(!dragDropManager.AllowDrop) {
					sourceManager.SetDropTargetType(DropTargetType.None);
					return;
				}
			}
			public int Index { get; set; }
		}
		public abstract class SupportDragDropBase : DragDropObjectBase, ISupportDragDrop {
			protected IList draggingRows;
			protected SupportDragDropBase(DragDropManagerBase dragDropManager)
				: base(dragDropManager) {
			}
			#region ISupportDragDrop Members
			bool ISupportDragDrop.CanStartDrag(object sender, MouseButtonEventArgs e) {
				return dragDropManager.AllowDrag && dragDropManager.CustomAllowDrag(e) && CanStartDragCore(e);
			}
			protected virtual bool CanStartDragCore(MouseButtonEventArgs e) {
				draggingRows = GetDraggingRows(e);
				return draggingRows != null;
			}
			protected abstract FrameworkElement Owner { get; }
			IDragElement ISupportDragDrop.CreateDragElement(Point offset) {
				dragDropManager.ViewInfo.DraggingRows = draggingRows;
				dragDropManager.ViewInfo.FirstDraggingObject = dragDropManager.GetObject(draggingRows[0]);
				DestroyPreviousDragElement();
				return dragDropManager.CreateDragElement(offset, Owner);
			}
			IDropTarget ISupportDragDrop.CreateEmptyDropTarget() { return null; }
			IEnumerable<UIElement> ISupportDragDrop.GetTopLevelDropContainers() {
				return new UIElement[] { dragDropManager.RootElement ?? LayoutHelper.FindRoot(dragDropManager.AssociatedObject) as FrameworkElement };
			}
			bool ISupportDragDrop.IsCompatibleDropTargetFactory(IDropTargetFactory factory, UIElement dropTargetElement) {
				return factory is DragDropManagerDropTargetFactory;
			}
			FrameworkElement ISupportDragDrop.SourceElement { get { return SourceElementCore; } }
			protected abstract FrameworkElement SourceElementCore { get; }
			#endregion
			protected abstract IList GetDraggingRows(MouseButtonEventArgs e);
			void DestroyPreviousDragElement() {
				DragDropElementHelper helper = dragDropManager.DragDropHelper;
				if(helper.DragElement != null)
					helper.DragElement.Destroy();
			}
		}
		#endregion
		internal static DragDropManagerBase GetDragDropManagerBySourceElement(UIElement source) {
			return DragDropManagerBase.GetDragDropManager(source);
		}
		public DataTemplate DragElementTemplate {
			get { return (DataTemplate)GetValue(DragElementTemplateProperty); }
			set { SetValue(DragElementTemplateProperty, value); }
		}
		public FrameworkElement RootElement {
			get { return (FrameworkElement)GetValue(RootElementProperty); }
			set { SetValue(RootElementProperty, value); }
		}
		public DragDropViewInfo ViewInfo { get; private set; }
		protected internal abstract IList ItemsSource { get; }
		protected DragDropManagerBase dragOverSourceManager;
		protected internal IList DraggingRows { get { return ViewInfo.DraggingRows; } }
#if SL
		FloatingContainer adorner;
#else
		AdornerContainer adorner;
		AdornerLayer adornerLayer;
#endif
		protected TableDropMarkerControl MarkerControl { get; set; }
		protected DragDropManagerBase() {
			ViewInfo = new DragDropViewInfo();
#if SL
			adorner = FloatingContainerFactory.Create(FloatingMode.Adorner);
			adorner.ShowContentOnly = true;
#endif
			this.TemplatesContainer = new DragDropTemplatesContainer();
		}
		protected internal void ShowDropMarker(UIElement element, TableDragIndicatorPosition dragIndicatorPosition) {
#if !SL
			HideDropMarker();
#endif
			if(MarkerControl == null)
				MarkerControl = CreateDropMarkerControl();
#if SL
			if(adorner.Owner != element && element != null) {
				FrameworkElement fe = element as FrameworkElement;
				MarkerControl.Height = fe.ActualHeight;
				MarkerControl.Width = fe.ActualWidth;
				adorner.Content = MarkerControl;
				adorner.Owner = fe;
				adorner.UpdateFloatingBounds();
				adorner.IsOpen = true;
			}
#else
			if((adorner == null || adorner.AdornedElement != element) && element != null) {
				adorner = new AdornerContainer(element, MarkerControl);
				adornerLayer = AdornerLayer.GetAdornerLayer(element);
				adornerLayer.Add(adorner);
			}
#endif
			MarkerControl.DragIndicatorPosition = dragIndicatorPosition;
		}
		protected TableDropMarkerControl CreateDropMarkerControl() {
			return new TableDropMarkerControl() { IsHitTestVisible = false };
		}
		protected void HideDropMarker() {
#if !SL
			if(adorner != null) {
				adornerLayer.Remove(adorner);
				adorner = null;
				adornerLayer = null;
				MarkerControl = null;
			}
#endif
		}
		protected internal void ClearDragInfo(DragDropManagerBase sourceManager) {
			sourceManager.HideDropMarkerForce();
			sourceManager.SetDropTargetType(DropTargetType.None);
		}
		protected internal abstract void OnDrop(DragDropManagerBase sourceManager, UIElement source, Point pt);
		protected internal virtual void OnDragLeave() {
			if(dragOverSourceManager != null)
				ClearDragInfo(this);
			if(!ReferenceEquals(this, dragOverSourceManager))
				ClearDragInfo(dragOverSourceManager);
		}
		protected internal virtual void OnDragOver(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			this.dragOverSourceManager = sourceManager;
		}
		void HideDropMarkerForce() {
#if SL
			adorner.Content = null;
			adorner.Owner = null;
			adorner.IsOpen = false;
#else
			HideDropMarker();
#endif
		}
		protected internal void SetDropTargetType(DropTargetType dropTargetType) {
			ViewInfo.DropTargetType = dropTargetType;
		}
		protected virtual IDragElement CreateDragElement(Point offset, FrameworkElement owner) {
			return new DataControlDragElement(this, offset, owner);
		}
		public virtual object GetObject(object obj) {
			return obj;
		}
		protected internal virtual IList GetSource(object row) {
			return ItemsSource;
		}
		protected internal virtual bool CustomAllowDrag(MouseButtonEventArgs e) {
			return true;
		}
		protected internal virtual void SetDragInfoVisibility(bool visible) {
#if !SL
			DataControlDragElement dragElement = DragDropHelper.DragElement as DataControlDragElement;
			if(dragElement != null)
				dragElement.FloatingContainer.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
#endif
		}
	}
	public abstract class DragDropObjectBase {
		protected readonly DragDropManagerBase dragDropManager;
		protected DragDropObjectBase(DragDropManagerBase dragDropManager) {
			this.dragDropManager = dragDropManager;
		}
	}
}

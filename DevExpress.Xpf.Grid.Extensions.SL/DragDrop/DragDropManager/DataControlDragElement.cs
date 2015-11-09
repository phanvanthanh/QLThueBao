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
#if !SL
using DevExpress.Xpf.Utils;
using System.Windows.Interactivity;
#else
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid {
	public class DataControlDragElement : CustomDragElement {
		protected internal FloatingContainer FloatingContainer { get { return container; } }
		Point initialOffset;
		public DataControlDragElement(DragDropManagerBase dragDropManager, Point offset, FrameworkElement owner) {
			initialOffset = offset;
			container.Owner = owner;
			container.Content = new ContentPresenter() {
				Content = dragDropManager.ViewInfo,
				ContentTemplate = dragDropManager.DragElementTemplate 
				?? (dragDropManager.TemplatesContainer !=null ? dragDropManager.TemplatesContainer.DefaultDragElementTemplate : null),
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Top,
			};
			container.ShowContentOnly = true;
			container.FloatSize = new Size(350, 800);
		}
		protected override Point CorrectLocation(Point newLocation) {
			PointHelper.Offset(ref newLocation, initialOffset.X, initialOffset.Y);
			PointHelper.Offset(ref newLocation, 10, 16);
			return newLocation;
		}
	}
}

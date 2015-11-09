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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.ServiceModel.DomainServices.Client;
namespace DevExpress.Xpf.Grid {
	public class LazyLoadingConverter<TContext, TMasterEntity, TDetailEntity> : IValueConverter
		where TContext : DomainContext
		where TMasterEntity : Entity
		where TDetailEntity : Entity {
		readonly TContext domainContext;
		readonly Func<TContext, TMasterEntity, EntityQuery<TDetailEntity>> getQuery;
		public LazyLoadingConverter(TContext domainContext, Func<TContext, TMasterEntity, EntityQuery<TDetailEntity>> getQuery) {
			this.domainContext = domainContext;
			this.getQuery = getQuery;
		}
		object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			TMasterEntity c = (TMasterEntity)value;
			LoadOperation<TDetailEntity> loadOperation = domainContext.Load<TDetailEntity>(getQuery(domainContext, c), new Action<LoadOperation<TDetailEntity>>(OnCompleted), null);
			return loadOperation.Entities;
		}
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			throw new NotImplementedException();
		}
		void OnCompleted(LoadOperation op) {
			if(op.HasError) {
				MessageBox.Show("Connection could not be established." + Environment.NewLine + op.Error.Message, "Connection Error", MessageBoxButton.OK);
				op.MarkErrorAsHandled();
			}
		}
	}
}

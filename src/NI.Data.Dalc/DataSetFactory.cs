#region License
/*
 * Open NIC.NET library (http://nicnet.googlecode.com/)
 * Copyright 2004-2008 NewtonIdeas
 * Distributed under the LGPL licence
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using NI.Common.Providers;

namespace NI.Data.Dalc
{
	/// <summary>
	/// DataSetFactory used for creating DataSet objects with schema.
	/// </summary>
	public class DataSetFactory : IDataSetProvider, IObjectProvider
	{
		SchemaDescriptor[] _Schemas;

		/// <summary>
		/// Get or set schemas list for this factory.
		/// </summary>
		public SchemaDescriptor[] Schemas {
			get { return _Schemas; }
			set { 
				_Schemas = value;
				SourceNameDescrHash = null;
			}
		}

		static IDictionary<string, DataSet> DataSetCache = new Dictionary<string,DataSet>();
		static int MaxDataSetCacheSize = 200;

		IDictionary<string, SchemaDescriptor> SourceNameDescrHash = null;

		public DataSetFactory() {

		}

		protected SchemaDescriptor FindDescriptor(string sourcename) {
			if (SourceNameDescrHash == null) {
				SourceNameDescrHash = new Dictionary<string, SchemaDescriptor>();
				foreach (SchemaDescriptor descr in Schemas)
					foreach (string sn in descr.SourceNames)
						if (!SourceNameDescrHash.ContainsKey(sn))
							SourceNameDescrHash[sn] = descr;
			}
			return SourceNameDescrHash.ContainsKey(sourcename) ? SourceNameDescrHash[sourcename] : null;
		}

		protected DataSet GetDataSetWithSchema(string xmlSchema) {
			if (DataSetCache.Count>MaxDataSetCacheSize) {
				lock (DataSetCache) {
					DataSetCache.Clear();
				}
			}
			DataSet ds;

			if (DataSetCache.TryGetValue(xmlSchema, out ds)) {
				return ds.Clone();
			}
			ds = new DataSet();
			ds.ReadXmlSchema(new StringReader(xmlSchema));
			lock (DataSetCache) {
				DataSetCache[xmlSchema] = ds;
			}
			return ds.Clone();
		}

		public DataSet GetDataSet(object context) {
			if (!(context is string))
				throw new ArgumentException("Source name (string) expected as a context.");
			string sourceName = (string)context;
			SchemaDescriptor schemaDescr = FindDescriptor(sourceName);
			if (schemaDescr == null)
				return null; // unknown sourcename
			DataSet ds = GetDataSetWithSchema(schemaDescr.XmlSchema);
			return ds;
		}

		public object GetObject(object context) {
			return GetDataSet(context);
		}

		public class SchemaDescriptor {
			string[] _SourceNames;
			string _XmlSchema;

			public string[] SourceNames {
				get { return _SourceNames; }
				set { _SourceNames = value; }
			}

			public string XmlSchema {
				get { return _XmlSchema; }
				set { _XmlSchema = value; }
			}

		}
	}
}
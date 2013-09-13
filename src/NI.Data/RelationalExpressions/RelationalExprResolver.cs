#region License
/*
 * Open NIC.NET library (http://nicnet.googlecode.com/)
 * Copyright 2004-2012 NewtonIdeas
 * Copyright 2008-2013 Vitalii Fedorchenko (changes and v.2)
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
using System.Collections;

using NI.Data;

namespace NI.Data.RelationalExpressions
{
	/// <summary>
	/// Relational expression resolver (executed for DALC).
	/// </summary>
	/*public class RelationalExprResolver
	{
		IRelExQueryParser _RelExQueryParser;
		IDalc _Dalc;
		// we have 2 flags because of legacy
		bool _ReturnList = false;
		bool _ReturnCount = false;
		
		/// <summary>
		/// Get or set flag that idicates whether this resolver should return records count as result
		/// </summary>
		public bool ReturnCount {
			get { return _ReturnCount; }
			set { _ReturnCount = value; }
		}
		
		/// <summary>
		/// Get or set flag that indicates whether this resolver should return result as objects list
		/// </summary>
		public bool ReturnList {
			get { return _ReturnList; }
			set { _ReturnList = value; }
		}
		
		/// <summary>
		/// Get or set context relational expressions to query parser
		/// </summary>
		public IRelExQueryParser RelExQueryParser {
			get { return _RelExQueryParser; }
			set { _RelExQueryParser = value; }
		}
		
		/// <summary>
		/// Get or set DALC component
		/// </summary>
		public IDalc Dalc {
			get { return _Dalc; }
			set { _Dalc = value; }
		}
	
		public RelationalExprResolver()
		{
		}
		
		public override object Evaluate(IDictionary context, string expression) {
			Query q = RelExQueryParser.Parse(expression);
			
			if (ReturnCount)
				return Dalc.RecordsCount(q);
			
			if (ReturnList) {
				return Dalc.LoadAllValues(q);			
			} else {
				object value = Dalc.LoadValue(q);
				return value!=null ? PrepareValue(value) : null;
			}

		}
		

		
	}*/
}

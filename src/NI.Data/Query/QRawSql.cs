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
using System.Diagnostics;

namespace NI.Data
{
	/// <summary>
	/// Represents raw SQL query value
	/// </summary>
	[DebuggerDisplay("{SqlText}")]
	[Serializable]
	public class QRawSql : IQueryValue {

		/// <summary>
		/// Get SQL text
		/// </summary>
		public string SqlText {
			get; private set;
		}
		
		/// <summary>
		/// Initializes a new instance of the QRawSql with specfield SQL text
		/// </summary>
		/// <param name="sqlText"></param>
		public QRawSql(string sqlText) {
			SqlText = sqlText;
		}
		
	}
}

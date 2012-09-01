#region License
/*
 * Open NIC.NET library (http://nicnet.googlecode.com/)
 * Copyright 2004-2012 NewtonIdeas
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
using System.Security.Principal;

namespace NI.Data.Permissions
{
	/// <summary>
	/// </summary>
	public interface IDalcConditionComposer
	{
		/// <summary>
		/// Compose condition
		/// </summary>
		/// <returns>condition or null (means no additional conditions)</returns>
		QueryNode Compose(IPrincipal user, DalcOperation operation, string sourceName);
	}


	
}

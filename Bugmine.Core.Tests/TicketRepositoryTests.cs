using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Text;

namespace Bugmine.Core.Tests
{
	[TestClass]
	public class TicketRepositoryTests
	{
		[TestMethod]
		public void Deserialize_Tickets()
		{
			string response = "{\"total_count\":22,\"limit\":2,\"offset\":0,\"issues\":[{\"updated_on\":\"2012/12/14 16:35:53 +0100\",\"author\":{\"name\":\"Jorien Ruijter\",\"id\":246},\"status\":{\"name\":\"New\",\"id\":1},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/12/14 16:35:53 +0100\",\"start_date\":\"2012/12/14\",\"subject\":\"Niet alles komt door in de Sale categorie\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Zie printscreen, deze basic shirt komen allemaal niet door in de Sale categorie.\",\"id\":28220,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/14 16:11:55 +0100\",\"author\":{\"name\":\"Jorien Ruijter\",\"id\":246},\"status\":{\"name\":\"New\",\"id\":1},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/12/14 16:11:55 +0100\",\"start_date\":\"2012/12/14\",\"subject\":\"Snapple in food categorie blijft error geven\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Snapple blijft een error geven. De oranje Snapple (mango) wordt vanuit de carroussel doorgelinkt naar de rode snapple. De rode snapple geeft nog steeds de error pagina.\",\"id\":28217,\"priority\":{\"name\":\"Normal\",\"id\":4}}]}";
		}
	}
}

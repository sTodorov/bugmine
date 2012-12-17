﻿using System;
using System.Collections.Generic;
using Bugmine.Core.Redmine.Mappers;
using Bugmine.Core.Redmine.Parsers;
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
			string response = "{\"limit\":25,\"total_count\":22,\"offset\":0,\"issues\":[{\"updated_on\":\"2012/12/17 05:24:24 +0100\",\"author\":{\"name\":\"Jorien Ruijter\",\"id\":246},\"status\":{\"name\":\"New\",\"id\":1},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"estimated_hours\":3.0,\"done_ratio\":0,\"created_on\":\"2012/12/14 16:35:53 +0100\",\"start_date\":\"2012/12/14\",\"subject\":\"Niet alles komt door in de Sale categorie\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Zie printscreen, deze basic shirt komen allemaal niet door in de Sale categorie.\",\"id\":28220,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/14 16:11:55 +0100\",\"author\":{\"name\":\"Jorien Ruijter\",\"id\":246},\"status\":{\"name\":\"New\",\"id\":1},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/12/14 16:11:55 +0100\",\"start_date\":\"2012/12/14\",\"subject\":\"Snapple in food categorie blijft error geven\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Snapple blijft een error geven. De oranje Snapple (mango) wordt vanuit de carroussel doorgelinkt naar de rode snapple. De rode snapple geeft nog steeds de error pagina.\",\"id\":28217,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/14 16:06:44 +0100\",\"author\":{\"name\":\"Jorien Ruijter\",\"id\":246},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/12/14 15:56:57 +0100\",\"start_date\":\"2012/12/14\",\"subject\":\"Alex Boxershort toont verkeerd om\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Boxershort van de Alex 1412001123 091\r\ntoont verkeerd om, maar de foto's zijn wel goed opgeslagen.\r\n\r\nZie ook printscreen\",\"id\":28216,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/13 12:43:59 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"Support\",\"id\":3},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/12/13 12:43:59 +0100\",\"start_date\":\"2012/12/13\",\"subject\":\"Incorrect stock in Concentrator\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"\",\"id\":28087,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/13 14:47:15 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"SLA\",\"id\":5},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"estimated_hours\":6.0,\"due_date\":\"2013/01/25\",\"done_ratio\":0,\"created_on\":\"2012/12/12 20:43:02 +0100\",\"start_date\":\"2012/12/12\",\"subject\":\"Reprocess failed calls to Magento (Shipment, cancel, refund) based on some rules and errors\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"\",\"id\":28048,\"priority\":{\"name\":\"High\",\"id\":5}},{\"updated_on\":\"2012/12/13 13:07:23 +0100\",\"author\":{\"name\":\"Mira de Wit\",\"id\":217},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"SLA\",\"id\":5},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"done_ratio\":100,\"created_on\":\"2012/12/12 12:10:18 +0100\",\"subject\":\"1212210 - Niet alle artikelen doorgezet naar Concentrator [PRIO: urgent]\",\"custom_fields\":[{\"value\":\"Mira.de.Wit@coolcat.nl\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Hoi Hoi\r\n\r\nEen klant belde ons om te melden dat niet alle artikelen die besteld waren ook daadwerkelijk zijn verzonden. Nu blijkt dat de order wel is doorgezet van Magento naar de Concentrator en het WMS, maar het bewuste artikel stond daar niet in. Kunnen jullie AUB nakijken waarom voor de order niet alle artikelen zijn doorgezet van Magento naar de Concentrator? Willen jullie ook aangeven of alsnog (alleen) de ontbrekende artikelregel doorgezet kan worden? Wij kunnen dan namelijk op een correcte manier de klant alsnog het artikel doen toekomen.\r\n\r\nVOORBEELD - Order 700047113\r\n\r\nOrder:                  700047113\r\nOntbreekt:         1EF5216077 65 M\r\n\r\nBesteld - Magento\r\n[cid:image002.png@01CDD85A.A00E2430]\r\n\r\nArtikelen in Concentrator\r\n[cid:image005.jpg@01CDD861.64F445D0]\r\nArtikelen in WMS (ook verzonden)\r\n[cid:image006.png@01CDD860.D9D2E6F0]\r\n\r\n\r\nAlvast bedankt en laat het AUB weten als jullie meer informatie nodig hebben!\r\n\r\n\r\nMet vriendelijke groet,\r\n\r\nMira de Wit\r\nApplication Administrator \u0026 Projects\r\n\r\n[cid:image001.gif@01CDD856.091F84A0]\r\n\r\nHoofdveste 10\r\n3992 DG Houten\r\nPostbus 125\r\n3990 DC Houten\r\n\r\nT. +31 (0) 30 6356376\r\nM.+31 (0) 6 21489941\r\nF. +31 (0) 30 6355045\r\nE. mira.de.wit@coolcat.nl\r\nS. cc-mira.de.wit\r\nPlease consider the environment before printing this email.\",\"id\":27994,\"priority\":{\"name\":\"Urgent\",\"id\":6}},{\"updated_on\":\"2012/12/12 10:07:48 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":8.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/11 13:53:15 +0100\",\"start_date\":\"2012/12/11\",\"subject\":\"Download sample epub and pdf files\",\"description\":\"\",\"id\":27921,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 10:07:11 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":4.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/11 13:51:08 +0100\",\"start_date\":\"2012/12/11\",\"subject\":\"Product images missing \",\"description\":\"See attached file\",\"id\":27920,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 10:06:53 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":4.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/11 13:50:13 +0100\",\"start_date\":\"2012/12/11\",\"subject\":\"English content on Bebook\",\"description\":\"The  Ebooks have no attirbutes in the English language. Please make sure that the English attributes are copied from the Dutch. \r\n\r\nSo, no languageid on the attribute values\",\"id\":27919,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 10:06:40 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":8.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/11 13:49:09 +0100\",\"start_date\":\"2012/12/11\",\"subject\":\"Incomplete Magento products \",\"description\":\"See word file attached\",\"id\":27918,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 10:06:14 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":6.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/11 13:47:27 +0100\",\"start_date\":\"2012/12/11\",\"subject\":\"Pricing issue\",\"description\":\"Pricing is not correct for the BeBook and ICIDU website. The values in the Concentrator are not correct. Below is an example of the BeBook Pure. Right now the price is \u20ac 80.13 ex VAT, this should be 82.60 ex VAT.  The JDE field where this price is found, is :   \u201cBP\u201d or alias: \u201cUNCS\u201d\r\n\r\nProduct: 15365142\",\"id\":27916,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 10:12:17 +0100\",\"author\":{\"name\":\"Gerrieta Dam\",\"id\":266},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":8.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/10 16:08:17 +0100\",\"start_date\":\"2012/12/10\",\"subject\":\"Product attributes\",\"description\":\"\",\"id\":27865,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/11 09:55:04 +0100\",\"author\":{\"name\":\"Gerrieta Dam\",\"id\":266},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":8.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/10 16:07:36 +0100\",\"start_date\":\"2012/12/10\",\"subject\":\"Enabling and disabling all cb products\",\"description\":\"\",\"id\":27864,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/11 09:57:00 +0100\",\"author\":{\"name\":\"Gerrieta Dam\",\"id\":266},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":2.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/10 16:06:52 +0100\",\"start_date\":\"2012/12/10\",\"subject\":\"Download link in Magento\",\"description\":\"\",\"id\":27863,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/11 10:09:29 +0100\",\"author\":{\"name\":\"Gerrieta Dam\",\"id\":266},\"status\":{\"name\":\"Approved\",\"id\":8},\"tracker\":{\"name\":\"Task\",\"id\":4},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator @ BAS - BeBook\",\"id\":636},\"estimated_hours\":8.0,\"due_date\":\"2013/01/04\",\"done_ratio\":0,\"created_on\":\"2012/12/10 16:06:11 +0100\",\"start_date\":\"2012/12/10\",\"subject\":\"Testing urls for shipment, cancellation, etc.\",\"description\":\"\",\"id\":27862,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/13 11:22:28 +0100\",\"author\":{\"name\":\"Wytse Posthumus\",\"id\":176},\"status\":{\"name\":\"Test Approved\",\"id\":10},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"estimated_hours\":2.0,\"due_date\":\"2012/11/09\",\"done_ratio\":50,\"created_on\":\"2012/10/31 14:27:58 +0100\",\"start_date\":\"2012/10/31\",\"subject\":\"Negatieve verzendkosten op pakbon (order 700034892)\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Hoi,\r\n\r\nOrder 700034892 heeft op de pakbon (negatief) 3.95 staan bij verzendkosten.\r\n\r\nWat ik weet over de order is dat hij een kortingsbon heeft (2012902, regelid: 516) voor gratis verzending. Daarnaast was er 1 product die op 0 euro stond en 1 die 5 euro koste. Het totaalbedrag van de order was dus 5 euro. Dit is betaald en de order is doorgezet.\r\n\r\nKunnen jullie uitzoeken waarom er negatieve verzendkosten op de bon staan?\r\n\r\nGroeten,\r\n Wytse\",\"id\":25415,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/11/06 11:18:28 +0100\",\"author\":{\"name\":\"Vincent Welling\",\"id\":36},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"Support\",\"id\":3},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ BAS\",\"id\":435},\"estimated_hours\":4.0,\"due_date\":\"2012/11/23\",\"done_ratio\":0,\"created_on\":\"2012/10/31 10:59:35 +0100\",\"subject\":\"***SPAM*** Magento connector aanpassing Concentrator\",\"custom_fields\":[{\"value\":\"v.welling@basgroup.nl\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"Stan,\r\n\r\nCan you place the customer email address in line 4 of the XML\r\n\r\nIf possible only for the end customers site's (not for BAS NL and BAS BE)\r\n\r\n        \u003CCustomerOverride\u003E\r\n            \u003CDropshipment\u003Etrue\u003C/Dropshipment\u003E\r\n            \u003COrderAddress\u003E\r\n                \u003CName\u003EBas Van De Ven\u003C/Name\u003E\r\n                \u003CAddressLine1\u003EAdriaen Poirtersstraat 3\u003C/AddressLine1\u003E\r\n                \u003CAddressLine2/\u003E\r\n                \u003CAddressLine3/\u003E\r\n                \u003CZipCode\u003E5144SV\u003C/ZipCode\u003E\r\n                \u003CCity\u003EWAALWIJK\u003C/City\u003E\r\n                \u003CCountry\u003ENl\u003C/Country\u003E\r\n            \u003C/OrderAddress\u003E\r\n        \u003C/CustomerOverride\u003E\r\n\r\n\r\n[cid:image001.png@01CDB756.BAF96770]\r\n\r\n\r\nVincent\",\"id\":25390,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/12 09:39:00 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Magento Support @ Coolcat\",\"id\":471},\"estimated_hours\":4.0,\"due_date\":\"2013/01/21\",\"done_ratio\":0,\"created_on\":\"2012/10/23 14:47:34 +0200\",\"start_date\":\"2012/10/23\",\"subject\":\"Move SEO texts to Concentrator\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"\",\"id\":24764,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/12/05 08:47:07 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Assigned\",\"id\":2},\"tracker\":{\"name\":\"Bug\",\"id\":1},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"due_date\":\"2012/09/19\",\"done_ratio\":0,\"created_on\":\"2012/09/14 14:47:02 +0200\",\"start_date\":\"2012/09/14\",\"subject\":\"Order status invalid\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"An orderline gets a ledger 'Ready to Order' and 'Processed KASMUT' with the same timestamp. Therefore, it keeps hanging in the Concentrator\r\n\r\nExample: OrderLine 72036\r\n\",\"id\":21595,\"priority\":{\"name\":\"Normal\",\"id\":4}},{\"updated_on\":\"2012/06/20 10:52:09 +0200\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Continuous\",\"id\":15},\"tracker\":{\"name\":\"Support\",\"id\":3},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"done_ratio\":0,\"created_on\":\"2012/06/11 08:57:25 +0200\",\"start_date\":\"2012/06/11\",\"subject\":\"Task management \",\"custom_fields\":[{\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"All hours related to managing the tasks within the project\",\"id\":14680,\"priority\":{\"name\":\"Low\",\"id\":3}},{\"updated_on\":\"2012/11/21 09:03:15 +0100\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Continuous\",\"id\":15},\"tracker\":{\"name\":\"SLA\",\"id\":5},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ Coolcat\",\"id\":396},\"done_ratio\":0,\"created_on\":\"2012/05/21 08:48:51 +0200\",\"start_date\":\"2012/05/21\",\"subject\":\"Deployment\",\"custom_fields\":[{\"value\":\"\",\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"\",\"id\":13438,\"priority\":{\"name\":\"Low\",\"id\":3}},{\"updated_on\":\"2012/06/20 11:00:08 +0200\",\"author\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"status\":{\"name\":\"Continuous\",\"id\":15},\"tracker\":{\"name\":\"Support\",\"id\":3},\"assigned_to\":{\"name\":\"Svetoslav Todorov\",\"id\":52},\"project\":{\"name\":\"Concentrator Support @ America Today\",\"id\":397},\"done_ratio\":0,\"created_on\":\"2012/05/01 07:53:10 +0200\",\"start_date\":\"2012/05/01\",\"subject\":\"Algemene support\",\"custom_fields\":[{\"name\":\"Email_Customer\",\"id\":45}],\"description\":\"\",\"id\":11995,\"priority\":{\"name\":\"Low\",\"id\":3}}]}";
			var parser = new JsonTicketParser();
			var result = parser.ParseTickets(response);

			var mapper = new TicketResultMapper();
			var ti = mapper.MapFromTicketResult(result);

			Assert.IsTrue(2 == 5);
		}
	}
}

using EasyNetQ;
using Force24.Contacts.Abstractions;
using Force24.Contacts.RabbitMq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Test3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string endpoint = "api/search";

            string key = "term";

            string test = null;

            var query = string.Format("{0}?{1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(test));

            var address = string.Format("{0}?{1}", endpoint, query);

            Console.WriteLine(address);

            var decodedStr = HttpUtility.UrlEncode(test);


            var trimTest = new TrimOrganizationNameTest();

            trimTest.Test();


            Test t = null;
            Console.WriteLine($"your name is {t?.Name}");

            //var s = "2021-01-31 22:31:07";

            var busStr =
             "host=84.18.197.174:9215;username=force24dev;password=93gRUvoi0#H!;VirtualHost=development";
            // "host=84.18.197.174:9215;username=force24prod;password=wjzhAM@aW92B;timeout=240";

            var bus = RabbitHutch.CreateBus(busStr);

            var contactService = new ContactsService.V1(bus);

            var identityContext = new IdentityContext()
            {
                CustomerId = new Guid("AC76CD96-6D1C-40D6-8192-437A91E8014D")
            };


            var upsertItems =
            new[] {
                new ContactUpsertItem.V1()
                { Id = 187368150 ,
                EmailAddress = "warrick.schlaudraff@gmail.com",
                 Fields = new Dictionary<string, object>(){ { "lastname", "Schlaudraff" }, { "emailaddress", "warrick.schlaudraff@gmail.com" } }
                }
            };


            var upsertRequest = new ContactsUpsert.V1.Request()
            {
                IdentityContext = identityContext,
                Items = upsertItems
            };

            var upsertResponse = await contactService.UpsertAsync(upsertRequest);

            if (upsertResponse.IsFail)
            {
                Console.WriteLine(upsertResponse.Error.Message);
            }








            var contacts = new int[]
            {
                192579859
             };

            var fieldsOptions = FieldsOptions.V1.FromFieldsString(FieldsOptions.V1.MissingFieldBehaviour.Fail,
            "firstname,lastname,emailaddress,mobilephone");

            var lookupResponse = await contactService.LookupContactsAsync(new ContactsLookup.V1.Request
            {
                IdentityContext = identityContext,
                ContactsLookupInfo = contacts
                .Select(id => new ContactLookupInfo.V1
                {
                    Id = id
                }).ToArray(),
                FieldsOptions = fieldsOptions,
                ContactLookupBehaviour = ContactLookupBehaviour.V1.Strict
            });

            if (lookupResponse.IsFail)
            {
                Console.WriteLine($"ContactLookUpFailed : {lookupResponse.Error.Message} ");
            }





            //var upsertItems =
            //new[] {
            //    new ContactUpsertItem.V1()
            //    { Id = 193588415 ,
            //     Fields = new Dictionary<string, object>(){ { "lastname", "test10t"}, { "firstname", "testf10t" } }
            //    }, new ContactUpsertItem.V1()
            //    { Id = 193588413 ,
            //     Fields = new Dictionary<string, object>(){ { "lastname", "test9t"}, { "firstname", "testf9t" } }
            //    }
            //};

            //var upsertRequest = new ContactsUpsert.V1.Request()
            //{
            //    IdentityContext = identityContext,
            //    Items = upsertItems
            //};

            //var upsertResponse = await contactService.UpsertAsync(upsertRequest);

            //if (upsertResponse.IsFail)
            //{
            //    Console.WriteLine(upsertResponse.Error.Message);
            //}







            Console.WriteLine(string.Join(Environment.NewLine, new Dictionary<string, string> {
                {"key1", "abc"},
                {"key2", "dec"},
                 {"key3", "value3"},
              }));

            var date1 = "2021-02-04 08:00:53";

            var b = System.Convert.ChangeType(date1, TypeCode.DateTime, CultureInfo.InvariantCulture);

            var dateString = "10-22-2015";

            CultureInfo provider = CultureInfo.InvariantCulture;
            // Output: 10/22/2015 12:00:00 AM  
            DateTime dateTime16 = DateTime.ParseExact(dateString, new string[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy" }, provider, DateTimeStyles.None);


            var date2 = dateTime16.ToUniversalTime();
            Console.WriteLine(dateTime16.Kind == DateTimeKind.Local);
            //transformedValue = actualDate.ToUniversalTime();

            CultureInfo c = CultureInfo.InvariantCulture;

            Console.WriteLine(dateTime16.ToString());
            Console.WriteLine(dateTime16.ToString(c));

            Console.WriteLine(date1 is DateTime);
        }
    }
}

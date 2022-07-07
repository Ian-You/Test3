using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test2
{
    class Program
    {
        private static readonly string stringProperty = "public string";
        private static readonly string intergerProperty = "public int?";
        private static readonly string doubleProperty = "public double?";
        private static readonly string booleanProperty = "public bool?";
        private static readonly string dateTimeProperty = "public DateTime?";
        private static readonly string propertySuffix = "{ get; set;}";

        private static readonly string intergerColumn = "INT,";
        private static readonly string stringColumn = "NVARCHAR(4000),";
        private static readonly string doubleColumn = "FLOAT,";
        private static readonly string booleanColumn = "BIT,";
        private static readonly string dateTimeColumn = "DATETIME,";

        private static readonly string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static void Main(string[] args)
        {
            //GenerateAllEntities();

            //GenerateDistinctEntityPropertyInfo("account");

            //GenerateAllEntityProperties();

            //GenerateNotFoundFields(Path.Combine(currentDirectory, "Contact.txt"), "contact", Path.Combine(currentDirectory, "ContactFieldsUnfound.txt"));
            GenerateAllFieldsFromEntity("contact", Path.Combine(currentDirectory, "ContactAllFieldsFromServer.txt"));
            //GenerateAllFieldsFromEntity("gtwuk_subscription", Path.Combine(currentDirectory, "SubscriptionAllFieldsFromServer.txt"));
            //GenerateAllFieldsFromEntity("gtwuk_interestprofile", Path.Combine(currentDirectory, "InterestProfileAllFieldsFromServer.txt"));
            //GenerateAllFieldsFromEntity("account", Path.Combine(currentDirectory, "AccountAllFieldsFromServer.txt"));

            //GenerateAccountFiles();
            //GenerateContactFiles();
            GenerateSubscriptionFiles();
            GenerateInterestProfileFiles();
            //GenerateProductUsageFiles();
            //GeneratePurchasedProductFiles();
           // GenerateExternalEventOrderFiles();
            //GenerateExternalOrderFiles();
            //GenerateEventTypeFiles();
            //GenerateEventDateFiles();
            //GenerateProductFiles();
            //GeneratePassKindFiles();
            //GenerateMembershipFiles();
            //GenerateJointMembershipFiles();
        }

        private static void GenerateProductFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "ProductProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "ProductColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "Product.txt");

            GenerateDotnetClass(fieldRequirementFile, "product", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateJointMembershipFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "JointMembershipProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "JointMembershipColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "JointMembership.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_jointmembership", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateMembershipFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "MembershipProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "MembershipColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "Membership.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_membership", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GeneratePassKindFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "PassKindProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "PassKindColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "PassKind.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_passkind", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateEventDateFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "EventDateProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "EventDateColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "EventDate.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_eventdate", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateEventTypeFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "EventTypeProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "EventTypeColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "EventType.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_eventtype", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateExternalOrderFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "externalorderProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "externalorderColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "ExternalOrder.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_externalorder", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateExternalEventOrderFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "externaleventorderProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "externaleventorderColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "ExternalEventOrder.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_externaleventorder", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GeneratePurchasedProductFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "PurchasedProductProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "PurchasedProductColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "PurchasedProduct.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_purchasedproduct", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateProductUsageFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "ProductUsageProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "ProductUsageColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "ProductUsage.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_productusage", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateSubscriptionFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "SubscripProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "SubscripColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "Subscription.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_subscription", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateInterestProfileFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "InterestProfileProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "InterestProfileColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "InterestProfile.txt");

            GenerateDotnetClass(fieldRequirementFile, "gtwuk_interestprofile", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateContactFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "contactProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "contactColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "Contact.txt");

            GenerateDotnetClass(fieldRequirementFile, "contact", propertyOutPutFileName, sqlOutPutFileName);
        }

        private static void GenerateAccountFiles()
        {
            var propertyOutPutFileName = Path.Combine(currentDirectory, "accountProperties.txt");
            var sqlOutPutFileName = Path.Combine(currentDirectory, "accountColumns.txt");
            var fieldRequirementFile = Path.Combine(currentDirectory, "Account.txt");

            GenerateDotnetClass(fieldRequirementFile, "account", propertyOutPutFileName, sqlOutPutFileName);
        }
        private static void GenerateDotnetClass(string fieldRequirementFile, string entityName, string propertyOutputFileName, string sqlOutputFileName)
        {
            var requireFields = File.ReadAllLines(fieldRequirementFile);

            var metaFields = GenerateEntityPropertyInfo(entityName);

            var sb = new StringBuilder();
            var sb1 = new StringBuilder();

            foreach (var metaField in metaFields)
            {
                if (requireFields.Select(m => m.ToLower(CultureInfo.InvariantCulture)).Contains(metaField.Name.ToLower(CultureInfo.InvariantCulture)))
                {
                    sb.AppendLine(GeneratePropertyInfo(metaField));
                    sb1.AppendLine(GenerateSqlColumn(metaField));
                }
            }

            File.WriteAllText(propertyOutputFileName, sb.ToString());
            File.WriteAllText(sqlOutputFileName, sb1.ToString());
        }

        private static void GenerateNotFoundFields(string fieldRequirementFile, string entityName, string fileName)
        {
            var requireFields = File.ReadAllLines(fieldRequirementFile);

            var metaFields = GenerateEntityPropertyInfo(entityName);

            var sb = new StringBuilder();

            foreach (var requireField in requireFields)
            {
                if ( !metaFields.Select(m => m.Name.ToLower(CultureInfo.InvariantCulture)).Contains(requireField.ToLower(CultureInfo.InvariantCulture)))
                {
                    sb.AppendLine(requireField);
                }
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        private static void GenerateAllFieldsFromEntity(string entityName, string fileName)
        {
            var metaFields = GenerateEntityPropertyInfo(entityName);

            var sb = new StringBuilder();

            foreach (var metaField in metaFields)
            {
                sb.AppendLine($"{metaField.Name}: {metaField.Type}");
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        private static string GenerateSqlColumn(EntityPropertyInfo metaField)
        {
            var type = metaField.Type switch
            {
                var f when
                      f == "Edm.String" ||
                      f == "Edm.Guid"
                      => stringColumn,
                var i when
                      i == "Edm.Int32" ||
                      i == "Edm.Int64" => intergerColumn,
                "Edm.Boolean" => booleanColumn,
                var d when
                    d == "Edm.Decimal" ||
                    d == "Edm.Double"
                    => doubleColumn,
                "Edm.DateTimeOffset" => dateTimeColumn,
                _ => throw new ArgumentException("unsupport type")
            };

            var name = metaField.Name.Substring(0, 1).ToUpper() + metaField.Name.Substring(1);
            return $"{name} {type}";
        }

        private static string GeneratePropertyInfo(EntityPropertyInfo metaField)
        {
            var type = metaField.Type switch
            {
                var f when
                      f == "Edm.String" ||
                      f == "Edm.Guid"
                      => stringProperty,
                var i when 
                      i == "Edm.Int32" ||
                      i == "Edm.Int64" => intergerProperty,
                "Edm.Boolean" => booleanProperty,
                var d when
                    d == "Edm.Decimal" ||
                    d == "Edm.Double"
                    => doubleProperty,
                "Edm.DateTimeOffset" => dateTimeProperty,
                _ => throw new ArgumentException("unsupport type")
            };
            var name = metaField.Name.Substring(0, 1).ToUpper() + metaField.Name.Substring(1);
            return $"{type} {name} {propertySuffix}";
        }

        private static EntityPropertyInfo[] GenerateEntityPropertyInfo(string entityName)
        {
            var result = new List<EntityPropertyInfo>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RMG_MetaData.xml");

            var x = XElement.Load(path).Elements().Last().Elements();

            foreach (XElement level1Element in x.Where(e => e.HasAttributes).Elements())
            {
                if (level1Element.Attribute("Name").Value == entityName)
                {
                    var e2 = level1Element.Elements().ToArray();

                    foreach (var level2Element in level1Element.Elements().Where(e =>
                        e.Attributes().Any(a => a.Name.LocalName == "Name")))
                    {
                        var name = level2Element.Attributes("Name").FirstOrDefault()?.Value;
                        var type = level2Element.Attributes("Type").FirstOrDefault()?.Value;

                        result.Add(new EntityPropertyInfo() { Name = name, Type = type });
                    }
                }
            }

            return result.ToArray();
        }

        private static void GenerateAllEntities()
        {
            var result = new List<EntityPropertyInfo>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RMG_MetaData.xml");

            var x = XElement.Load(path).Elements().Last().Elements();

            foreach (XElement level1Element in x.Where(e => e.HasAttributes).Elements())
            {
                var v = level1Element.Attributes().Where(a => a.Value == "mscrm.crmbaseentity");

                if (v.Any())
                {
                    Console.WriteLine(level1Element.Attribute("Name").Value);
                }
            }
        }

        private static void GenerateDistinctEntityPropertyInfo(string entityName)
        {
            var result = new Dictionary<string, string>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RMG_MetaData.xml");

            var x = XElement.Load(path).Elements().Last().Elements();

            foreach (XElement level1Element in x.Where(e => e.HasAttributes).Elements())
            {
                if (level1Element.Attribute("Name").Value == entityName)
                {
                    var e2 = level1Element.Elements().ToArray();

                    foreach (var level2Element in level1Element.Elements().Where(e =>
                    {
                        var attrs = e.Attributes().Where(a => a.Name.LocalName == "Name");
                        return attrs.Any();
                    }))
                    {
                        var name = level2Element.Attributes("Name").FirstOrDefault()?.Value;
                        var type = level2Element.Attributes("Type").FirstOrDefault()?.Value;

                        if (!result.ContainsKey(type))
                            result.Add(type, type);
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        private static void GenerateAllEntityProperties()
        {
            string[] allEntitiest =
            {
                "product",
                "gtwuk_jointmembership",
                "gtwuk_membership",
                "gtwuk_passkind",
                "gtwuk_eventdate",
                "gtwuk_eventtype",
                "gtwuk_externalorder",
                "gtwuk_externaleventorder",
                "gtwuk_purchasedproduct",
                "gtwuk_productusage",
                "gtwuk_subscription",
                "contact",
                "account"
            };

            foreach (var entity in allEntitiest)
            {
                GenerateEntityProperties(entity);
            }

        }

        private static void GenerateEntityProperties(string entityName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RMG_MetaData.xml");
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AllProperties", $"{entityName}.csv");

            var x = XElement.Load(path).Elements().Last().Elements();

            foreach (XElement level1Element in x.Where(e => e.HasAttributes).Elements())
            {
                if (level1Element.Attribute("Name").Value == entityName)
                {
                    var e2 = level1Element.Elements().ToArray();

                    var sb = new StringBuilder();

                    foreach (var level2Element in level1Element.Elements().Where(e =>
                     e.Attributes().Any(a => a.Name.LocalName == "Name"))
                   )
                    {
                        var name = level2Element.Attributes("Name").FirstOrDefault()?.Value;
                        var type = level2Element.Attributes("Type").FirstOrDefault()?.Value;

                        sb.AppendLine($"{name},{type}");
                    }

                    File.WriteAllText(filePath, sb.ToString());
                }
            }



        }
    }
}

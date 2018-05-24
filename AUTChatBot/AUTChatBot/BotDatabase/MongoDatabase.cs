using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Json;

namespace AUTChatBot
{
    class MongoDatabase
    {
        private const string EndpointUri = "autchatbotdb.documents.azure.com:443/";
        private const string PrimaryKey = "LyPERf5eIMs5P1CII26a6BBy6vnvxvyrj162R0UTD25vzxff4vEilMs03hV7Nnt07t8zb2l3kwSB7NbLPdzujA====";
        private DocumentClient client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

        static async Task<String> findPaperAsync(String paperName, Boolean paperCode)
        {
            IMongoClient client = getClient();

            IMongoDatabase db = client.GetDatabase("autbotdb");

            var papersList = db.GetCollection<BsonDocument>("papers");

            

            using (IAsyncCursor<BsonDocument> cursor = await papersList.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument d in batch)
                    {

                        var jsonSettings = new MongoDB.Bson.IO.JsonWriterSettings
                        {
                            OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict
                        };

                        JsonObject obj = (JsonObject)d.ToJson<MongoDB.Bson.BsonDocument>(jsonSettings);
                        




                        IEnumerable<BsonElement> elementBatch = d.ToList();
                        foreach (BsonElement e in elementBatch)
                        {
                            if (e.GetValue("paperName", new BsonString(string.Empty)).AsString == paperName && !paperCode)
                            {
                                var paperCode = e.GetValue("paperCode", new BsonString(string.Empty)).AsString;
                                return (String)paperCode;
                            }
                            else if (e.GetValue("paperCode", new BsonString(string.Empty)).AsString == paperName && paperCode)
                            {
                                var paperName = e.GetValue("paperName", new BsonString(string.Empty)).AsString;
                                return (String)paperName;
                            }
                        }
                        
                    }
                }

                return null;
            }
        }

        

        public static ImongoDatabase getClient()
        {
            return new MongoClient("mongodb://autchatbotdb:LyPERf5eIMs5P1CII26a6BBy6vnvxvyrj162R0UTD25vzxff4vEilMs03hV7Nnt07t8zb2l3kwSB7NbLPdzujA==@autchatbotdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
            
        }

        static void Main(string[] args)
        {
            try
            {
                MongoClient dbClient = new MongoClient("mongodb://autchatbotdb:LyPERf5eIMs5P1CII26a6BBy6vnvxvyrj162R0UTD25vzxff4vEilMs03hV7Nnt07t8zb2l3kwSB7NbLPdzujA==@autchatbotdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");

                // Database List
                var dbList = dbClient.ListDatabases().ToList();

                Console.WriteLine("The list of databases are :");
                foreach (var item in dbList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n\n");

                // Get Database & Collection
                IMongoDatabase db = dbClient.GetDatabase("autbotdb");
                var collList = db.ListCollections().ToList();
                Console.WriteLine("The list of collections are :");
                foreach (var item in collList)
                {
                    Console.WriteLine(item);
                }

                var degreeColl = db.GetCollection<BsonDocument>("autbotcollection");

                Degree softDev = new Degree
                {
                    Id = "BCIS.Sofware.Development",
                    years = 3,
                    papers = new Papers[]
                    {
                        // Year 1
                        new Papers
                        {
                            paper = new Paper[]
                            {
                                // Compulsory
                                new Paper { paperCode = "COMM501", paperName = "Applied Communication" },
                                new Paper { paperCode = "COMP500", paperName = "Programming 1" },
                                new Paper { paperCode = "COMP501", paperName = "Computing Technology and Society" },
                                new Paper { paperCode = "COMP502", paperName = "Foundations of IT Infrastructure" },
                                new Paper { paperCode = "COMP503", paperName = "Programming 2" },
                                new Paper { paperCode = "ENEL504", paperName = "Computer Network Principles" },
                                new Paper { paperCode = "INFS500", paperName = "Enterprise Systems" },
                                // Choose 1 of...
                                new Paper { paperCode = "MATH500", paperName = "Mathematical Concepts"},
                                new Paper { paperCode = "MATH501", paperName = "Differential and Integral Calculus"},
                                new Paper { paperCode = "MATH502", paperName = "Algebra and Discrete Mathematics"},
                                new Paper { paperCode = "STAT500", paperName = "Applied Statistics"}
                            }
                        },
                        // Year 2
                        new Papers
                        {
                            paper = new Paper[]
                            {
                                // Compulsory
                                new Paper { paperCode = "COMP600", paperName = "IT Project Management" },
                                new Paper { paperCode = "COMP602", paperName = "Software Development Practice" },
                                new Paper { paperCode = "COMP603", paperName = "Program Design and Construction" },
                                new Paper { paperCode = "INFS600", paperName = "Data and Process Modelling" },
                                new Paper { paperCode = "INFS601", paperName = "Logical Database Design" },
                                // Choose 1 of...
                                new Paper { paperCode = "COMP604", paperName = "Operating Systems"},
                                new Paper { paperCode = "INFS602", paperName = "Physical Database Design"}
                            }
                        },
                        // Year 3
                        new Papers
                        {
                            paper = new Paper[]
                            {
                                // Compulsory
                                new Paper { paperCode = "COMP704", paperName = "Research and Development Project" },
                                new Paper { paperCode = "COMP719", paperName = "Applied Human Computer Interaction" },
                                new Paper { paperCode = "ENSE701", paperName = "Contemporary Methods in Software Engineering" },
                                // Choose 1 of...
                                new Paper { paperCode = "COMP713", paperName = "Distributed and Mobile Systems"},
                                new Paper { paperCode = "COMP721", paperName = "Web Development"}
                            }
                        },
                        // Elective Papers
                        new Papers
                        {
                            paper = new Paper[]
                            {
                                // Year 1
                                new Paper { paperCode = "COMP505", paperName = "Introduction to Programming"},
                                new Paper { paperCode = "ENSE501", paperName = "Programming for Engineering Applications"},
                                new Paper { paperCode = "ENSE502", paperName = "Object Oriented Applications"},
                                // Year 2
                                new Paper { paperCode = "COMP612", paperName = "Computer Graphics Programming"},
                                new Paper { paperCode = "MATH604", paperName = "Mathematics of Finance"},
                                // Year 3
                                new Paper { paperCode = "COMP705", paperName = "Special Topic"},
                                new Paper { paperCode = "COMP710", paperName = "Game Programming"},
                                new Paper { paperCode = "COMP716", paperName = "Highly Secure Systems"},
                                new Paper { paperCode = "COMP720", paperName = "IT Project Practice"},
                                new Paper { paperCode = "COMP724", paperName = "Health Informatics"},
                                new Paper { paperCode = "INFS700", paperName = "Needs Analysis and Aquisition"}
                            }
                        }
                    }
                };

                BsonDocument test = softDev.ToBsonDocument();
                degreeColl.InsertOne(test);

                // READ
                var resultDoc = degreeColl.Find(new BsonDocument()).ToList();
                foreach (var item in resultDoc)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public class Degree
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
            public int years;
            public Papers[] papers { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        // paper is one year of papers
        public class Papers
        {
            public Paper[] paper { get; set; }
        }

        public class Paper
        {
            public string paperCode { get; set; }
            public string paperName { get; set; }
        }

    }
}

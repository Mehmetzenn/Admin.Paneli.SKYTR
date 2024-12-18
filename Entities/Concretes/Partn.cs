using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Partner : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // "_id" alanını temsil eder.

        [BsonElement("name")]
        public string Name { get; set; } // "name" alanı.

        [BsonElement("last_name")]
        public string LastName { get; set; } // "last_name" alanı.

        [BsonElement("password")]
        public string Password { get; set; } // "password" alanı.

        [BsonElement("phone_number")]
        public string PhoneNumber { get; set; } // "phone_number" alanı.

        [BsonElement("email")]
        public string Email { get; set; } // "email" alanı.

        [BsonElement("address")]
        public List<string> Address { get; set; } // "address" alanı (Array).

        [BsonElement("bank_details")]
        public List<string> BankDetails { get; set; } // "bank_details" alanı (Array).

        [BsonElement("services")]
        public List<string> Services { get; set; } // "services" alanı (Array).

        [BsonElement("documents")]
        public List<string> Documents { get; set; } // "documents" alanı (Array).

        [BsonElement("plan_type")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlanType { get; set; } // "plan_type" alanını temsil eder.

        [BsonElement("balance")]
        public decimal Balance { get; set; } // "balance" alanı.

        [BsonElement("role")]
        public string Role { get; set; } // "role" alanı.

        [BsonElement("status")]
        public string Status { get; set; } // "status" alanı.

        [BsonElement("email_verified")]
        public bool EmailVerified { get; set; } // "email_verified" alanı.

        [BsonElement("service_type")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceType { get; set; } // "service_type" alanını temsil eder.

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } // "createdAt" alanı.

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } // "updatedAt" alanı.

        [BsonElement("__v")]
        public int Version { get; set; } // "__v" alanını temsil eder.
    }
}

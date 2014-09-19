using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDB
{
    public class Employee
    {
        /// <summary>
        /// In addition, if your domain class is going to be used as the root document it must contain an Id field or property 
        /// (typically named Id although you can override that if necessary). Normally the Id will be of type ObjectId, but there are no constraints on the type of this member.
        /// </summary>
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public IList<Status> StatusL { get; set; }

        public Employee()
        {
            StatusL = new List<Status>
            {
                new Status
                {
                    Name = "Go In"
                }
            };
        }

        public void GoOut()
        {
            StatusL.Add(new Status{Name = "Go Out"});
        }
    }
}